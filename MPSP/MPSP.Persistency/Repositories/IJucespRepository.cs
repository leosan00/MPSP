using MPSP.Model.Search;
using System.Collections.Generic;

namespace MPSP.Persistency.Repositories
{
    public interface IJucespRepository 
    {
        Jucesp Add(Jucesp jucesp);

		IEnumerable<Jucesp> GetAll();
    }
}
