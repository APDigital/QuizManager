using QuizManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizManager.Controllers
{
    public class QuizAdminController : Controller
    {
        // GET: QuizAdmin
        public ActionResult Index()
        {
            return View();
        }
        //GET: Add Quiz 
        public ActionResult AddQuiz(QuizViewModel model)
        {
            return View(model);
        }
        //GET: Add Questions
        public ActionResult AddQuestions(QuizViewModel model)
        {
            return View(model);
        }
        // GET: Add Category
        public ActionResult AddCategory(QuizViewModel model)
        {
            return RedirectToAction("AddQuiz");
        }
        public ActionResult FinishQuizCreation()
        {
            return RedirectToAction("Index");
        }
    }
}