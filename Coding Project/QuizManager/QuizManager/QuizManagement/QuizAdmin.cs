using QuizManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizManager.QuizManagement
{
    public class QuizAdmin
    {
        //Code behind Manage Quiz Page
        private QuizManagerEntities QuizEntities = new QuizManagerEntities();
        private QuizViewModel quizViewModel = new QuizViewModel();
        public QuizAdmin()
        {

        }
        public void AddQuiz(Quiz newQuizItem)
        {
            bool alreadyExists = QuizEntities.Quizs.Any(x => x.Title == newQuizItem.Title);
            if (alreadyExists == false)
            {
                quizViewModel.GetAllAvailableQuizzes();
                var listOfAllQuizzes = quizViewModel.ListOfAllQuizes;
                var selectedCategory = QuizEntities.Categories.Where(m => m.Title == newQuizItem.Category.Title).Single();
                newQuizItem.Category = selectedCategory;
                newQuizItem.CategoryId = selectedCategory.Id;
                newQuizItem.Id = listOfAllQuizzes.Last().Id + 1;
                newQuizItem.DateCreated = DateTime.Now;
                QuizEntities.Quizs.Add(newQuizItem);
                QuizEntities.SaveChanges();
            }
        }
        public void AddCategory(string categoryName)
        {
            List<Category> currentCategories = QuizEntities.Categories.ToList();
            Category newCategory = new Category();
            newCategory.Title = categoryName;
            newCategory.Id = currentCategories.Last().Id + 1;
            QuizEntities.Categories.Add(newCategory);
            QuizEntities.SaveChanges();
        }
        public void AddQuestionAndAnswers(Question question, List<Answer> answers)
        {
            List<Question> currentListOfQuestions = QuizEntities.Questions.ToList();
            question.Id = currentListOfQuestions.Last().Id + 1;
            question.QuizId = QuizEntities.Quizs.ToList().Last().Id;
            question.Quiz = QuizEntities.Quizs.Where(m => m.Id == question.QuizId).Single();
            QuizEntities.Questions.Add(question);
            QuizEntities.SaveChanges();

            foreach (var answer in answers)
            {
                List<Answer> currentListOfAnswers = QuizEntities.Answers.ToList();
                answer.QuestionId = question.Id;
                answer.Id = currentListOfAnswers.Last().Id + 1;
                if (answer.IsCorrect == true)
                {
                    answer.Correct = 1;
                }
                else
                {
                    answer.Correct = 0;
                }

                QuizEntities.Answers.Add(answer);
                QuizEntities.SaveChanges();
            }
        }
    }
}