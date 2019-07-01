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
            return View(model);
        }
        //GET: Question Page
        public ActionResult Question(TakeQuizViewModel model, string QuizName)
        {
            return View(model);
        }
        //GET: Finish Quiz page
        public ActionResult QuizFinish(string score, TakeQuizViewModel model)
        {
            return View(model);
        }
    }
}