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
    public class ExerciseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public ExerciseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            return Ok(_unitOfWork.Exercises.Find(b => b.ExerciseId == id));
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
            return Ok(await _unitOfWork.Exercises.GetByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Exercises.GetAll());
        }

        [HttpGet("Find")]
        public IActionResult GetByName(string name)
        {
            return Ok(_unitOfWork.Exercises.Find(b => b.ExerciseName == name));
        }

        [HttpGet("FindAll")]
        public IActionResult FindAll(string find)
        {
            return Ok(_unitOfWork.Exercises.FindAll(b => b.ExerciseName.Contains(find)));
        }
        
        [HttpPost("Insert")]
        public IActionResult InsertProgram(dtoExercise exercise)
        {
            Exercise exercise1 = new()
            {
                ExerciseName = exercise.Name,
                Description = exercise.Description,
                NutritionValue = exercise.NutritionValue,
                CaloreiBurn = exercise.CaloreiBurn,
                ImageURL = exercise.ImageURL
            };

            _unitOfWork.Exercises.Insert(exercise1);
            return Ok(_unitOfWork.Complete());
        }
        
    }
}
