using System.Net;

namespace domain.Models
{
    public class ErrorsResult
    {
         public ErrorsResult(string code, string description){
            Code = code;
            Description = description;
        }
        public ErrorsResult(HttpStatusCode statusCode, string description){
            StatusCode = statusCode;
            Description = description;
        }
        //
        // Summary:
        //     Gets or sets the code for this error.
        public string Code { get; set; }

        public HttpStatusCode StatusCode { get; set; }
        //
        // Summary:
        //     Gets or sets the description for this error.
        public string Description { get; set; }
    }
}