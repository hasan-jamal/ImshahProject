using ImshahProject.Web.Data;
using ImshahProject.Web.DataAccess.IRepository;
using ImshahProject.Web.Models;

namespace ImshahProject.Web.DataAccess.Repository
{
    public class QuotesRepository : Repository<Quote> , IQuoteRepository
    {
        private readonly ImshahProjectContext _db;

        public QuotesRepository(ImshahProjectContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Quote quote)
        {
            _db.Quotes.Update(quote);
        }
    }
}
