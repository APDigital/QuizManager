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
        QuizManagerEntities entities = new QuizManagerEntities();
        QuizViewModel model = new QuizViewModel();

        [TestMethod()]
        public void GetAllAvailableQuizzesTest()
        {
           List<Quiz> listOfAllQuizzes = model.GetAllAvailableQuizzes();
            Assert.AreEqual(listOfAllQuizzes.First().Title, "Test Quiz");
        }

        [TestMethod()]
        public void GetQuizByTitleTest()
        {
            Quiz searchedForByTitle = model.GetQuizByTitle("Test Quiz");
            Assert.AreEqual(searchedForByTitle.Title, "Test Quiz");
        }

        [TestMethod()]
        public void GetAllAvailableAnswersForQuestionTest()
        {
            List<Answer> ListOfAllAvailableAnswersForQuestion = model.GetAllAvailableAnswersForQuestion(1);
            Assert.AreEqual(ListOfAllAvailableAnswersForQuestion.Count(), 4);
        }

        [TestMethod()]
        public void GetCorrectAnswerTest()
        {
            Answer correctAnswer = model.GetCorrectAnswer(1);
            Assert.AreEqual(correctAnswer.Answer1, "Yes");
            Answer incorrectAnswer = model.GetCorrectAnswer(3);
            Assert.AreEqual(incorrectAnswer.Answer1, "No");
        }
    }
}