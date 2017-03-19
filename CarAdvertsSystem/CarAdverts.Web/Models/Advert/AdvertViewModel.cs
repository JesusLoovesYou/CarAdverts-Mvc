using CarAdverts.Web.AutoMapping;

namespace CarAdverts.Web.Models.Advert
{
    public class AdvertViewModel : IMapFrom<CarAdverts.Models.Advert>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url => $"/adverts/{this.Id}/{this.Title.ToLower().Replace(" ", "-")}";
    }
}