using BearerTokenGen.Infrastructure.Factories;
using BearerTokenGen.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BearerTokenGen.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TokenApiController : ControllerBase
    {
        private readonly ITokenFactory _tokenFactory;
        public TokenApiController(ITokenFactory tokenFactory) {
            _tokenFactory = tokenFactory ?? throw new ArgumentNullException(nameof(ITokenFactory));
        }

        [HttpPost]
        public async Task<TokenModel> CreateToken(BearerTokenParamsModel bearerTokenParams) {
            var newToken = await Task.Run(() => _tokenFactory.CreateToken(bearerTokenParams));
            return newToken;        
        }
    }
}