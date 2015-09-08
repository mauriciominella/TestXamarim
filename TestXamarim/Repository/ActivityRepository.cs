using System;

namespace TestXamarim.Repository
{
	public class ActivityRepository : RestRespositoryBase<Activity>, IRepository<Activity> 
	{
		#region IRepository implementation

		public void Add (Activity entity)
		{
			base.Post (entity);
		}

		public void Delete (Activity entity)
		{
			base.Delete (entity.Id);
		}

		public void Update (Activity entity)
		{
			throw new NotImplementedException ();
		}

		public Activity FindById (int Id)
		{
			//base.Get (Id);
			return new Activity ();
		}

		public System.Collections.Generic.IEnumerable<Activity> List {
			get {
				return base.GetAll ();
			}
		}

		#endregion

		public ActivityRepository ()
		{
		}
	}
}

