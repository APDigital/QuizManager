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
    public class EditQuizViewModelTests
    {
        EditQuizViewModel model = new EditQuizViewModel();
        QuizViewModel quizViewModel = new QuizViewModel();
        QuizManagerEntities entities = new QuizManagerEntities();
        [TestMethod()]
        public void SetQuizVariablesTest()
        {
            model.CurrentQuiz = quizViewModel.GetQuizByTitle("Test Quiz");
            model.SetQuizVariables(model.CurrentQuiz);
            Assert.AreEqual(model.Id, model.CurrentQuiz.Id);
            Assert.AreEqual(model.Title, model.CurrentQuiz.Title);
            Assert.AreEqual(model.Description, model.CurrentQuiz.Description);
            Assert.AreEqual(model.PassMark, model.CurrentQuiz.PassMark);
            Assert.AreEqual(model.Category, model.CurrentQuiz.Category);
            //Do not check Questions as I am setting the Answer.IsCorrect value to be different based on the Correct Property
            //Assert.AreEqual(model.Questions, model.CurrentQuiz.Questions);
        }

        [TestMethod()]
        public void SetQuestionVariablesTest()
        {
            model.CurrentQuiz = quizViewModel.GetQuizByTitle("Test Quiz");
            model.SetQuestionVariables(1);
            Assert.AreEqual(model.CurrentQuestion.Id, 1);
            Assert.AreEqual(model.CurrentArrayOfAnswers, model.CurrentQuestion.Answers.ToArray());
        }

        [TestMethod()]
        public void SaveQuizDetailsTest()
        {
            model.CurrentQuiz = quizViewModel.GetQuizByTitle("Test Quiz");
            model.SetQuizVariables(model.CurrentQuiz);
            model.Description = "Changed Value Test";
            model.SaveQuizDetails();
            Assert.AreEqual(entities.Quizs.Where(x => x.Title == "Test Quiz").Single().Description, "Changed Value Test");
        }

        [TestMethod()]
        public void SaveQuestionDetailsTest()
        {
            model.CurrentQuiz = quizViewModel.GetQuizByTitle("Test Quiz");
            model.SetQuestionVariables(1);
            model.CurrentQuestion.Question1 = "Changed Value Test";
            model.SaveQuestionDetails();
            Assert.AreEqual(entities.Questions.Where(x => x.Id == model.CurrentQuestion.Id).Single().Question1, "Changed Value Test");

            model.CurrentQuestion.Question1 = "Is this a Test Question?";
            model.SaveQuestionDetails();
        }
    }
}