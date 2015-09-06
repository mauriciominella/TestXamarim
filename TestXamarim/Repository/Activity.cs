using System;

namespace TestXamarim
{
	public class Activity : TestXamarim.Repository.IEntity
	{
		#region IEntity implementation

		public string Id { get; set; }

		#endregion

		public DateTime Date { get; set; }
		public String Description { get; set; }
		public int Type { get; set; }

	}
}

