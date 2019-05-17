using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TorneioValoran.ViewModel
{
    public class ListMatchViewModel
    {
        public int Id { get; set; }
        public string Group { get; set; }
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        public string TeamWinner { get; set; }
    }
}
