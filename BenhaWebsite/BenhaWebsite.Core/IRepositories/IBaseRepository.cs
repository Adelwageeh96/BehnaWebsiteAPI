using BenhaWebsite.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.Core.IRepositories
{
	public interface IBaseRepository<T> where T : class
	{
		Task<IEnumerable<T>>GetAllAsync(Expression<Func<T, bool>> mathc = null);
		Task<IEnumerable<T>>GetAllAsync(Expression<Func<T, bool>> mathc = null, params string[] includes);
		Task<T> GetByIdAsync<t>(t id);
        Task AddAsync(T model);
		Task DeleteAsync(T model);
		Task<int> CountAsync(Expression<Func<T, bool>> mathc = null);
	}
}
