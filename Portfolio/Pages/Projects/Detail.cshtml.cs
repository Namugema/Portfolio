using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Core;
using Portfolio.Data;

namespace Portfolio.Pages.Projects
{
	public class DetailModel : PageModel
    {
        private readonly IProjectData projectData;

        public Project Project { get; set; } = new Project();

        public DetailModel(IProjectData projectData)
        {
            this.projectData = projectData;
        }

        public IActionResult OnGet(int projectId)
        {
            Project = projectData.getById(projectId);

            if(Project == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
            
        }
    }
}
