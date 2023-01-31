using System;
using Portfolio.Core;
namespace Portfolio.Data
{
    public interface IProjectData
	{
		IEnumerable<Project> GetProjectByName(string name);
        Project getById(int Id);
        Project Update(Project updatedProject);
        Project Add(Project newProject);
        Project Delete(int Id);
        int Commit();
    }
}

