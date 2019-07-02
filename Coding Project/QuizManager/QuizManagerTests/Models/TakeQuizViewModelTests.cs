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
    public class TakeQuizViewModelTests
    {
        TakeQuizViewModel model = new TakeQuizViewModel();
        QuizManagerEntities entities = new QuizManagerEntities();

        [TestMethod()]
        public void GetListOfQuestionsByQuizTest()
        {
            model.GetListOfQuestionsByQuiz("Test Quiz");
            var firstQuestion = model.CurrentQuiz.Questions.First();
            Assert.IsNotNull(model.AvailableQuestionsByNumber);
            Assert.AreEqual(model.AvailableQuestionsByNumber.First().Value, firstQuestion);
        }

        [TestMethod()]
        public void GetRandomQuestionTest()
        {
            model.GetListOfQuestionsByQuiz("Test Quiz");
            var question1 = model.GetRandomQuestion();
            model.RemoveQuestionFromAvailableList(question1);
            var question2 = model.GetRandomQuestion();
            Assert.AreNotEqual(question1.Id, question2.Id);
        }

        [TestMethod()]
        public void RemoveQuestionFromAvailableListTest()
        {
            model.GetListOfQuestionsByQuiz("Test Quiz");
            var availableQuestions = model.AvailableQuestionsByNumber;
            int startCount = availableQuestions.Count();
            model.RemoveQuestionFromAvailableList(availableQuestions.Where(x => x.Key == 1).Single().Value);
            int endCount = availableQuestions.Count();
            Assert.AreEqual(startCount-1,endCount);
        }

        [TestMethod()]
        public void StoreQuestionToUsersAnswersTest()
        {
            model.GetListOfQuestionsByQuiz("Test Quiz");
            var currentQuestion = model.AvailableQuestionsByNumber.First().Value;
            model.CurrentAnswers = currentQuestion.Answers.ToList();
            model.CurrentAnswers.First().IsSelected = true;
            model.StoreQuestionToUsersAnswers(currentQuestion);
            Assert.AreEqual(model.UsersAnswers.First().Key, currentQuestion);
        }

        [TestMethod()]
        public void CheckUsersAnswersTestCorrect()
        {
            model.GetListOfQuestionsByQuiz("Test Quiz");
            var currentQuestion = model.AvailableQuestionsByNumber.First().Value;
            model.CurrentAnswers = currentQuestion.Answers.ToList();
            model.CurrentAnswers.Last().IsSelected = true;
            model.StoreQuestionToUsersAnswers(currentQuestion);

            model.CheckUsersAnswers(model.UsersAnswers);
            Assert.AreEqual(model.FinalScore, "Congratulations You passed! \n You Scored 100%");
        }
        [TestMethod()]
        public void CheckUsersAnswersTestIncorrect()
        {
            model.GetListOfQuestionsByQuiz("Test Quiz");
            var currentQuestion = model.AvailableQuestionsByNumber.First().Value;
            model.CurrentAnswers = currentQuestion.Answers.ToList();
            model.CurrentAnswers.First().IsSelected = true;
            model.StoreQuestionToUsersAnswers(currentQuestion);

            model.CheckUsersAnswers(model.UsersAnswers);
            Assert.AreEqual(model.FinalScore, "We're sorry, you did not pass. \n You Scored 0%");
        }
    }
}