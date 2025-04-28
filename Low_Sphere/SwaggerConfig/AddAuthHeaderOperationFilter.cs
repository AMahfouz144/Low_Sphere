using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Common.Swagger
{
    public class AddAuthHeaderOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            foreach (var param in context.ApiDescription.ParameterDescriptions)
            {
                if(param.ModelMetadata != null)
                {
                    var hasAttribute = ((DefaultModelMetadata)param.ModelMetadata).Attributes?.PropertyAttributes?.Any(x => x is IgnoreDataMemberAttribute);
                    if (hasAttribute == true)
                    {
                        var parameterToHide = operation.Parameters.SingleOrDefault(p => p.Name == param.Name);
                        if (parameterToHide != null)
                        {
                            operation.Parameters.Remove(parameterToHide);
                        }
                    }
                }
            }

            // Policy names map to scopes
            var requiredScopes = context.MethodInfo
                .GetCustomAttributes(true)
                .OfType<AuthorizeAttribute>()
                .Select(attr => attr.Policy)
                .Distinct();

            if (requiredScopes.Any())
            {
                var unauthorized = new SwaggerResponseDescription
                {
                    Code = 401,
                    Name = "Unauthorized",
                    Examples = new List<string>
                    {
                        "the reason is one of those (token not valid, token expired, user was logged out, user inactive)",
                    }
                };
                operation.Responses.Add(unauthorized.GetCode, new OpenApiResponse { Description = unauthorized.GetDescription() });

                var needtorefresh = new SwaggerResponseDescription
                {
                    Code = 451,
                    Name = "NeedtoRefresh",
                    Examples = new List<string>
                    {
                        "the reason is (token expired)",
                    }
                };
                operation.Responses.Add(needtorefresh.GetCode, new OpenApiResponse { Description = needtorefresh.GetDescription() });

                var oAuthScheme = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                };

                operation.Security = new List<OpenApiSecurityRequirement>
                    {
                        new OpenApiSecurityRequirement
                        {
                            [ oAuthScheme ] = requiredScopes.ToList()
                        }
                    };
            }

            Res.ResponseDescriptions().ForEach(a =>
            {
                operation.Responses.Add(a.GetCode, new OpenApiResponse { Description = a.GetDescription() });
            });
        }
    }

    public class SwaggerResponseDescription
    {
        public int Code { set; get; }
        public string? Name { set; private get; }
        public List<string> Examples { set; private get; } = new List<string>();

        public string GetDescription()
        {
            var res = $"<strong>{Name}</strong>";
            Examples.ForEach(example => res += $"<br/>- {example}");
            return res;
        }

        public string GetCode => $"{Code}";
    }

    public static class Res
    {
        public static List<SwaggerResponseDescription> ResponseDescriptions() => new List<SwaggerResponseDescription>()
        {
            new SwaggerResponseDescription
            {
                Code = 404,
                Name = "Not Found",
            },

            new SwaggerResponseDescription
            {
                Code = 500,
                Name = "Internal Server Error",
                Examples = new List<string>
                {
                    "{\r\n  \"Result\": [\r\n    \"Internal Server Error.\"]\r\n}"
                }
            },

            new SwaggerResponseDescription
            {
                Code = 405,
                Name = "Validation Exception",
                Examples = new List<string>
                {
                    "{\r\n  \"Result\": [\r\n    \"The X field is required.\",\r\n    \"Sorry, x-field should be at least 8 characters\"\r\n  ]\r\n}"
                }
            },

            new SwaggerResponseDescription
            {
                Code = 406,
                Name = "Business Exception",
                Examples = new List<string>
                {
                    "{\r\n  \"Result\": [\r\n    \"Incorrect credentials.\"]\r\n}"
                }
            }
        };
    }
}
