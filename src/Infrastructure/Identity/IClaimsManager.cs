using Domain.Entities;
using Domain.Entities.UserAggregate;
using System.Security.Claims;
using ZeStudio;

namespace Infrastructure.Identity
{
	public interface IClaimsManager : IScopedInjector<IClaimsManager, ClaimsManager>
	{
		Guid GetCurrentUserId();
		string GetCurrentUserName();
		IEnumerable<Claim> GetUserClaims(UserEntity user);
		Claim GetUserClaim(string claimType);
	}
}