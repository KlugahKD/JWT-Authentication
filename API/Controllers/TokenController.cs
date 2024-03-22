using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using API.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController: ControllerBase
    {
        
    [HttpGet]
    [Route("Decode")]
    public IActionResult DecodeToken(string jwtToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = tokenHandler.ReadJwtToken(jwtToken);

        // Decode and retrieve claim values using the extension method
        var tokenClaims = jwtSecurityToken.DecodeToken();

        // Return the decoded claims
        return Ok(tokenClaims);
    } 
    }
}