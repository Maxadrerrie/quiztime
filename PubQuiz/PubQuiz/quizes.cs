using M.NetStandard.CommonInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubQuiz
{
    public class quizes : BoxItem
    {
        public string Titel { get; set; }
        public int quizid { get; set; }

        public string GetBoxItemTitle()
        {
            return Titel;
        }
    }
}
