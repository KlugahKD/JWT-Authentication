using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using API.Data;

namespace API.Extensions
{
     public static class JwtSecurityTokenExtension
{
    public static string? GetClaimValue(this JwtSecurityToken token, string claimType)
    {
        var claim = token.Claims.FirstOrDefault(c => c.Type == claimType);
        return claim?.Value;
    }

public static TokenClaims DecodeToken(this JwtSecurityToken token)
    {
        var email = token.GetClaimValue(JwtRegisteredClaimNames.Email);
        var userId = token.GetClaimValue(JwtRegisteredClaimNames.NameId);
        var name = token.GetClaimValue(JwtRegisteredClaimNames.Name);
        var audience = token.GetClaimValue(JwtRegisteredClaimNames.Aud);
        var issuer = token.GetClaimValue(JwtRegisteredClaimNames.Iss);
        var roles = token.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToArray();
        var phoneNumber = token.GetClaimValue(ClaimTypes.MobilePhone);

        return new TokenClaims
        {
            Email = email,
            UserId = userId,
            Name = name,
            PhoneNumber = phoneNumber,
            Audience = audience,
            Issuer = issuer,
            Roles = roles
        };
    }
}
}