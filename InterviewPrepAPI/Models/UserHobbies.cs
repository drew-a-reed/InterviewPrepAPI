using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewPrepAPI.Models
{
	public class UserHobbies
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public Guid UserId { get; set; }

		public Guid HobbyId { get; set; }

		[DataType(DataType.Date)]
		public DateTime? LastPlayed { get; set; }

		public bool? IsFavorite { get; set; }

	}
}
