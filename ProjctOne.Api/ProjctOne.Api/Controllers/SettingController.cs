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
    public class SettingController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public SettingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            return Ok(_unitOfWork.Settings.Find(b => b.SettingId == id));
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
            return Ok(await _unitOfWork.Settings.GetByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Settings.GetAll());
        }

        [HttpPost("Insert")]
        public IActionResult Insert(dtoSetting dtoSetting)
        {
            Setting setting = new()
            {
                ProfileId = dtoSetting.ProfileId,
                Language = dtoSetting.Language,
                Theme = dtoSetting.Theme

            };

            _unitOfWork.Settings.Insert(setting);
            return Ok(_unitOfWork.Complete());
        }
    }
}
