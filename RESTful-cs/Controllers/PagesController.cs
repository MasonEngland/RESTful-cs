using Microsoft.AspNetCore.Mvc;
namespace RESTful_cs.Controllers
{
	[Route("/")]
	public class PagesController : Controller
	{
		[HttpGet]
		public IActionResult HomePage()
		{
			return File("/index.html", "text/html");
		}

		[HttpGet("/Login")]
		public IActionResult SecondPage()
		{
			return File("~/Login/index.html", "text/html");
		}

	}
}

