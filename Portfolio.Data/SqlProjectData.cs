using Microsoft.EntityFrameworkCore;
using Portfolio.Core;
using System.Linq;

namespace Portfolio.Data
{
    public class SqlProjectData : IProjectData
    {
        private readonly PortfolioDbContext db;

        public SqlProjectData(PortfolioDbContext db)
        {
            this.db = db;
        }

        public Project Add(Project newProject)
        {
            db.Add(newProject);
            return newProject;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Project Delete(int Id)
        {
            var project = getById(Id);

            if(project != null)
            {
                db.Projects.Remove(project);
            }
            return project;
        }

        public Project getById(int Id)
        {
            return db.Projects.Find(Id);
        }

        public IEnumerable<Project> GetProjectByName(string name)
        {
            var query = from p in db.Projects
                        where p.Name.ToLower().StartsWith(name.ToLower()) || string.IsNullOrEmpty(name)
                        orderby p.Name
                        select p;
            return query;
        }

        public Project Update(Project updatedProject)
        {
            var entity = db.Projects.Attach(updatedProject);
            entity.State = EntityState.Modified;

            return updatedProject;
        }
    }
}

