using System.Collections.Generic;

namespace ApiTorneioValoran.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Fase { get; set; }
        public List<Team> Teams { get; set; }

        //navigation property Entity
        public Match Match { get; set; }

        public Group() { }
        public Group(string name, List<Team> teams, int fase)
        {
            this.Teams = new List<Team>();
            this.Name = name;
            this.Teams = teams;
            this.Fase = fase;


        }
    }
}
