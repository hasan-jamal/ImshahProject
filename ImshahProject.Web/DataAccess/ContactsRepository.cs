using ImshahProject.Web.Data;
using ImshahProject.Web.DataAccess.IRepository;
using ImshahProject.Web.Models;

namespace ImshahProject.Web.DataAccess.Repository
{
    public class ContactsRepository : Repository<Contact> , IContactRepository
    {
        private readonly ImshahProjectContext _db;

        public ContactsRepository(ImshahProjectContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Contact coverType)
        {
            _db.Contacts.Update(coverType);
        }
    }
}
