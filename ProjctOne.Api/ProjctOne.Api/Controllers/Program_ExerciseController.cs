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
    public class Program_ExerciseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public Program_ExerciseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /*
        [HttpGet]
        public IActionResult GetById()
        {

            return Ok(_unitOfWork.Program_Exercises.Find(b => b.Program_ExerciseId == 1));
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
        public async Task<IActionResult> GetByIdAsync()
        {
            return Ok(await _unitOfWork.Program_Exercises.GetByIdAsync(1));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Program_Exercises.GetAll());
        }
        /*
        [HttpGet("Find")]
        public IActionResult GetByName()
        {
            return Ok(_unitOfWork.Program_Exercises.Find(b => b. == "The Stars"));
        }
        
        [HttpGet("GetAllWithAuthors")]
        public IActionResult GetAllWithAuthors()
        {
            return Ok(_unitOfWork.Program_Exercises.FindAll(b => b.ExerciseName.Contains("The")));
        }
        */
        [HttpPost("Insert")]
        public IActionResult InsertProgram(dtoProgramExercise programExercise)
        {
            Program_Exercise programExercise1 = new()
            {
                ExerciseId = programExercise.ExerciseId,
                ProgramId = programExercise.ProgramId
            };

            _unitOfWork.Program_Exercises.Insert(programExercise1);
            return Ok(_unitOfWork.Complete());
        }
        
    }
}
