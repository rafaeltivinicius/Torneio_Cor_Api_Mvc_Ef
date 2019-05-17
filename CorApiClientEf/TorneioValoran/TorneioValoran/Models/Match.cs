using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TorneioValoran.Models
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Group Group { get; set; }
        public Team RsultTeamChampion { get; set; }
    }
}
