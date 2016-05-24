using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_v_0._1.BO
{
    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Test Test { get; set; }
        public SlideShow SlideShow { get; set; }
    }
}
