namespace Identity.Module.Responses
{
	public class UserResponse
	{
		public Guid Id { get; set; }
		public string Fullname { get; set; }
		public string Email { get; set; }
		public RoleResponse Role { get; set; }
	}
}