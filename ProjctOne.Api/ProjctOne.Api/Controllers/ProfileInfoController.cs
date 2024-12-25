using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectOne.Core.Interfaces;
using ProjectOne.Core.Models;
using System.Security.Claims;

namespace ProjctOne.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileInfoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public ProfileInfoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            return Ok(_unitOfWork.ProfileInfos.Find(b => b.ProfileId == id));
        }


        [Authorize]
        [HttpGet("GetName")]
        public IActionResult GetName()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var name = User.Identity.Name;
            return Ok(id + " " + name);
        }



        [HttpGet("Async/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _unitOfWork.ProfileInfos.GetByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.ProfileInfos.GetAll());
        }

        [HttpGet("FindByUserName")]
        public IActionResult GetByUserName(string username)
        {
            return Ok(_unitOfWork.ProfileInfos.Find(b => b.User.UserName == username));
        }

        
        [HttpPost("Insert")]
        public IActionResult Insert(dtoProfileInfo dtoProfileInfo)
        {
            ProfileInfo profileInfo = new()
            {
                UserId = dtoProfileInfo.UserId,
                Gender = dtoProfileInfo.Gender,
                BirthDay = dtoProfileInfo.BirthDay,
                Height = dtoProfileInfo.Height,
                Weight = dtoProfileInfo.Weight,
                FitnessLevel = dtoProfileInfo.FitnessLevel,
                FitnessGoal = dtoProfileInfo.FitnessGoal
            };

            _unitOfWork.ProfileInfos.Insert(profileInfo);
            return Ok(_unitOfWork.Complete());
        }
    }
}
