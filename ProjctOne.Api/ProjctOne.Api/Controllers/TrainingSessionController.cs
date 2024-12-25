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
    public class TrainingSessionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public TrainingSessionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            return Ok(_unitOfWork.TrainingSessions.Find(b => b.SessionId == id));
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
            return Ok(await _unitOfWork.TrainingSessions.GetByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.TrainingSessions.GetAll());
        }
        /*
        [HttpGet("Find")]
        public IActionResult GetByName()
        {
            return Ok(_unitOfWork.TrainingSessions.Find(b => b. == "The Stars"));
        }
        */

        /*HttpGet("GetAllWithAuthors")]
        public IActionResult GetAllWithAuthors()
        {
            return Ok(_unitOfWork.WorkoutPrograms.FindAll(b => b.ProgramName.Contains("The")));
        }
        */
        [HttpPost("Insert")]
        public IActionResult InsertProgram(dtoTrainingSession session)
        {
            TrainingSession session1 = new()
            {
                UserId = session.UserId,
                ProgramId = session.ProgramId,
                StartTime = session.StartTime,
                EndTime = session.EndTime,
                Status = session.Status
            };

            _unitOfWork.TrainingSessions.Insert(session1);
            return Ok(_unitOfWork.Complete());
        }
    }
}
