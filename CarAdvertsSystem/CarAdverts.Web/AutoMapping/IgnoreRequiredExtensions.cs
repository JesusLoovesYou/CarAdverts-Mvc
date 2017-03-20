using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.Ajax.Utilities;

namespace CarAdverts.Web.AutoMapping
{
    public static class IgnoreRequiredExtensions
    {
        public static IMappingExpression<TSource, TDestination> IgnoreReadOnly<TSource, TDestination>(
               this IMappingExpression<TSource, TDestination> expression)
        {
            var sourceType = typeof(TSource);

            foreach (var property in sourceType.GetProperties())
            {
                PropertyDescriptor descriptor = TypeDescriptor.GetProperties(sourceType)[property.Name];
                RequiredAttribute attribute = (RequiredAttribute)descriptor.Attributes[typeof(RequiredAttribute)];
               
                    expression.ForMember(property.Name, opt => opt.Ignore());
                
            }

            return expression;
        }
    }
}