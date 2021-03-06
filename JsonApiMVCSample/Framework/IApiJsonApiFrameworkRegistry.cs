using JsonApiFramework;
using JsonApiFramework.ServiceModel;

namespace JsonApiMVCSample.Framework
{
    /// <summary>Singleton registry of all well-known location for JsonApiFramework components.</summary>
    public interface IApiJsonApiFrameworkRegistry
    {
        // PUBLIC METHODS ///////////////////////////////////////////////////
        #region Methods
        IDocumentContextOptions ApiDocumentContextOptions { get; }

        IServiceModel ApiServiceModel { get; }
        #endregion
    }
}