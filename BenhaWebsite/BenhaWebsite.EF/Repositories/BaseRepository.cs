using BenhaWebsite.Core.IRepositories;
using BenhaWebsite.EF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
		public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> mathc=null)
		{
			if (mathc is not null)
				return await _context.Set<T>().AsNoTracking().Where(mathc).ToListAsync();
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }
		public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> mathc = null, params string[] includes)
		{
			IQueryable<T> queary;
			if (mathc is not null)
				queary = _context.Set<T>().AsNoTracking().Where(mathc);
			else
				queary = _context.Set<T>().AsNoTracking();
            foreach (var include in includes)
                queary = queary.Include(include);
			return queary;
        }
		public async Task<T> GetByIdAsync<t>(t id) => await _context.Set<T>().FindAsync(id);

        public async Task AddAsync(T model) => await _context.Set<T>().AddAsync(model);
		
		public async Task  DeleteAsync(T model)=>  _context.Set<T>().Remove(model);

        public async Task<int> CountAsync(Expression<Func<T, bool>> mathc = null)
		{
			if (mathc is not null)
				return  await _context.Set<T>().AsNoTracking().CountAsync(mathc);
            return await _context.Set<T>().CountAsync();
        }


    }

}
