using System;
    using System.Threading.Tasks;

namespace infrastructure
{
    using domain;
    public class AccountServices : IAccountServices
    {
        public async Task<IAccountServices> CreateUser()
        {
            return this;
        }
        public IAccountServices GetUser()
        {
            return this;
        }
    }
}
