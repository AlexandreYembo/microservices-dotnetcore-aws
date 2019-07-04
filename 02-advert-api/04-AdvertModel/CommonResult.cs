using System.Net;

namespace AdvertModel
{
    public class CommonResult
    {
        public CommonResult(HttpStatusCode statusCode){
            StatusCode = statusCode;
        }

        public CommonResult(HttpStatusCode statusCode, string message){
            StatusCode = statusCode;
            Message = message;
        }
        public HttpStatusCode StatusCode {get; set;}
        public string Message {get; set;}
    }
}