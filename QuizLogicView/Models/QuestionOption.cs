namespace QuizLogic.Models
{
    public class QuestionOption
    {
        public int QuestionOptionId { get; set; }
        public int QuestionId { get; set; } 
        public string OptionValue { get; set; }
        public bool IsCorrect { get; set; } 
        public Question Question { get; set; }
    }    
}
