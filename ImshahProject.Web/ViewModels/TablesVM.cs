using ImshahProject.Web.Models;

namespace ImshahProject.Web.ViewModels
{
    public class TablesVM
    {
        public IEnumerable<Slider> Sliders { get; set; } = new List<Slider>();
        public IEnumerable<Service> Services { get; set; } = new List<Service>();
        public IEnumerable<Goal> Goals { get; set; }             = new List<Goal>();
        public IEnumerable<About> About { get; set; }            = new List<About>();
        public IEnumerable<Information> Information { get; set; }= new List<Information>();
        public IEnumerable<Partner> Partner { get; set; } = new List<Partner>();

    }
}
