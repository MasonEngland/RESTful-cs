namespace RESTful_cs.Models
{
	public class Account
	{
		public Guid Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }

		public Account()
		{
			Id = Guid.NewGuid();
		}
	}
}

