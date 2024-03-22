using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class TokenClaims
    {
    public string? Email { get; set; }
    public string? UserId { get; set; }
    public string? Name { get; set; }
    public string? Audience { get; set; }
    public string? Issuer { get; set; }
    }
}