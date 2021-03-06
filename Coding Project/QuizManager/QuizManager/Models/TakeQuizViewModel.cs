﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizManager.Models
{
    public class TakeQuizViewModel
    {
        private QuizManagerEntities QuizEntities = new QuizManagerEntities();
        public Quiz CurrentQuiz { get; set; }
        public Question CurrentQuestion { get; set; }
        public List<Answer> CurrentAnswers { get; set; }
        public Dictionary<int, Question> AvailableQuestionsByNumber { get; set; }
        public Dictionary<Question, Answer> UsersAnswers { get; set; }
        public string FinalScore { get; set; }
        private QuizViewModel quizViewModel = new QuizViewModel();
        public TakeQuizViewModel()
        {
            AvailableQuestionsByNumber = new Dictionary<int, Question>();
            UsersAnswers = new Dictionary<Question, Answer>();
        }
        public List<Question> GetListOfQuestionsByQuiz(string quizTitle)
        {
            int questionNumber = 1;
            CurrentQuiz = quizViewModel.GetQuizByTitle(quizTitle);
            List<Question> listOfQuestions = CurrentQuiz.Questions.ToList();

            foreach (var question in listOfQuestions)
            {
                if (questionNumber != 1)
                {
                    AvailableQuestionsByNumber.Add(questionNumber, question);
                    questionNumber = questionNumber + 1;
                }
                else
                {
                    Question item = question;
                    AvailableQuestionsByNumber.Add(questionNumber, item);
                    questionNumber = questionNumber + 1;
                }
            }
            return listOfQuestions;
        }
        public Question GetRandomQuestion()
        {
            Random random = new Random();
            int randomNumber = 0;
            if (AvailableQuestionsByNumber.Count > 1)
            {
                List<int> listOfAvailableKeys = new List<int>();
                foreach (var item in AvailableQuestionsByNumber)
                {
                    listOfAvailableKeys.Add(item.Key);
                }
                int[] arrayOfAvailableKeys = listOfAvailableKeys.ToArray();
                do
                {
                    randomNumber = arrayOfAvailableKeys[random.Next(1, arrayOfAvailableKeys.Length)];
                } while (AvailableQuestionsByNumber.Any(x => x.Key == randomNumber) == false);
            }
            else
            {
                randomNumber = AvailableQuestionsByNumber.Single().Key;
            }

            var question = AvailableQuestionsByNumber.Where(x => x.Key == randomNumber).Single();
            return question.Value;
        }
        public void RemoveQuestionFromAvailableList(Question question)
        {
            var dictionaryQuestion = AvailableQuestionsByNumber.Where(x => x.Value == question).Single();
            AvailableQuestionsByNumber.Remove(dictionaryQuestion.Key);
        }
        public void StoreQuestionToUsersAnswers(Question question)
        {
            Answer selectedAnswer = CurrentAnswers.Where(x => x.IsSelected == true).Single();
            Answer dbSelectedAnswer = QuizEntities.Answers.Where(x => x.Id == selectedAnswer.Id).Single();
            UsersAnswers.Add(question, dbSelectedAnswer);
        }
        public void CheckUsersAnswers(Dictionary<Question, Answer> usersAnswers)
        {
            List<Answer> CorrectAnswers = new List<Answer>();
            List<Answer> IncorrectAnswers = new List<Answer>();
            foreach (var answer in usersAnswers)
            {
                if (answer.Value.Correct == 1)
                {
                    CorrectAnswers.Add(answer.Value);
                }
                else
                {
                    IncorrectAnswers.Add(answer.Value);
                }
            }
            decimal totalQuestions = IncorrectAnswers.Count + CorrectAnswers.Count;
            decimal passPercentage = Math.Round((CorrectAnswers.Count / totalQuestions) * 100, 0);

            if (CorrectAnswers.Count >= CurrentQuiz.PassMark)
            {
                FinalScore = string.Format("Congratulations You passed! \n You Scored {0}%", passPercentage);
            }
            else
            {
                FinalScore = string.Format("We're sorry, you did not pass. \n You Scored {0}%", passPercentage);
            }
        }
    }
}