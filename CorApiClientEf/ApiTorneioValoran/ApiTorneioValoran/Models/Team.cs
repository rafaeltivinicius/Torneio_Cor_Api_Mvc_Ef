using System.Collections.Generic;

namespace ApiTorneioValoran.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //navigation property Entity
        public Group Group { get; set; }
        public List<Match> Match { get; set; }

        public Team() { }
        public Team(Group group)
        {
            this.Match = new List<Match>();
            this.Group = group;
        }

    }
}
