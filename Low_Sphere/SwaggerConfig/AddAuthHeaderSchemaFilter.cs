using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Common.Swagger
{
    public class AddAuthHeaderSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema?.Properties == null)
            {
                return;
            }

            //var ignoreDataMemberProperties = context.Type.GetProperties()
            //    .Where(t => t.GetCustomAttribute<IgnoreDataMemberAttribute>() != null);

            var ignoreDataMemberProperties = context.Type.GetProperties()
               .Where(t => t.GetCustomAttribute<JsonIgnoreAttribute>() != null);
            
            foreach (var ignoreDataMemberProperty in ignoreDataMemberProperties)
            {
                var propertyToHide = schema.Properties.Keys
                    .SingleOrDefault(x => x.ToLower() == ignoreDataMemberProperty.Name.ToLower());

                if (propertyToHide != null)
                {
                    schema.Properties.Remove(propertyToHide);
                }
            }
        }
    }
}