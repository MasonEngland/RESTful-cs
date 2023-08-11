﻿namespace RESTful_cs.Models
{
	public class Book
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Author { get; set; }

		public string Series { get; set; }

		public bool SafeForKids { get; set; }

		public DateTime Date { get; set; }

		public Book()
		{
			Id = Guid.NewGuid();
			Date = DateTime.Now;
		}

	}
}

