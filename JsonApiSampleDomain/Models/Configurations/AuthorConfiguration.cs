using JsonApiFramework.ServiceModel.Configuration;
using JsonApiSampleDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonApiSampleDomain.Models.Configurations
{
    public class AuthorConfiguration : ResourceTypeBuilder<Author>
    {
        public AuthorConfiguration()
        {
            // Relationships
            this.ToManyRelationship<Course>("course");

            // Ignore
            //this.Attribute(x => x.Articles).Ignore();
        }

         
    }
}
