namespace Identity.Module.Responses
{
	public class JWTResponse
	{
		public string Token { get; set; }
		public string RefreshToken { get; set; }
		public DateTime ExpiresAt { get; set; }
	}
}