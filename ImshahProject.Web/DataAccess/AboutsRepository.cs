using ImshahProject.Web.Data;
using ImshahProject.Web.DataAccess.IRepository;
using ImshahProject.Web.Models;

namespace ImshahProject.Web.DataAccess.Repository
{
    public class AboutsRepository : Repository<About> , IAboutsRepository
    {
        private readonly ImshahProjectContext _db;

        public AboutsRepository(ImshahProjectContext db) : base(db)
        {
            _db = db;
        }

        public void Update(About obj)
        {
            var aboutId = _db.Abouts.FirstOrDefault(u => u.Id == obj.Id);
            if (aboutId != null)
            {
                aboutId.Id = obj.Id;
                aboutId.Text1 = obj.Text1;
                aboutId.Text2 = obj.Text2;
                aboutId.Text3 = obj.Text3;
                aboutId.Text_ar1 = obj.Text_ar1;
                aboutId.Text_ar2 = obj.Text_ar2;
                aboutId.Text_ar3 = obj.Text_ar3;
  
                if (obj.ImageUrl != null)
                {
                    aboutId.ImageUrl = obj.ImageUrl;
                }
                if (obj.ImageUrl2 != null)
                {
                    aboutId.ImageUrl2 = obj.ImageUrl2;
                }
            }
        }
    }
}
