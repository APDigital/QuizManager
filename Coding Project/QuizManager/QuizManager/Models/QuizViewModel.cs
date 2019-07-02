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

        public QuizViewModel()
        {

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