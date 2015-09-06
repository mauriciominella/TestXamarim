﻿using System;
using System.Collections.Generic;

namespace TestXamarim.Repository
{
	public interface IRepository<T> where T: IEntity
	{
		IEnumerable<T> List { get; }
		void Add(T entity);
		void Delete(T entity);
		void Update(T entity);
		T FindById(int Id);
	}
}

