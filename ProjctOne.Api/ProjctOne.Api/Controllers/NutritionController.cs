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
    public class NutritionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public NutritionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            return Ok(_unitOfWork.Nutritions.Find(b => b.NutritionId == id));
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
            return Ok(await _unitOfWork.Nutritions.GetByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Nutritions.GetAll());
        }

        [HttpGet("Find")]
        public IActionResult GetByName(string name)
        {
            return Ok(_unitOfWork.Nutritions.Find(b => b.FoodName == name));
        }

        [HttpGet("FindAll")]
        public IActionResult FindAll(string find)
        {
            return Ok(_unitOfWork.Nutritions.FindAll(b => b.FoodName.Contains(find)));
        }

        [HttpPost("Insert")]
        public IActionResult Insert(dtoNutrition dtoNutrition)
        {
            Nutrition nutrition = new()
            {
                UserId = dtoNutrition.UserId,
                FoodName = dtoNutrition.FoodName,
                Calories = dtoNutrition.Calories,
                Fats = dtoNutrition.Fats,
                Carbohydrates = dtoNutrition.Carbohydrates,
                Proteins = dtoNutrition.Proteins,
            };

            _unitOfWork.Nutritions.Insert(nutrition);
            return Ok(_unitOfWork.Complete());
        }

    }
}
