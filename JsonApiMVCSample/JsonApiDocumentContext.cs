using System;

using JsonApiFramework;
using JsonApiFramework.Http;
using JsonApiFramework.Server;
using JsonApiFramework.ServiceModel.Configuration;
using JsonApiSampleDomain.Model;

namespace JsonApiMVCSample
{
    public class JsonApiDocumentContext : DocumentContext
    {
        private static readonly UrlBuilderConfiguration UrlBuilderConfiguration = new UrlBuilderConfiguration("https", "localhost:44325");

        protected override void OnConfiguring(IDocumentContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseUrlBuilderConfiguration(UrlBuilderConfiguration);
        }

        protected override void OnServiceModelCreating(IServiceModelBuilder serviceModelBuilder)
        {
            // Home /////////////////////////////////////////////////////////
            var homeDocumentConfiguration = serviceModelBuilder.Resource<HomeDocument>();

            // .. Hypermedia
            homeDocumentConfiguration.Hypermedia()
                                     .SetApiCollectionPathSegment(String.Empty);

            // .. ResourceIdentity
            homeDocumentConfiguration.ResourceIdentity()
                                     .SetApiType("home");

            serviceModelBuilder.HomeResource<HomeDocument>();


            // Author /////////////////////////////////////////////////////////

            var authorConfig = serviceModelBuilder.Resource<Author>();
            // .. Hypermedia
            authorConfig.Hypermedia()
                              .SetApiCollectionPathSegment("author");

            authorConfig.ResourceIdentity(x => x.Id)
                           .SetApiType("author");


            authorConfig.Attribute(x => x.Name)
                          .SetApiPropertyName("name");

            authorConfig.Attribute(x => x.Courses)
                              .SetApiPropertyName("courses");

            authorConfig.ToManyRelationship<Course>(rel: "courses");
        }
    }
}
