using ApiMar.Models.DTO.Auth;

namespace ApiMar.Repositories.Interfaces
{
	public interface IAuthRepository
	{
		public Task<UserWaucDTO?> Login(IConfiguration configuration, string username, string password);

		public string JwtTokenGenerate(IConfiguration configuration, UserWaucDTO user);

		public UserWaucDTO JwtTokenCheck(IConfiguration configuration, string token);
	}
}
