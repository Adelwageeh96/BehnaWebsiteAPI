using BenhaWebsite.Core.IRepositories;
using BenhaWebsite.EF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.EF.Repositories
{
	public class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		private readonly ApplicationDbContext _context;

		public BaseRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();
		public async Task<T> GetByIdAsync<t>(t id) => await _context.Set<T>().FindAsync(id);
		public async Task Add(T model) => await _context.Set<T>().AddAsync(model);
		
		public void  Delete(T model)=>  _context.Set<T>().Remove(model);
	}

}
