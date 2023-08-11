namespace RESTful_cs.Models
{
	public class Movie
	{

		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Director { get; set; }
 
		public DateTime Date { get; set; }

		public Movie()
		{
			Id = Guid.NewGuid();
			Date = DateTime.Now;
		}
	}
}

