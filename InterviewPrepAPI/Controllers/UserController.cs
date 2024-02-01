using InterviewPrepAPI.data;
using InterviewPrepAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InterviewPrepAPI.Controllers
{
	[ApiController]
	[Route("api/users")]
	public class UserController: Controller
	{

		private readonly InterviewPrepDbContext _interviewPrepContext;

		public UserController(InterviewPrepDbContext interviewPrepContext)
		{
			_interviewPrepContext = interviewPrepContext;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllUsers()
		{
			var users = await _interviewPrepContext.Users.ToListAsync();
			return Ok(users);
		}

		[HttpPost]
		public async Task<IActionResult> AddUser([FromBody] User newUser)
		{
			newUser.Id = Guid.NewGuid();

			await _interviewPrepContext.Users.AddAsync(newUser);
			await _interviewPrepContext.SaveChangesAsync();

			return Ok(newUser);
		}

		[HttpGet]
		[Route("{id:Guid}")]
		public async Task<IActionResult> GetUser([FromRoute] Guid id)
		{
			var user = await _interviewPrepContext.Users.FirstOrDefaultAsync(x => x.Id == id);

			if (user == null)
			{
				return NotFound();
			}

			return Ok(user);
		}

		[HttpPut]
		[Route("{id:Guid}")]
		public async Task<IActionResult> UpdateUser([FromRoute] Guid id, User updatedUser)
		{
			var user = await _interviewPrepContext.Users.FindAsync(id);

			if (user == null)
			{
				return NotFound();
			}

			user.Name = updatedUser.Name;
			user.Email = updatedUser.Email;
			user.Phone = updatedUser.Phone;

			await _interviewPrepContext.SaveChangesAsync();

			return Ok(user);
		}

		[HttpDelete]
		[Route("{id:Guid}")]
		public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
		{
			var user = await _interviewPrepContext.Users.FindAsync(id);

			if (user == null)
			{
				return NotFound();
			}

			_interviewPrepContext.Users.Remove(user);

			await _interviewPrepContext.SaveChangesAsync();

			return Ok();
		}

	}
}
