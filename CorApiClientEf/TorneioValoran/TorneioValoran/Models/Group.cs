using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TorneioValoran.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Team> Teams { get; set; }
 
        public Group()
        {
            Teams = new List<Team>();
        }
    }
}
