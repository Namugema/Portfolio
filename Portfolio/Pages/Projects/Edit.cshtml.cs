using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Data;
using Portfolio.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Portfolio.Pages.Projects
{
	public class EditModel : PageModel
    {
        private readonly IProjectData projectData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Project project { get; set; }

        public IEnumerable<SelectListItem> Statuses { get; set; }

        public EditModel(IProjectData projectData, IHtmlHelper htmlHelper)
        {
            this.projectData = projectData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? projectID)
        {
            Statuses = htmlHelper.GetEnumSelectList<ProjectStatus>();

            if (projectID.HasValue)
            {
                project = projectData.getById(projectID.Value);
            }
            else
            {
                project = new Project();
            }
            

            if(project == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            Statuses = htmlHelper.GetEnumSelectList<ProjectStatus>();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(project.Id > 0)
            {
                projectData.Update(project);
            }
            else
            {
                projectData.Add(project);
            }
            projectData.Commit();

            TempData["Message"] = "Project saved!";
            return RedirectToPage("./Detail", new { projectId = project.Id });
        }
    }
}
