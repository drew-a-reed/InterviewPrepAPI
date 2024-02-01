using InterviewPrepAPI.data;
using InterviewPrepAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InterviewPrepAPI.Controllers
{
	[ApiController]
	[Route("api/hobbies")]
	public class HobbyController : Controller
	{
		private readonly InterviewPrepDbContext _interviewPrepContext;

		public HobbyController(InterviewPrepDbContext interviewPrepContext)
		{
			_interviewPrepContext = interviewPrepContext;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllHobbies()
		{
			var hobbies = await _interviewPrepContext.Hobbies.ToListAsync();
			return Ok(hobbies);
		}

		[HttpPost]
		public async Task<IActionResult> AddHobby([FromBody] Hobby newHobby)
		{
			newHobby.Id = Guid.NewGuid();

			await _interviewPrepContext.Hobbies.AddAsync(newHobby);
			await _interviewPrepContext.SaveChangesAsync();

			return Ok(newHobby);
		}

		[HttpGet]
		[Route("{id:Guid}")]
		public async Task<IActionResult> GetHobby([FromRoute] Guid id)
		{
			var hobby = await _interviewPrepContext.Hobbies.FirstOrDefaultAsync(x => x.Id == id);

			if (hobby == null)
			{
				return NotFound();
			}

			return Ok(hobby);
		}

		[HttpPut]
		[Route("{id:Guid}")]
		public async Task<IActionResult> UpdateHobby([FromRoute] Guid id, Hobby updatedHobby)
		{
			var hobby = await _interviewPrepContext.Hobbies.FindAsync(id);

			if (hobby == null)
			{
				return NotFound();
			}

			hobby.Name = updatedHobby.Name;

			await _interviewPrepContext.SaveChangesAsync();

			return Ok(hobby);
		}

		[HttpDelete]
		[Route("{id:Guid}")]
		public async Task<IActionResult> DeleteHobby([FromRoute] Guid id)
		{
			var hobby = await _interviewPrepContext.Hobbies.FindAsync(id);

			if (hobby == null)
			{
				return NotFound();
			}

			_interviewPrepContext.Hobbies.Remove(hobby);

			await _interviewPrepContext.SaveChangesAsync();

			return Ok();
		}
	}
}
