namespace ApiTorneioValoran.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //navigation property Entity
        public Group Group { get; set; }
        public Match Match { get; set; }

        public Team() { }
        public Team(Group group)
        {
            this.Group = group;
        }

    }
}
