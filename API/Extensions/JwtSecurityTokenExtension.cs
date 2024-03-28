using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using API.Data;

namespace API.Extensions
{
  public static class JwtSecurityTokenExtension
  {
    public static TokenClaims DecodeToken(this ClaimsPrincipal principal)
    {
      var email = principal?.FindFirstValue(ClaimTypes.Email);
      var userId = principal?.FindFirstValue(ClaimTypes.NameIdentifier);
      var name = principal?.FindFirstValue(ClaimTypes.Name);
      var roles = principal?.FindAll(ClaimTypes.Role).Select(c => c.Value).ToArray();
      var phoneNumber = principal?.FindFirstValue(ClaimTypes.MobilePhone);

      return new TokenClaims
      {
        Email = email,
        UserId = userId,
        Name = name,
        Roles = roles,
        PhoneNumber = phoneNumber
      };
    }
  }
}