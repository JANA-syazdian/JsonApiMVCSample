using JsonApiFramework;
using JsonApiFramework.ServiceModel;
using JsonApiMVCSample.Framework;

namespace JsonApiMVCSample.Internal
{
    internal class ApiServiceContext : IApiServiceContext
    {
        // PUBLIC CONSTRUCTORS //////////////////////////////////////////////
        #region Constructors
        public ApiServiceContext(IApiJsonApiFrameworkRegistry apiJsonApiFrameworkRegistry)
        {
            this.ApiServiceModel = apiJsonApiFrameworkRegistry.ApiServiceModel;

            this.ApiDocumentContextOptions = apiJsonApiFrameworkRegistry.ApiDocumentContextOptions;
        }
        #endregion

        // PUBLIC PROPERTIES ////////////////////////////////////////////////
        #region IApiServiceContext Implementation
        public IServiceModel ApiServiceModel { get; }

        public IDocumentContextOptions ApiDocumentContextOptions { get; }
        #endregion
    }
}