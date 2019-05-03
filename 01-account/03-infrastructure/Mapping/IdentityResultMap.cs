using System.Collections.Generic;
using domain.Models;
using infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace infrastructure.Mapping
{
    public class IdentityResultMap : IIdentityResultMap
    {
        public AccountResult Map(IdentityResult identity) =>
            new AccountResult
                {
                    Succeeded = identity.Succeeded,
                    Errors = Map(identity.Errors)
                };

        public List<ErrorsResult> Map(IEnumerable<IdentityError> errors)
        {
            var result = new List<ErrorsResult>();
            if(errors == null)
                return result;

            foreach (var item in errors)
            {
                result.Add(new ErrorsResult(item.Code, item.Description));
            }

            return result;
        }
    }
}