using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizManager.Models
{
    public class EditQuizViewModel
    {
        public Quiz CurrentQuiz { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PassMark { get; set; }
        public Category Category { get; set; }
        public List<Category> Categories { get; set; }
        public ICollection<Question> Questions { get; set; }

        public Question CurrentQuestion { get; set; }
        public Answer[] CurrentArrayOfAnswers { get; set; }

        private QuizManagerEntities QuizEntities = new QuizManagerEntities();
        public EditQuizViewModel()
        {

        }
        public void SetQuizVariables(Quiz currentQuiz)
        {
            Id = currentQuiz.Id;
            Title = currentQuiz.Title;
            Description = currentQuiz.Description;
            PassMark = currentQuiz.PassMark;
            Category = currentQuiz.Category;
            Questions = currentQuiz.Questions;
            foreach (var question in Questions)
            {
                foreach (var answer in question.Answers)
                {
                    if (answer.Correct == 1)
                    {
                        answer.IsCorrect = true;
                    }
                    else
                    {
                        answer.IsCorrect = false;
                    }
                }
            }
        }
        public void SetQuestionVariables(int questionId)
        {
            CurrentQuestion = QuizEntities.Questions.Where(x => x.Id == questionId).Single();
            CurrentArrayOfAnswers = CurrentQuestion.Answers.ToArray();
            foreach (var answer in CurrentArrayOfAnswers)
            {
                if (answer.Correct == 1)
                {
                    answer.IsCorrect = true;
                }
                else
                {
                    answer.IsCorrect = false;
                }
            }
        }
        public void SaveQuizDetails()
        {
            Quiz currentQuiz = QuizEntities.Quizs.Where(x => x.Id == Id).Single();
            currentQuiz.Title = Title;
            currentQuiz.Description = Description;
            currentQuiz.PassMark = PassMark;
            currentQuiz.Category = QuizEntities.Categories.Where(x => x.Title == Category.Title).Single();
            QuizEntities.SaveChanges();

            Questions = currentQuiz.Questions;
        }
        public void SaveQuestionDetails()
        {
            Question currentQuestion = QuizEntities.Questions.Where(x => x.Id == CurrentQuestion.Id).Single();
            currentQuestion.Quiz = QuizEntities.Quizs.Where(x=>x.Title == CurrentQuiz.Title).Single();
            currentQuestion.Question1 = CurrentQuestion.Question1;
            
            foreach (var answer in currentQuestion.Answers)
            {
                Answer editedAnswer = CurrentArrayOfAnswers.Where(x => x.Id == answer.Id).Single();
                answer.Answer1 = editedAnswer.Answer1;
                answer.Explanation = editedAnswer.Explanation;
                if (editedAnswer.IsCorrect==true)
                {
                    answer.Correct = 1;
                }
                else
                {
                    answer.Correct = 0;
                }
            }
            QuizEntities.SaveChanges();
        }
    }
}