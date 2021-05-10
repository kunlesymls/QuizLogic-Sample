namespace QuizLogic.Models
{
    public class StudentAnswer
    {
        public int StudentAnswerId { get; set; }
        public int StudentQuestionId { get; set; }
        public string AnswerValue { get; set; }
        public bool IsSelected { get; set; }
        public bool IsCorrect { get; set; }
        public StudentQuestion StudentQuestions { get; set; }
    }


    
}
