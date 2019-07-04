using QuizManager.Models;
using QuizManager.QuizManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizManager.Controllers
{
    public class QuizAdminController : Controller
    {
        private QuizAdmin quizAdmin = new QuizAdmin();
        private QuizViewModel quizViewModel = new QuizViewModel();
        [Authorize(Roles = "Edit")]
        // GET: Edit Quiz
        public ActionResult EditQuiz(EditQuizViewModel model, string QuizName)
        {
            if (model.Id == 0)
            {
                model.CurrentQuiz = quizViewModel.GetQuizByTitle(QuizName);
                model.SetQuizVariables(model.CurrentQuiz);
            }
            else
            {
                model.SaveQuizDetails();
            }
            model.Categories = quizViewModel.Categories;
            return View(model);
        }

        [Authorize(Roles = "Edit")]
        //GET: Edit Questions
        public ActionResult EditQuestions(EditQuizViewModel model, int QuestionId, string QuizName)
        {
            if (model.CurrentQuestion == null)
            {
                model.CurrentQuiz = quizViewModel.GetQuizByTitle(QuizName);
                model.SetQuestionVariables(QuestionId);
            }
            else
            {
                model.SaveQuestionDetails();
                return RedirectToAction("EditQuiz", new { QuizName = model.CurrentQuiz.Title });
            }
            return View(model);
        }
        [Authorize(Roles = "Edit")]
        //GET: Add Quiz 
        public ActionResult AddQuiz(QuizViewModel model)
        {
            if (model.NewQuizItem == null)
            {
                return View(model);
            }
            else
            {
                quizAdmin.AddQuiz(model.NewQuizItem);
                return RedirectToAction("AddQuestions");
            }
        }
        [Authorize(Roles = "Edit")]
        //GET: Add Questions
        public ActionResult AddQuestions(QuizViewModel model)
        {
            if (model.Question == null)
            {
                return View(model);
            }
            else
            {
                quizAdmin.AddQuestionAndAnswers(model.Question, model.ArrayOfAnswers.ToList());
                return View(model);
            }
        }
        [Authorize(Roles = "Edit")]
        // GET: Add Category
        public ActionResult AddCategory(QuizViewModel model)
        {
            quizAdmin.AddCategory(model.NewCategory.Title);
            return RedirectToAction("AddQuiz");
        }
        [Authorize(Roles = "Edit")]
        public ActionResult FinishQuizCreation()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}