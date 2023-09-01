using BenhaWebsite.Core.Dtos.AuthenticationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.Core.IRepositories
{
	public interface ICodeforcesRepository
	{
		Task<bool> CheckHandleValidity(string handle);
		Task<string> GetContestStandings(ContestRequestDto request);
	}
}
