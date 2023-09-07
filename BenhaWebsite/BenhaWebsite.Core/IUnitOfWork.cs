using BenhaWebsite.Core.IRepositories;
using BenhaWebsite.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.Core
{
	public interface IUnitOfWork : IDisposable
	{
		public IBaseRepository<EmployeeRegisterationCode> EmployeeRegisterationCodes { get; }
		public IBaseRepository<Mentor> Mentors { get; }
		public IBaseRepository<HeadOfCamp> HeadOfCamps { get; }
		public IBaseRepository<Camp> Camps { get; }
		public IBaseRepository<Sheet> Sheets { get; }
		public IBaseRepository<Trainee> Trainees { get; }

		int Complete();
	}
}
