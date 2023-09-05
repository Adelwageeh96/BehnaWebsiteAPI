using BenhaWebsite.Core;
using BenhaWebsite.Core.Dtos.CampDtos;
using BenhaWebsite.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BenhaWebsite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public CampsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAllCamps")]
        public async Task<IActionResult> GetAllAsync()
        {
           var camps= await _unitOfWork.Camps.GetAllAsync();
           var campDtos = await Task.WhenAll( camps.Select(async camp =>
           {
               string headOfCampName = "";
               if(camp.HeadOfCamp?.UserId is not null)
               {
                   var headOfCamp = await _userManager.FindByIdAsync(camp.HeadOfCamp.UserId);
                   if (headOfCamp is not null)
                       headOfCampName = headOfCamp.UserName;
               }

               return new CampsDto
               {
                   Name=camp.Name,
                   HeadOfCamp=headOfCampName,
                   SheetsNumber=camp.Sheets?.Count()??0,
                   TraineesNumber=camp.Trainees?.Count()??0
               };

           }));
           return Ok(campDtos);
        }



    }
}
