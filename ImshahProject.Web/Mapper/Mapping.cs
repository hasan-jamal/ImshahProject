using AutoMapper;
using ImshahProject.Web.Models;
using ImshahProject.Web.ViewModels;

namespace ImshahProject.Web.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
     

            #region ApplicationUsers
            CreateMap<RegisterCustomerVM, ApplicationUser>()
                .ForMember(x=>x.Email, a=> a.MapFrom(e=> e.EmailAddress))
                .ForMember(x => x.UserName, a => a.MapFrom(e => e.EmailAddress))
                .ReverseMap();
            #endregion

            #region Contact
            CreateMap<ContactsVM, Contact>().ReverseMap();
            #endregion


        }
    }
}
