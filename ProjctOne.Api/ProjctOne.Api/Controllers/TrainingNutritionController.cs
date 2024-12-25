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
    public class TrainingNutritionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public TrainingNutritionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            return Ok(_unitOfWork.TrainingNutritions.Find(b => b.TrainingNutritionId == id));
        }


        

        [HttpGet("Async/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _unitOfWork.Nutritions.GetByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Nutritions.GetAll());
        }

        
        [HttpPost("Insert")]
        public IActionResult Insert(dtoTrainingNutrition dtoTrainingNutrition)
        {
            TrainingNutrition trainingNutrition = new()
            {
                NutritionId = dtoTrainingNutrition.NutritionId,
                SessionId = dtoTrainingNutrition.SessionId
            };

            _unitOfWork.TrainingNutritions.Insert(trainingNutrition);
            return Ok(_unitOfWork.Complete());
        }
    }
}
