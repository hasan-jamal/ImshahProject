using ImshahProject.Web.DataAccess.IRepository;
using ImshahProject.Web.Models;

namespace ImshahProject.Web.DataAccess.IRepository
{
    public interface IAboutsRepository : IRepository<About>
    {
        void Update(About about);
    }
}
