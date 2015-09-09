using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestXamarim.Repository
{
	public interface IRepository<T> where T: IEntity
	{
		IList<T> GetAll ();
		Task<IList<T>> GetAllAsync ();
	    void Add(T entity);
		Task AddAsync (T entity);
		void Delete(T entity);
		Task DeleteAsync(T entity);
		void Update(T entity);
		Task UpdateAsync (T entity);
		T FindById(int Id);
	}
}

