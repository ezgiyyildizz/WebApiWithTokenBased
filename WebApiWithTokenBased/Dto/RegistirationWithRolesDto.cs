using WebApiWithTokenBased.Dto;

public class RegistrationWithRolesDto
{
    public RegistrationDto RegistrationDto { get; set; }
    public ICollection<string> Roles { get; set; }
}
