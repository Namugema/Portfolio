using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Data;
using Portfolio.Core;

namespace Portfolio.Pages.Projects
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IProjectData projectData;

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public IEnumerable<Project> Projects { get; set; } = Enumerable.Empty<Project>();

        public ListModel(IConfiguration config, IProjectData projectData)
        {
            this.config = config;
            this.projectData = projectData;
        }

        public void OnGet()
        {
            Projects = projectData.GetProjectByName(SearchTerm);
            
            Message = config["Message"];
            
        }
    }
}
