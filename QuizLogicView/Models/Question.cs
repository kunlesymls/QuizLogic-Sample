using System.Collections.Generic;

namespace QuizLogic.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public int SubjectId { get; set; }
        public int QuestionNumber { get; set; } 
        public string QuestionName { get; set; }
        public string QuestionHint { get; set; } 
        public QuestionType QuestionType { get; set; } 
        public Subject Subject { get; set; }
        public ICollection<QuestionOption> QuestionOptions { get; set; }
    }


    
}
