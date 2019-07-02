using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizManager.Models;
using QuizManager.QuizManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizManager.QuizManagement.Tests
{
    [TestClass()]
    public class QuizAdminTests
    {
        QuizManagerEntities entities = new QuizManagerEntities();
        QuizAdmin admin = new QuizAdmin();
        QuizViewModel model = new QuizViewModel();
    
        [TestMethod()]
        public void AddQuizTest()
        {
            Quiz newQuiz = new Quiz()
            {
                DateCreated = DateTime.Now,
                Title = "New Test Quiz",
                Description = "New Test Description",
                Author = "Aoife",
                PassMark = 40,
                Category = entities.Categories.Where(x => x.Id == 1).Single()
            };
            admin.AddQuiz(newQuiz);
            model.GetAllAvailableQuizzes();
            List<Quiz> quizzes = model.ListOfAllQuizes;
            Assert.AreEqual(quizzes.Last().Title, "New Test Quiz");
        }

        [TestMethod()]
        public void AddCategoryTest()
        {
            admin.AddCategory("New Category");
            Assert.AreEqual(entities.Categories.ToList().Last().Title, "New Category"); ;
        }

        [TestMethod()]
        public void AddQuestionAndAnswersTest()
        {
            List<Answer> answersForQuestion = new List<Answer>() {
                new Answer()
                {
                    Answer1 = "A",
                    Explanation = "Incorrect",
                    QuestionId = 2,
                    IsCorrect = false
                },
                new Answer()
                {
                    Answer1 = "B",
                    Explanation = "Incorrect",
                    QuestionId = 2,
                    IsCorrect = false
                },
                new Answer()
                {
                    Answer1 = "C",
                    Explanation = "Incorrect",
                    QuestionId = 2,
                    IsCorrect = false
                },
                new Answer()
                {
                    Answer1 = "D",
                    Explanation = "Correct",
                    QuestionId = 2,
                    IsCorrect = true
                }
            };
            Question question = new Question()
            {
                QuizId = 2,
                Question1 = "Pick a Letter"
            };
            admin.AddQuestionAndAnswers(question, answersForQuestion);
            Assert.AreEqual(entities.Questions.ToList().Last().Question1, "Pick a Letter");
            Assert.AreEqual(entities.Answers.ToList().Last().Correct, 1);
        }
    }
}