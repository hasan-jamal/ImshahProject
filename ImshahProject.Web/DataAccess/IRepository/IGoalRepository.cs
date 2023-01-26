using ImshahProject.Web.DataAccess.IRepository;
using ImshahProject.Web.Models;

namespace ImshahProject.Web.DataAccess.IRepository
{
    public interface IGoalRepository : IRepository<Goal>
    {
        void Update(Goal goal);
    }
}
