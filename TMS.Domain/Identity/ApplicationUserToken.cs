using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Identity;
public class ApplicationUserToken : IdentityUserToken<Guid>
{
    #region Entity Members
    public string TokenId { get; set; } // Map the token with jwtId
    public bool IsUsed { get; set; } // if its used we dont want generate a new Jwt token with the same refresh token
    public bool IsRevoked { get; set; } // if it has been revoke for security reasons

    [Required, Column(TypeName = "datetime")]
    public DateTime CreatedOn { get; set; }
    [Required, Column(TypeName = "datetime")]
    public DateTime ExpiresOn { get; set; }

    public Guid SessionGuid { get; set; }
    #endregion
}
