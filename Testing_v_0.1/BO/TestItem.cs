using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_v_0._1.BO
{
    public class TestItem
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public Answer CorrectAnswer { get; set; }
        public List<Answer> WrongAnswers { get; set; }
        public List<Answer> AnswersToDisplay
        {
            get
            {
                Random rnd = new Random();

                var answers = new List<Answer>();
                answers.Add(CorrectAnswer);

                var wrongAnswers = WrongAnswers.OrderBy(x => rnd.Next()).Take(2);
                answers.AddRange(wrongAnswers);

                return answers.OrderBy(x => rnd.Next()).Take(3).ToList();
            }
        }

        public Answer Answered { get; set; }
    }
}
