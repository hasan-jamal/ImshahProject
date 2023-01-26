namespace ImshahProject.Web.DataAccess.IRepository
{
    public interface IUnitOfWork
    {
        IContactRepository contacts { get; }
        IGoalRepository goals { get; }
        ISliderRepository sliders { get; }
        IServiceRepository services { get; }
        IAboutsRepository abouts { get; }
        IInformationRepository informations { get; }
        IPartnerRepository partners { get; }
        IQuoteRepository quotes { get; }


        void Save();
    }
}
