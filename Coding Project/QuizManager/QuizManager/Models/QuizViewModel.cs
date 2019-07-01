using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizManager.Models
{
    public class QuizViewModel
    {
        private QuizManagerEntities QuizEntities = new QuizManagerEntities();

        public QuizViewModel()
        {

        }
        public List<Quiz> GetAllAvailableQuizzes()
        {
            List<Quiz> placeholder = new List<Quiz>();
            return placeholder;
        }
        public Quiz GetQuizByTitle(string quizTitle)
        {
            Quiz placeholder = new Quiz();
            return placeholder;
        }
        public List<Answer> GetAllAvailableAnswersForQuestion(int questionId)
        {
            List<Answer> placeholder = new List<Answer>();
            return placeholder;
        }
        public Answer GetCorrectAnswer(int questionId)
        {
            Answer placeholder = new Answer();
            return placeholder;
        }
    }
}