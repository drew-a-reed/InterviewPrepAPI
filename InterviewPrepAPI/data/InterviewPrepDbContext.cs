using InterviewPrepAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewPrepAPI.data
{
    public class InterviewPrepDbContext: DbContext
	{

		public InterviewPrepDbContext(DbContextOptions options): base(options) { }

		public DbSet<User> Users { get; set; }
	}
}
