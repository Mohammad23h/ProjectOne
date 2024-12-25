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

    public class WorkoutProgramController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public WorkoutProgramController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            return Ok(_unitOfWork.WorkoutPrograms.Find(b => b.ProgramId == id));
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
            return Ok(await _unitOfWork.WorkoutPrograms.GetByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.WorkoutPrograms.GetAll());
        }

        [HttpGet("Find")]
        public IActionResult GetByName(string name)
        {
            return Ok(_unitOfWork.WorkoutPrograms.Find(b => b.ProgramName == name));
        }

        [HttpGet("FindAll")]
        public IActionResult FindAll(string find)
        {
            return Ok(_unitOfWork.WorkoutPrograms.FindAll(b => b.ProgramName.Contains(find)));
        }

        [HttpPost("Insert")]
        public IActionResult InsertProgram(dtoWorkoutProgram program)
        {
            WorkoutProgram program1 = new()
            {
                ProgramName = program.Name,
                ProgramDescription = program.Description,
                DifficultyLevel = program.Level
            };
            
            _unitOfWork.WorkoutPrograms.Insert(program1);
            return Ok(_unitOfWork.Complete());
        }
    }

}
