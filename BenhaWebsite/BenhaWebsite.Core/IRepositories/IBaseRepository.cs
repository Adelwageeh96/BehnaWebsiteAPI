using BenhaWebsite.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.Core.IRepositories
{
	public interface IBaseRepository<T> where T : class
	{
		Task<T> GetByIdAsync<t>(t id);
		void Add(T model);
		void Delete(T model);
	}
}
