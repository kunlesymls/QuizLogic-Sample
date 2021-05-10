using System.Collections.Generic;

namespace QuizLogic.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public ICollection<QuestionRule> QuestionRules { get; set; }
    }
    
}
