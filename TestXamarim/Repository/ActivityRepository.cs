using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TestXamarim.Repository
{
	public class ActivityRepository : RestRespositoryBase<Activity>, IRepository<Activity> 
	{
		#region IRepository implementation

		public void Add (Activity entity)
		{
			base.Post (entity);
		}

		public Task AddAsync(Activity entity){
			return Task.Run (() => Add (entity));
		}

		public void Delete (Activity entity)
		{
			base.Delete (entity.Id);
		}

		public Task DeleteAsync(Activity entity){
			return Task.Run(() => base.Delete(entity.Id));
		}

		public void Update (Activity entity)
		{
			throw new NotImplementedException ();
		}

		public Task UpdateAsync(Activity entity){
			return Task.Run (() => Update (entity));
		}

		public Activity FindById (int Id)
		{
			//base.Get (Id);
			return new Activity ();
		}
			
		public Task<IList<Activity>> GetAllAsync(){
			return Task.Run (() => base.GetAll ());
		}

		#endregion

	}
}

