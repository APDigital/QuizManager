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
        [Authorize(Roles = "Edit")]
        // GET: QuizAdmin
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Edit")]
        //GET: Add Quiz 
        public ActionResult AddQuiz(QuizViewModel model)
        {
            return View(model);
        }
        [Authorize(Roles = "Edit")]
        //GET: Add Questions
        public ActionResult AddQuestions(QuizViewModel model)
        {
            return View(model);
        }
        [Authorize(Roles = "Edit")]
        // GET: Add Category
        public ActionResult AddCategory(QuizViewModel model)
        {
            return RedirectToAction("AddQuiz");
        }
        [Authorize(Roles = "Edit")]
        public ActionResult FinishQuizCreation()
        {
            return RedirectToAction("Index");
        }
    }
}