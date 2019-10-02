using MPSP.Model.Search;
using MPSP.Persistency.Context;

namespace MPSP.Persistency.Repositories
{
    public class JucespRepository : IJucespRepository
    {
        private readonly IBaseRepository<Jucesp> _repository;

        public JucespRepository(IBaseRepository<Jucesp> repository)
        {
            _repository = repository;
        }

        public Jucesp Add(Jucesp jucesp)
        {
            return _repository.Add(jucesp);
        }

    }
}
