using Microsoft.AspNetCore.Identity;
using System;

public class UserRole : IdentityRole
{
    public DateTime CreatedAt { get; set; }
    public string Description { get; set; } = "Default Description";
    public string CreatedBy { get; set; } = "System";
    public bool IsActive { get; set; }
}
