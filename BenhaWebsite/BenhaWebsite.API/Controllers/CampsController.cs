using AutoMapper;
using BenhaWebsite.Core;
using BenhaWebsite.Core.Dtos.CampDtos;
using BenhaWebsite.Core.Models;
using BenhaWebsite.EF;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BenhaWebsite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CampsController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet("GetAllCamps")]
        public async Task<IActionResult> GetAllAsync()
        {

            var camps = await _unitOfWork.Camps.GetAllAsync(null,"HeadOfCamp", "Sheets", "Trainees");
            var headOfCampIds = camps
                .Where(camp => camp.HeadOfCamp?.UserId is not null)
                .Select(camp => camp.HeadOfCamp.UserId)
                .ToList();

            var headOfCampInfo = await _userManager.Users
                .Where(user => headOfCampIds.Contains(user.Id))
                .ToDictionaryAsync(user => user.Id, user => user.UserName);


           var campDtos = await Task.WhenAll(  camps.Select(async camp =>
           {
               string headOfCampName = "";
               if( camp.HeadOfCamp?.UserId is not null)
               {
                   if (headOfCampInfo.TryGetValue(camp.HeadOfCamp.UserId, out var userName))
                       headOfCampName = userName;
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

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var camp = await _unitOfWork.Camps.GetByIdAsync(id);
            if (camp is not null)
            {
                HeadOfCamp headOfCamp = await _unitOfWork.HeadOfCamps.GetByIdAsync(camp.HeadOfCampId);
                int SheetsNumber = await _unitOfWork.Sheets.CountAsync(t=>t.CampId== id);
                int TrainnesNumber=await _unitOfWork.Trainees.CountAsync(t=>t.CampId== id);
                return Ok(new CampDetailsDto
                {
                    Name = camp.Name,
                    CreateTime=camp.CreateTime,
                    Description=camp.Description,
                    DurationInWeeks=camp.DurationInWeeks,
                    HeadOfCamp= _userManager.FindByIdAsync(headOfCamp.UserId).Result.UserName,
                    SheetsNumber= SheetsNumber,
                    TraineesNumber=TrainnesNumber,
                });
            }
            return NotFound();

        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(CampAddEditDto dto)
        {
            await _unitOfWork.Camps.AddAsync(_mapper.Map<Camp>(dto));
            _unitOfWork.Complete();
            return Ok(dto);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(int id , CampAddEditDto dto)
        {
            Camp? camp= await _unitOfWork.Camps.GetByIdAsync(id);
            if(camp is not null)
            {
                camp.DurationInWeeks = dto.DurationInWeeks;
                camp.Name = dto.Name;
                camp.HeadOfCampId = dto.HeadOfCampId;
                camp.Description = dto.Description;
                _unitOfWork.Complete();
                return Ok(_mapper.Map<CampAddEditDto>(camp));
            }
            return NotFound();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            Camp? camp = await _unitOfWork.Camps.GetByIdAsync(id);
            if (camp is not null)
            {
                await _unitOfWork.Camps.DeleteAsync(camp);
                _unitOfWork.Complete();
                return Ok(_mapper.Map<CampAddEditDto>(camp));
            }
            return NotFound();
        }



    }
}
