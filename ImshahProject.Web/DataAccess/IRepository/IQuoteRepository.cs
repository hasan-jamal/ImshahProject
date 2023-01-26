using ImshahProject.Web.DataAccess.IRepository;
using ImshahProject.Web.Models;

namespace ImshahProject.Web.DataAccess.IRepository
{
    public interface IQuoteRepository : IRepository<Quote>
    {
        void Update(Quote quote);
    }
}
