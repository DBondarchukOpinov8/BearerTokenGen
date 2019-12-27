using BearerTokenGen.Models;

namespace BearerTokenGen.Infrastructure.Factories {
    public interface ITokenFactory {
        TokenModel CreateToken(BearerTokenParamsModel bearerTokenParams);
    }
}