using System.Collections.Generic;
using domain.Models;
using Microsoft.AspNetCore.Identity;
namespace infrastructure.Interfaces
{
    public interface IIdentityResultMap
    {
         AccountResult Map(IdentityResult identity);
         List<ErrorsResult> Map(IEnumerable<IdentityError> errors);
    }
}