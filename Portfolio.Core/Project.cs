using System;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Core
{

    public class Project
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }

		public string GithubRepo { get; set; } = string.Empty;
        public string ProjectImage { get; set; } = string.Empty;
		public DateOnly StartDate { get; set; }
		public DateOnly EndDate { get; set; }

		[Required]
		public ProjectStatus Status { get; set; }
	}
}

