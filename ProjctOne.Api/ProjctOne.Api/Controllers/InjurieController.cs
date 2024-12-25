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
    public class InjurieController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public InjurieController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {

            return Ok(_unitOfWork.Injuries.Find(b => b.InjurieId == id));
        }


        [Authorize]
        [HttpGet("GetName")]
        public IActionResult GetName()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var name = User.Identity.Name;
            return Ok(id + " " + name);
        }



        [HttpGet("Async")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _unitOfWork.Injuries.GetByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Injuries.GetAll());
        }

        [HttpGet("Find")]
        public IActionResult GetByName(string name) 
        {
            return Ok(_unitOfWork.Injuries.Find(b => b.InjurieName == name));
        }

        [HttpGet("FindAll")]
        public IActionResult GetAllWithAuthors(string find)
        {
            return Ok(_unitOfWork.Injuries.FindAll(b => b.InjurieName.Contains(find)));
        }

        [HttpPost("Insert")]
        public IActionResult Insert(dtoInjurie dtoInjurie)
        {
            Injurie injurie = new()
            {
                ProfileId = dtoInjurie.ProfileId,
                InjurieName = dtoInjurie.InjurieName,
                InjurieType = dtoInjurie.InjurieType,
                IInjurieDescription = dtoInjurie.IInjurieDescription,
                InjurieDate = dtoInjurie.InjurieDate,
                HealingDate = dtoInjurie.HealingDate
                
            };

            _unitOfWork.Injuries.Insert(injurie);
            return Ok(_unitOfWork.Complete());
        }
    }
}
