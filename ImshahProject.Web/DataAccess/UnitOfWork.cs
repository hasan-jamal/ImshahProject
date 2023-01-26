using ImshahProject.Web.Data;
using ImshahProject.Web.DataAccess.IRepository;
using ImshahProject.Web.DataAccess.Repository;

namespace ImshahProject.Web.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ImshahProjectContext _db;
        public UnitOfWork(ImshahProjectContext db)
        {
            _db = db;
            contacts = new ContactsRepository(_db);
            goals = new GoalsRepository(_db);
            services = new ServicesRepository(_db);
            sliders = new SlidersRepository(_db);
            abouts = new AboutsRepository(_db);
            informations = new InformationRepository(_db);
            partners = new PartnersRepository(_db);
            quotes = new QuotesRepository(_db);


        }
        public IContactRepository contacts { get; private set; }
        public IGoalRepository goals { get; private set; }
        public IServiceRepository services { get; private set; }
        public ISliderRepository sliders { get; private set; }
        public IAboutsRepository abouts { get; private set; }
        public IInformationRepository informations { get; private set; }
        public IPartnerRepository partners { get; private set; }
        public IQuoteRepository quotes { get; private set; }



        public void Save()
        {
          _db.SaveChanges();
        }
    }
}
