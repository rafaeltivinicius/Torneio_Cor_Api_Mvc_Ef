using Microsoft.CodeAnalysis.Differencing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TorneioValoran.Models;
using TorneioValoran.Repositories.Interfaces;

namespace TorneioValoran.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private readonly string _urlApi = "https://localhost:5001/api/match/";

        public List<Match> ListGroup()
        {
            IEnumerable<Match> group = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_urlApi);

                var responseTask = client.GetAsync("GetAll");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Match>>();
                    readTask.Wait();

                    group = readTask.Result;
                }
                else
                {
                    group = Enumerable.Empty<Match>();
                }
            }

            return group.ToList();
        }

        public List<Match> Create()
        {
            IEnumerable<Match> match = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_urlApi);

                var responseTask = client.GetAsync("Create");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Match>>();
                    readTask.Wait();

                    match = readTask.Result;
                }
                else
                {
                    match = Enumerable.Empty<Match>();
                }
            }

            return match.ToList();
        }

    }
}
