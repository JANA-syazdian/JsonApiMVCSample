
using JsonApiFramework.Conventions;
using JsonApiFramework.ServiceModel;
using JsonApiFramework.ServiceModel.Configuration;
using JsonApiSampleDomain.Models.Configurations;

namespace JsonApiSampleDomain.Model
{
    public static class ConfigurationFactory
    {
        public static IServiceModel CreateServiceModel()
        {
            var serviceModelBuilder = new ServiceModelBuilder();

            serviceModelBuilder.Configurations.Add(new AuthorConfiguration());


            serviceModelBuilder.HomeResource<HomeDocument>();

            var conventions = CreateConventions();
            var serviceModel = serviceModelBuilder.Create(conventions);
            return serviceModel;
        }

        private static IConventions CreateConventions()
        {
            var conventionsBuilder = new ConventionsBuilder();

            // Use JSON API standard member naming convention for JSON API resource attributes.
            // For example, FirstName in POCO becomes "first-name" as a JSON API attribute.
            conventionsBuilder.ApiAttributeNamingConventions()
                              .AddStandardMemberNamingConvention();

            // Use JSON API standard member naming and plurization conventions of the POCO type
            // name as the JSON API type name.
            // For example, Article POCO type becomes "articles" as the JSON API type.
            conventionsBuilder.ApiTypeNamingConventions()
                              .AddPluralNamingConvention()
                              .AddStandardMemberNamingConvention();

            // Discover all public properties as JSON API resource attributes.
            // For example, FirstName property in POCO becomes an attribute of a JSON API resource.
            conventionsBuilder.ResourceTypeConventions()
                              .AddPropertyDiscoveryConvention();

            var conventions = conventionsBuilder.Create();
            return conventions;
        }
    }
}
