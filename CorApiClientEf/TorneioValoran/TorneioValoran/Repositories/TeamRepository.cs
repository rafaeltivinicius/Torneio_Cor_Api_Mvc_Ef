using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TorneioValoran.Models;
using TorneioValoran.Repositories.Interfaces;

namespace TorneioValoran.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly string _urlApi = "https://localhost:5001/api/team/";

        public List<Team> ListTeam()
        {
            IEnumerable<Team> team = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_urlApi);

                var responseTask = client.GetAsync("GetAll");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Team>>();
                    readTask.Wait();

                    team = readTask.Result;
                }
                else
                {
                    team = Enumerable.Empty<Team>();
                }
            }

            return null;
        }
        
        public List<Team> Create(List<Team> teams)
        {
            IEnumerable<Team> team = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_urlApi);

                var responseTask = client.PostAsJsonAsync("Create", teams);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Team>>();
                    readTask.Wait();

                    team = readTask.Result;
                }
                else
                {
                    team = Enumerable.Empty<Team>();
                }
            }
            
            return team.ToList();
        }
    }
}
