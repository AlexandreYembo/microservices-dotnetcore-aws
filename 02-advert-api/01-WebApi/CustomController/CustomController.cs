using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class CustomController : ControllerBase
    {
        public async Task<ActionResult> GetReponse<T>(Func<Task<T>> result){
            try
            {
                await result.Invoke();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}