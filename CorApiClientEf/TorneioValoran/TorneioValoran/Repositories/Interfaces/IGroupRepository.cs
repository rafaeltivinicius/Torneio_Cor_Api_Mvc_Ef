using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneioValoran.Models;

namespace TorneioValoran.Repositories.Interfaces
{
    public interface IGroupRepository
    {
        List<Group> ListGroup();
        List<Group> Create();
    }
}
