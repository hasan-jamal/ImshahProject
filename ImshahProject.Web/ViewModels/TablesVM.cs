using ImshahProject.Web.Models;

namespace ImshahProject.Web.ViewModels
{
    public class TablesVM
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<Service> Services { get; set; }
        public IEnumerable<Goal> Goals { get; set; }
        public IEnumerable<About> About { get; set; }
        public IEnumerable<Information> Information { get; set; }
        public IEnumerable<Partner> Partner { get; set; }

    }
}
