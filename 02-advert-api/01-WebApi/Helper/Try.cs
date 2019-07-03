using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Helper
{
    public class Try : ControllerBase
    {
        public async Task<ActionResult> toAdd(Action result){
            try
            {
                return Ok(result);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}