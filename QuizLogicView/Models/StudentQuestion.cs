using System.Collections.Generic;

namespace QuizLogic.Models
{
    public class StudentQuestion
    {
        public int StudentQuestionId { get; set; }
        public int StudentResponseId { get; set; }
        public int StudentId { get; set; }
        public int QuestionNumber { get; set; }
        public string Question { get; set; }
        public string QuestionHint { get; set; }
        public string QuestionTypeName { get; set; }
        public StudentResponse StudentResponse { get; set; }
        public ICollection<StudentAnswer> StudentAnswers { get; set; }
    }
    
}
