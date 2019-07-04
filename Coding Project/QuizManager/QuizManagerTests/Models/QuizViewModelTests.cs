using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizManager.Models.Tests
{
    [TestClass()]
    public class QuizViewModelTests
    {
        QuizViewModel model = new QuizViewModel();

        [TestMethod()]
        public void GetAllAvailableQuizzesTest()
        {
            model.GetAllAvailableQuizzes();
           List<Quiz> listOfAllQuizzes = model.ListOfAllQuizes;
            Assert.AreEqual(listOfAllQuizzes.First().Title, "Test Quiz");
        }

        [TestMethod()]
        public void GetQuizByTitleTest()
        {
            Quiz searchedForByTitle = model.GetQuizByTitle("Test Quiz");
            Assert.AreEqual(searchedForByTitle.Title, "Test Quiz");
        }
    }
}