using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizManager.Models
{
    public class TakeQuizViewModel
    {
        //TakeQuiz Design:
        //Get the Full List of Questions Related to a Quiz by the Quiz Title
        //Add all Questions to AvailableQuestionsByNumber. code will check whether the question has been taken by the Key in the Dictionary.
        //GetQuestion() will generate a random question from the list of available questions
        //RemoveQuestionFromAvailableList() will ensure the question cannot be taken a second time
        //StoreQuestionToUsersAnswers() will keep a record of what answers the user provides
        //CheckUsersAnswers() will check how many question sthe user answered correctly and set the users final score to "Pass" or "Fail" with their pass percentage as a string.


        private QuizManagerEntities QuizEntities = new QuizManagerEntities();
        public Quiz CurrentQuiz { get; set; }
        public Dictionary<int,Question> AvailableQuestionsByNumber { get; set; }
        public Dictionary<Question,Answer> UsersAnswers { get; set; }
        public string FinalScore { get; set; }
        public TakeQuizViewModel()
        {

        }
        public List<Question> GetListOfQuestionsByQuiz(string quizTitle)
        {
            List<Question> placeholder = new List<Question>();
            return placeholder;
        }
        public Question GetQuestion()
        {
            Question placeholder = new Question();
            return placeholder;
        }
        public void RemoveQuestionFromAvailableList(Question question)
        {

        }
        public void StoreQuestionToUsersAnswers(Question question)
        {

        }
        public void CheckUsersAnswers(Dictionary<Question,Answer> usersAnswers)
        {

        }
    }
}