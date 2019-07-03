using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizManager.Models
{
    public class QuizViewModel
    {
        private QuizManagerEntities QuizEntities = new QuizManagerEntities();
        public string SearchByQuizTitle { get; set; }
        public List<Quiz> ListOfAllQuizes { get; set; }
        public Quiz NewQuizItem { get; set; }
        public Category NewCategory { get; set; }
        public List<Category> Categories { get; set; }
        public Question Question { get; set; }
        public Answer[] ArrayOfAnswers { get; set; }
        public Quiz CurrentQuiz { get; set; }
        public Quiz EditedQuiz { get; set; }

        public QuizViewModel()
        {
            Categories = QuizEntities.Categories.ToList();
        }
        public void GetAllAvailableQuizzes()
        {
            ListOfAllQuizes = QuizEntities.Quizs.ToList();
        }
        public Quiz GetQuizByTitle(string quizTitle)
        {
            return QuizEntities.Quizs.Where(x => x.Title == quizTitle).Single();
        }
    }
}