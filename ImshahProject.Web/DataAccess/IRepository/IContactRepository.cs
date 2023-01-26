using ImshahProject.Web.DataAccess.IRepository;
using ImshahProject.Web.Models;

namespace ImshahProject.Web.DataAccess.IRepository
{
    public interface IContactRepository :IRepository<Contact>
    {
        void Update(Contact contact);
    }
}
