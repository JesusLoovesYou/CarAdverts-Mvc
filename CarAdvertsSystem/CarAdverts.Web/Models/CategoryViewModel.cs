using AutoMapper;
using CarAdverts.Models;
using CarAdverts.Web.AutoMapping;

namespace CarAdverts.Web.Models
{
    public class CategoryViewModel : IMapFrom<Category>  //, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // da pitam Viktor kak da premahna required attributa

        //public void CreateMappings(IMapperConfigurationExpression configuration)
        //{
        //    configuration.CreateMap<Category, CategoryViewModel>()
        //        .ForSourceMember(src => src.Id, opt => opt.Ignore())
        //        .ForSourceMember(src => src.Name, opt => opt.Ignore());
        //}
    }
}