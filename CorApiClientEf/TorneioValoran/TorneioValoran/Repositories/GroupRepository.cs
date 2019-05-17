using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using TorneioValoran.Models;
using TorneioValoran.Repositories.Interfaces;

namespace TorneioValoran.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly string _urlApi = "https://localhost:5001/api/group/";

        public List<Group> ListGroup()
        {
            IEnumerable<Group> group = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_urlApi);

                var responseTask = client.GetAsync("GetAll");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Group>>();
                    readTask.Wait();

                    group = readTask.Result;
                }
                else
                {
                    group = Enumerable.Empty<Group>();
                }
            }

            return group.ToList();
        }

        public List<Group> ListGroupFase()
        {
            IEnumerable<Group> group = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_urlApi);

                var responseTask = client.GetAsync("GetbyPhase");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Group>>();
                    readTask.Wait();

                    group = readTask.Result;
                }
                else
                {
                    group = Enumerable.Empty<Group>();
                }
            }

            return group.ToList();
        }

        public List<Group> Create()
        {
            IEnumerable<Group> group = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_urlApi);

                var responseTask = client.GetAsync("Create");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Group>>();
                    readTask.Wait();

                    group = readTask.Result;
                }
                else
                {
                    group = Enumerable.Empty<Group>();
                }
            }

            return group.ToList();
        }

    }
}
