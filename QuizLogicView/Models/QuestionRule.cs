using System;

namespace QuizLogic.Models
{
    public class QuestionRule
    {
        public int QuestionRuleId { get; set; }
        public int SubjectId { get; set; }
        public double ScorePerQuestion { get; set; }
        public bool AnswerAllQuestion { get; set; }
        public int TotalQuestion { get; set; }
        public bool UseUnlimitedTime { get; set; }
        public int MaximumTime { get; set; } // in seconds
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NoOfAllowedAttempt { get; set; }
        public int NoOfAttemptPerDay { get; set; }
        public Subject Subject { get; set; }
    }


    
}
