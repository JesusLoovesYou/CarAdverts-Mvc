using AutoMapper;

namespace CarAdverts.Web.AutoMapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
