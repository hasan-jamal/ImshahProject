using ImshahProject.Web.Data;
using ImshahProject.Web.DataAccess.IRepository;
using ImshahProject.Web.Models;

namespace ImshahProject.Web.DataAccess.Repository
{
    public class GoalsRepository : Repository<Goal> , IGoalRepository
    {
        private readonly ImshahProjectContext _db;

        public GoalsRepository(ImshahProjectContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Goal obj)
        {
            var goalId = _db.Goals.FirstOrDefault(u => u.Id == obj.Id);
            if (goalId != null)
            {
                goalId.Id = obj.Id;
                goalId.Name = obj.Name;
                goalId.Name_ar = obj.Name_ar;
                goalId.Text = obj.Text;
                goalId.Text_ar = obj.Text_ar;

                if (obj.ImageUrl != null)
                {
                    goalId.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
