using Gym.BLL.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Gym.BLL_EF.Services
{
    public class CurrnetUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public CurrnetUserService(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }

        public string GetCurrnetUserId()
        {
            var claimsPrincipal = _contextAccessor?.HttpContext?.User as ClaimsPrincipal;
            return claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
