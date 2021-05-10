using System;
using System.Collections.Generic;

namespace QuizLogic.Models
{
    public class StudentResponse
    {
        public int StudentResponseId { get; set; }
        public int StudentId { get; set; }     
        public int TotalQuestion { get; set; }
        public double Score { get; set; }
        public double TotalScore { get; set; }
        public double ScoreInPercentage { get; set; }
        public string GradeRemark { get; set; }
        public string GradeDescription { get; set; }
        public DateTime DateTaken { get; set; }
        public Student Student { get; set; }
        public ICollection<StudentQuestion> StudentQuestions { get; set; }
    }


    
}
