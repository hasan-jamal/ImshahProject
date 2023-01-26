using ImshahProject.Web.DataAccess.IRepository;
using ImshahProject.Web.Models;

namespace ImshahProject.Web.DataAccess.IRepository
{
    public interface IInformationRepository : IRepository<Information>
    {
        void Update(Information information);
    }
}
