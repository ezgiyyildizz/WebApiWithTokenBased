using Microsoft.AspNetCore.Mvc;
using WebApiWithTokenBased.ActionFilters;
using WebApiWithTokenBased.Dto;

namespace WebApiWithTokenBased.Controllers
{
    // Rol işlemlerini yöneten denetleyici
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IAuthRepository _authRepository;

        // Denetleyici için bağımlılık enjeksiyonu
        public RoleController(IRoleRepository roleRepository, IAuthRepository authRepository)
        {
            _roleRepository = roleRepository;
            _authRepository = authRepository;
        }

        // Kullanıcı rolünü kontrol eden ve sadece yetkilendirilmiş kullanıcılara izin veren özelleştirilmiş filtre
        [TypeFilter(typeof(TokenAuthenticationFilter), Arguments = new object[] { "CanReadRoles" })]
        [HttpGet("GetAllRoles")]
        public IActionResult GetAllRoles()
        {
            // Tüm rolleri al ve döndür
            var roles = _roleRepository.GetAllRoles();
            return Ok(roles);
        }
    



// Bir rolü ID'ye göre getirme metodu
[TypeFilter(typeof(TokenAuthenticationFilter), Arguments = new object[] { "CanGetRoleById" })]
        [HttpGet("GetRoleById/{name}")]
        public IActionResult GetRoleById(string name)
        {
            var role = _roleRepository.GetRoleById(name);
            if (role != null)
            {
                return Ok(role);
            }
            return NotFound();
        }

        // Yeni rol ekleme metodu
        [TypeFilter(typeof(TokenAuthenticationFilter), Arguments = new object[] { "CanAddRole" })]
        [HttpPost("AddRole")]
        public IActionResult AddRole([FromBody] RoleDto roleDto)
        {
            _roleRepository.AddRole(roleDto.RoleName, roleDto.Description, roleDto.CreatedBy, roleDto.IsActive);
            return StatusCode(201, roleDto);
        }

        // Rol güncelleme metodu
        [TypeFilter(typeof(TokenAuthenticationFilter), Arguments = new object[] { "CanUpdateRole" })]
        [HttpPut("UpdateRole/{customName}")]
        public IActionResult UpdateRole(string customName, [FromBody] RoleDto roleDto)
        {
            var role = _roleRepository.GetRoleById(customName);
            _roleRepository.UpdateRole(customName, role);
            return NoContent();
        }

        // Rol silme metodu
        [TypeFilter(typeof(TokenAuthenticationFilter), Arguments = new object[] { "CanDeleteRole" })]
        [HttpDelete("DeleteRole/{name}")]
        public IActionResult DeleteRole(string name)
        {
            _roleRepository.DeleteRole(name);
            return NoContent();
        }

        // Rolü kısmen güncelleme metodu (Patch)
        [TypeFilter(typeof(TokenAuthenticationFilter), Arguments = new object[] { "CanPatchRole" })]
        [HttpPatch("PatchRole/{name}")]
        public IActionResult PatchRole(string name, [FromBody] RolePatchDto rolePatchDto)
        {
            var role = _roleRepository.GetRoleById(name);
            if (role == null)
            {
                return NotFound();
            }

            if (rolePatchDto.Description != null)
            {
                role.Description = rolePatchDto.Description;
            }

            if (rolePatchDto.IsActive.HasValue)
            {
                role.IsActive = rolePatchDto.IsActive.Value;
            }

            _roleRepository.UpdateRole(name, role);

            return NoContent();
        }

        [TypeFilter(typeof(TokenAuthenticationFilter), Arguments = new object[] { "CanAssignRolesToUser" })]
        [HttpPost("AssignRolesToUser")]
        public async Task<IActionResult> AssignRolesToUser(string userName, IEnumerable<string> roles)
        {
            try
            {
                var user = await _authRepository.GetUserByName(userName);

                // AssignRolesToUser metodunu çağırarak rolleri atayın
                await _roleRepository.AssignRolesToUser(user, roles);
                return Ok("Roles assigned successfully.");
            }
            catch (RoleNotFoundException ex)
            {
                return NotFound(ex.Message); // Sadece hata mesajını döndürür
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }



        // Kullanıcıdan rolleri çıkarma metodu
        [TypeFilter(typeof(TokenAuthenticationFilter), Arguments = new object[] { "CanRemoveRolesFromUser" })]
        [HttpPost("RemoveRolesFromUser/{userName}")]
        public async Task<IActionResult> RemoveRolesFromUser(string userName, [FromBody] IEnumerable<string> roles)
        {
            var user = await _authRepository.GetUserByName(userName);

            if (user == null)
            {
                return NotFound();
            }

            await _roleRepository.RemoveRolesFromUser(user, roles);

            return Ok("Roller başarıyla kullanıcıdan çıkarılmıştır.");
        }

        // Kullanıcının rollerini getirme metodu
        [HttpGet("roles/{username}")]
        public async Task<IActionResult> GetRolesForUser(string username)
        {
            try
            {
                var roles = await _authRepository.GetRolesForUser(username);
                return Ok(roles);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Roldeki kullanıcıları getirme metodu
        [TypeFilter(typeof(TokenAuthenticationFilter), Arguments = new object[] { "CanUserInRole" })]
        [HttpGet("usersinrole/{roleName}")]
        public async Task<IActionResult> GetUsersInRole([FromRoute(Name= "roleName")]string roleName)
        {
            try
            {
                var users = await _authRepository.GetUsersInRole(roleName);
                return Ok(users);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // Role claim atama metodu
        //[TypeFilter(typeof(TokenAuthenticationFilter), Arguments = new object[] { "CanAddRoleClaimToUser" })]
        [HttpPost("AddRoleClaimToUser")]
        public async Task<IActionResult> AddRoleClaimToUser([FromBody] ClaimDto claimDto)
        {
            await _roleRepository.AddRoleClaimToUser(claimDto.RoleName, claimDto.ClaimType, claimDto.ClaimValue);
            return Ok("Role claim added successfully.");
        }



        // İlgili role için bir izni kaldırmak için kullanılan HTTP DELETE isteğini işleyen metod
        [HttpDelete("{roleName}/permissions")]
        public async Task<IActionResult> RemovePermission(string roleName, [FromBody] ClaimDto claimDto)
        {
            // Geçerli model durumunu kontrol et
            if (!ModelState.IsValid)
            {
                return BadRequest("Geçersiz veri gönderildi.");
            }

            try
            {
                // İzin kaldırma işlemini gerçekleştir
                var isPermissionRemoved = await _roleRepository.RemovePermissionFromRole(roleName, claimDto.ClaimType, claimDto.ClaimValue);

                // İzin başarıyla kaldırıldıysa
                if (isPermissionRemoved)
                {
                    return Ok("İzin başarıyla kaldırıldı.");
                }
                // İzin role atanmamışsa
                else
                {
                    return NotFound("Belirtilen izin, role atanmamış.");
                }
            }
            // Argüman hatası durumunda
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            // Diğer hata durumlarında
            catch (Exception)
            {
                return StatusCode(500, "Bir hata oluştu. İzin kaldırılamadı.");
            }
        }

    }
}
