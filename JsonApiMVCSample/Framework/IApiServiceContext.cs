using JsonApiFramework;
using JsonApiFramework.ServiceModel;

namespace JsonApiMVCSample.Framework
{
    /// <summary>Scoped HTTP call API service execution context.</summary>
    public interface IApiServiceContext
    {
        // PUBLIC METHODS ///////////////////////////////////////////////////
        #region Methods
        IDocumentContextOptions ApiDocumentContextOptions { get; }

        IServiceModel ApiServiceModel { get; }
        #endregion
    }
}