using BenhaWebsite.Core;
using BenhaWebsite.Core.IRepositories;
using BenhaWebsite.Core.Models;
using BenhaWebsite.EF.Data;
using BenhaWebsite.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.EF
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;
		public IBaseRepository<EmployeeRegisterationCode> EmployeeRegisterationCodes { get; private set; }
		public IBaseRepository<Mentor> Mentors { get; private set; }
		public IBaseRepository<HeadOfCamp> HeadOfCamps { get; private set; }
		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
			EmployeeRegisterationCodes =  new BaseRepository<EmployeeRegisterationCode>(context);
			Mentors =  new BaseRepository<Mentor>(context);
			HeadOfCamps =  new BaseRepository<HeadOfCamp>(context);
		}

		public int Complete()=>_context.SaveChanges();
		public void Dispose()=>_context.Dispose();
	}
}
