using QuizManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizManager.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "Restricted, Edit , View")]
        public ActionResult Index(QuizViewModel model)
        {
            if (model.SearchByQuizTitle == null)
            {
                model = new QuizViewModel();
                model.GetAllAvailableQuizzes();
            }
            else
            {
                List<Quiz> newList = new List<Quiz>();
                newList.Add(model.GetQuizByTitle(model.SearchByQuizTitle));
                model.ListOfAllQuizes = newList;
            }
            return View(model);
        }
    }
}