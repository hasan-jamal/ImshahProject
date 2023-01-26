using ImshahProject.Web.Data;
using ImshahProject.Web.DataAccess.IRepository;
using ImshahProject.Web.Models;

namespace ImshahProject.Web.DataAccess.Repository
{
    public class SlidersRepository : Repository<Slider> , ISliderRepository
    {
        private readonly ImshahProjectContext _db;

        public SlidersRepository(ImshahProjectContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Slider obj)
        {
            var sliderId = _db.Sliders.FirstOrDefault(u => u.Id == obj.Id);
            if (sliderId != null)
            {
                sliderId.Id = obj.Id;
                sliderId.Name = obj.Name;
                sliderId.Name_ar = obj.Name_ar;
                sliderId.Text = obj.Text;
                sliderId.Text_ar = obj.Text_ar;

                if (obj.ImageUrl != null)
                {
                    sliderId.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
