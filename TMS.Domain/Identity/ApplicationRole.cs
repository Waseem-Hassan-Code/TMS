﻿using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity;
public class ApplicationRole : IdentityRole<Guid>
{
    public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
}
