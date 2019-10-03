using System;
using System.Collections.Generic;
using System.Text;
using MPSP.Model.Search;

namespace MPSP.Persistency.Repositories
{
	public class SielRepository : ISielRepository
	{
		private readonly IBaseRepository<Siel> _repository;

		public SielRepository(IBaseRepository<Siel> repository)
		{
			_repository = repository;
		}
		public Siel Add(Siel siel)
		{
			return _repository.Add(siel);
		}
	}
}
