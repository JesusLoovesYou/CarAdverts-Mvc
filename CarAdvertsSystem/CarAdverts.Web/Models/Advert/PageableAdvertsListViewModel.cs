using System.Collections.Generic;

namespace CarAdverts.Web.Models.Advert
{
    public class PageableAdvertsListViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<AdvertViewModel> Adverts { get; set; }
    }
}