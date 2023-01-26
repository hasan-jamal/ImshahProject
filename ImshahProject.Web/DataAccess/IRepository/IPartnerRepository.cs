using ImshahProject.Web.DataAccess.IRepository;
using ImshahProject.Web.Models;

namespace ImshahProject.Web.DataAccess.IRepository
{
    public interface IPartnerRepository : IRepository<Partner>
    {
        void Update(Partner partner);
    }
}
