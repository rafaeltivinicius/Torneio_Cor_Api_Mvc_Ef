using System;

namespace ApiTorneioValoran.Models
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Group Group { get; set; }
        public Team RsultTeamChampion { get; set; }

        //navigation property Entity
        public int IdGrupo { get; set; }
        public int IdRsultTeamChampion { get; set; }
    }
}
