using ImshahProject.Web.Data;
using ImshahProject.Web.DataAccess.IRepository;
using ImshahProject.Web.Models;

namespace ImshahProject.Web.DataAccess.Repository
{
    public class PartnersRepository : Repository<Partner> , IPartnerRepository
    {
        private readonly ImshahProjectContext _db;

        public PartnersRepository(ImshahProjectContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Partner obj)
        {
            var partnerId = _db.Partners.FirstOrDefault(u => u.Id == obj.Id);
            if (partnerId != null)
            {
                partnerId.Id = obj.Id;
                partnerId.Name = obj.Name;

                if (obj.ImageUrl != null)
                {
                    partnerId.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
