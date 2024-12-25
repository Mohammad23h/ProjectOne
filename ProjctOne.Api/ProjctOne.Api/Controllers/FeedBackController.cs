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
    public class FeedBackController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public FeedBackController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            return Ok(_unitOfWork.FeedBacks.Find(b => b.FeedBackId == id));
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
            return Ok(await _unitOfWork.FeedBacks.GetByIdAsync(id));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.FeedBacks.GetAll());
        }

        
        [HttpPost("Insert")]
        public IActionResult Insert(dtoFeedBack dtoFeedBack)
        {
            FeedBack feedBack = new()
            {
                UserId = dtoFeedBack.UserId,
                SessionId = dtoFeedBack.SessionId,
                Comment = dtoFeedBack.Comment,
                Rating = dtoFeedBack.Rating
            };

            _unitOfWork.FeedBacks.Insert(feedBack);
            return Ok(_unitOfWork.Complete());
        }
    }
}
