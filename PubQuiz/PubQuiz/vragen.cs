using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M.Core.Application.ControlHelpers;

namespace PubQuiz
{
    public class vragen
    {
        public int quizid { get; set; }
        public int Tijd { get; set; }
        public string Foto { get; set; }
        public string Vragen { get; set; }
        public string GoedeAntwoord { get; set; }
        public string Fouteantwoordeen { get; set; }
        public string Fouteantwoordtwee { get; set; }
        public string Fouteantwoorddrie { get; set; }
    }
}
