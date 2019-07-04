using System.Net;

namespace AdvertModel.Confirm
{
    public class ConfirmAdvertModelResult
    {
        public ConfirmAdvertModelResult(){

        }

        public ConfirmAdvertModelResult(HttpStatusCode statusCode){
            if(Result == null)
                Result = new CommonResult(statusCode);
        }

        public ConfirmAdvertModelResult(HttpStatusCode statusCode, string message){
            if(Result == null)
                Result = new CommonResult(statusCode, message);
        }
        public string Id {get; set;}
        public CommonResult Result {get; set;}
    }
}