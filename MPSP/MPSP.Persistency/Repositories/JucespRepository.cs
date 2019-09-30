using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MPSP.Model.Model;

namespace MPSP.Persistency.Repositories
{
    public class JucespRepository : IJucespRepository
    {
        private readonly IBaseRepository<Jucesp> _baseRepository;
        public JucespRepository(IBaseRepository<Jucesp> repository)
        {
            _baseRepository = repository;
        }
    }
}
