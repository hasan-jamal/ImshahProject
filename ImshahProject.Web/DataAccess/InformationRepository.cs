using ImshahProject.Web.Data;
using ImshahProject.Web.DataAccess.IRepository;
using ImshahProject.Web.Models;

namespace ImshahProject.Web.DataAccess.Repository
{
    public class InformationRepository : Repository<Information> , IInformationRepository
    {
        private readonly ImshahProjectContext _db;

        public InformationRepository(ImshahProjectContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Information information)
        {
            _db.Informations.Update(information);
        }
    }
}
