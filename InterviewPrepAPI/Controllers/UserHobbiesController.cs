using InterviewPrepAPI.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InterviewPrepAPI.Controllers
{
	public class UserHobbiesController : Controller
	{
		private readonly InterviewPrepDbContext _interviewPrepContext;

		public UserHobbiesController(InterviewPrepDbContext interviewPrepContext)
		{
			_interviewPrepContext = interviewPrepContext;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllUserHobbies()
		{
			var userHobbies = await _interviewPrepContext.Users.ToListAsync();
			return Ok(userHobbies);
		}
	}
}
