using QuizManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizManager.Controllers
{
    public class QuizController : Controller
    {
        // GET: Quiz
        public ActionResult Index(TakeQuizViewModel model, string QuizName)
        {
            if (model.CurrentQuiz == null)
            {
                model = new TakeQuizViewModel();
            }
            model.GetListOfQuestionsByQuiz(QuizName);
            Session["CurrentQuiz"] = model.CurrentQuiz;
            return View(model);
        }
        //GET: Question Page
        public ActionResult Question(TakeQuizViewModel model, string QuizName)
        {
            model.CurrentQuiz = Session["CurrentQuiz"] as Quiz;
            if (model.CurrentAnswers == null)
            {
                model.GetListOfQuestionsByQuiz(QuizName);
                model.CurrentQuestion = model.GetRandomQuestion();
                model.CurrentAnswers = model.CurrentQuestion.Answers.ToList();
                model.UsersAnswers = new Dictionary<Question, Answer>();

                Session["CurrentQuestion"] = model.CurrentQuestion;
                Session["CurrentAnswers"] = model.CurrentAnswers;
                Session["AvailableQuestions"] = model.AvailableQuestionsByNumber;
                Session["UsersAnswers"] = model.UsersAnswers;
            }
            model.CurrentQuestion = Session["CurrentQuestion"] as Question;
            model.AvailableQuestionsByNumber = Session["AvailableQuestions"] as Dictionary<int, Question>;
            model.UsersAnswers = Session["UsersAnswers"] as Dictionary<Question, Answer>;
            if (model.CurrentAnswers.Any(x => x.IsSelected == true) && model.AvailableQuestionsByNumber.Count != 0)
            {
                model.StoreQuestionToUsersAnswers(model.CurrentQuestion);
                Session["UsersAnswers"] = model.UsersAnswers;
                model.RemoveQuestionFromAvailableList(model.CurrentQuestion);
                if (model.AvailableQuestionsByNumber.Count != 0)
                {
                    model.CurrentQuestion = model.GetRandomQuestion();
                    model.CurrentAnswers = model.CurrentQuestion.Answers.ToList();
                    Session["CurrentQuestion"] = model.CurrentQuestion;
                    Session["CurrentAnswers"] = model.CurrentAnswers;
                }
                foreach (var item in model.CurrentAnswers)
                {
                    item.IsSelected = false;
                }
            }
            if (model.AvailableQuestionsByNumber.Count != 0)
            {
                return View(model);
            }
            else
            {
                model.UsersAnswers = Session["UsersAnswers"] as Dictionary<Question, Answer>;
                model.CheckUsersAnswers(model.UsersAnswers);
                Session["UsersAnswers"] = model.UsersAnswers;
                return RedirectToAction("QuizFinish", model);
            }
        }
        //GET: Finish Quiz page
        public ActionResult QuizFinish(string score, TakeQuizViewModel model)
        {
            model.UsersAnswers = Session["UsersAnswers"] as Dictionary<Question, Answer>;
            return View(model);
        }
    }
}