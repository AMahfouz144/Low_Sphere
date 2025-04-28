using Common.Common;
using Common.Exceptions;
using Common.Logger;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Common
{
    public class CustomErrorHandling
    {
        private readonly RequestDelegate next;

        public CustomErrorHandling(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            List<string> messages = new List<string>();
            context.Response.ContentType = "application/json";
            ExceptionType type = ExceptionType.General;

            if (ex is IdentitySpaceException)
            {
                var customException = ex as IdentitySpaceException;

                context.Response.StatusCode = customException.HttpStatusCode;
                if (customException is AuthException && (customException as AuthException).AuthExceptionType == AuthExceptionType.NotAvailable)
                    context.Response.StatusCode = 401;

                if (customException is ValidationsException)
                {
                    var invalidData = (customException as ValidationsException).InvalidFields;
                    if (invalidData != null)
                        messages = invalidData;
                    else
                        messages = new List<string>() { customException.ClientMessage };
                }
                else
                    messages = new List<string>() { customException.ClientMessage };

                type = customException.Type;
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                messages = new List<string>() { $"Internal Server Error.", ex.Message };
            }

            var logger = context.RequestServices.GetService(typeof(IVLogger)) as IVLogger;

            string description = GetRequestDescription(context);

            logger.Error(ex.Message, messages.FirstOrDefault(), ex.StackTrace, description, (int)type);
            var result = JsonSerializer.Serialize(new ServerResponse<List<string>> { Result = messages });
            return context.Response.WriteAsync(result);
        }

        private string GetRequestDescription(HttpContext context)
        {
            var request = context.Request;
            string api = context.Request.Path;
            string bodyAsText = null;
            string userId = context.User?.Claims?.FirstOrDefault(obj => obj.Type == "UserId")?.Value;
            string token = context.Request.Headers["Authorization"];


            using (var reader = new StreamReader(request.Body, true))
            {
                var tsk = reader.ReadToEndAsync();
                while (!tsk.IsCompleted) { };
                bodyAsText = tsk.Result;
            }

            StringBuilder builder = new StringBuilder($"API: {api}\n");

            if (!string.IsNullOrWhiteSpace(userId))
                builder.AppendLine($"UserId: {userId}");

            if (!string.IsNullOrWhiteSpace(token))
                builder.AppendLine($"Token: {token}");

            if (!string.IsNullOrWhiteSpace(bodyAsText))
                builder.AppendLine($"Body: {bodyAsText}");

            return builder.ToString(); ;
        }
    }
}