using ImshahProject.Web.Data;
using ImshahProject.Web.DataAccess.IRepository;
using ImshahProject.Web.Models;

namespace ImshahProject.Web.DataAccess.Repository
{
    public class ServicesRepository : Repository<Service> , IServiceRepository
    {
        private readonly ImshahProjectContext _db;

        public ServicesRepository(ImshahProjectContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Service obj)
        {
            var serviceId = _db.Services.FirstOrDefault(u => u.Id == obj.Id);
            if (serviceId != null)
            {
                serviceId.Id = obj.Id;
                serviceId.Name = obj.Name;
                serviceId.Name_ar = obj.Name_ar;

                if (obj.ImageUrl != null)
                {
                    serviceId.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
