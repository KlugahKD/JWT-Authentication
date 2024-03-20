using System.ComponentModel.DataAnnotations;


namespace API.Dtos
{
    public class CreateRoleDto
    {
        [Required(ErrorMessage = "Role Name is Required")]
        public string RoleName { get; set; }   = null!;
    }
}