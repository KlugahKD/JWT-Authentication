using API.Dtos;
using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class RolesController:ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly UserManager<AppUser> _userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpPost]

    public async Task<IActionResult> CreateRole([FromBody] CreateRoleDto createRoleDto)
    {
        if(string.IsNullOrEmpty(createRoleDto.RoleName)){
            return BadRequest ("Role name is required");
        }
        var roleExist = await _roleManager.RoleExistsAsync(createRoleDto.RoleName);

        if(roleExist){
            return BadRequest("Role already exists");
        }

        var roleResult = await _roleManager.CreateAsync(new IdentityRole(createRoleDto.RoleName));

        if(roleResult.Succeeded){
            return Ok(new {
                message = "Role Created successfully"
            });
        }

        return BadRequest("Role Creation failed.");
    }
    }
}