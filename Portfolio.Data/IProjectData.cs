using System;
using Portfolio.Core;
namespace Portfolio.Data
{
	public interface IProjectData
	{
		IEnumerable<Project> GetProjectByName(string name);
        Project getById(int Id);
    }

    public class InMemoryProjectData : IProjectData
    {
        List<Project> projects;

        public InMemoryProjectData()
        {
            projects = new List<Project>
            {
                new Project{Id=1, Name="FFARM", Description="Farm Financial Analysis and Risk Assessment System", Status=ProjectStatus.Complete},
                new Project{Id=2, Name="SportsPal", Description="Mobile app to connect Individuals to do sports together", Status=ProjectStatus.Complete},
                new Project{Id=3, Name="Planner", Description="Using knowledge from Project Management, create an efficient planner to order your life", Status=ProjectStatus.New}
            };
        }

        public IEnumerable<Project> GetProjectByName(string? name)
        {

            return from p in projects
                   where string.IsNullOrEmpty(name) || p.Name.ToLower().Contains(name.ToLower())
                   orderby p.Status
                   select p;
        }

        public Project getById(int Id)
        {
            return projects.SingleOrDefault(r => r.Id == Id);
        }
    }
}

