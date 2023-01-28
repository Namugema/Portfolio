using System;
namespace Portfolio.Core
{

    public class Project
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string GithubRepo { get; set; } = string.Empty;
        public string projectImage { get; set; } = string.Empty;
        public DateOnly startDate { get; set; }
		public DateOnly endDate { get; set; }
		public ProjectStatus Status { get; set; }
	}
}

