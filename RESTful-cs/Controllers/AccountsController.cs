using System.Diagnostics;
using RESTful_cs.Context;
using Microsoft.AspNetCore.Mvc;
using RESTful_cs.Models;
using static BCrypt.Net.BCrypt;

namespace RESTful_cs.Controllers
{
	[Route("/[controller]")]
	public class AccountsController : Controller
	{
		private readonly DatabaseContext _db;
		public AccountsController(DatabaseContext db)
		{
			_db = db;
		}
        private bool UsernameIsTaken(Account account)
        {
            Account[] Taken = _db.Accounts.Where(d => d.Username == account.Username).ToArray();
            if (Taken.Length > 0)
            {
                return true;
            }
            return false;
        }
		// GET: /Accounts
        [HttpGet]
		public IActionResult GetAccounts()
		{
			try
			{
                Account[] accounts = _db.Accounts.ToArray();
                return Ok(accounts);
            } catch (Exception err)
			{
				Debug.WriteLine(err.Message);
				return StatusCode(500);
			}
		}
		// POST: /Accounts
		[HttpPost]
		public string Register([FromBody] Account account)
		{
			Debug.WriteLine(account);
			try
			{
				if (UsernameIsTaken(account))
				{
					StatusCode(200);
					return "Username already registered";
				}

				if (account.Username != null)
				{
                    _db.Accounts.Add(new Account()
                    {
                        Username = account.Username,
                        Password = HashPassword(account.Password)
                    });
                    _db.SaveChanges();
                } 
				return $"success: {account.Username}";
			} catch (Exception err)
			{
                Debug.WriteLine(account.Username);
                return (err.Message);
			}
		}
		[HttpPost("Verify")]
		public object VerifyAccount([FromBody] Account account)
		{
			try
			{
				Account[] accounts = _db.Accounts.Where(d => d.Username == account.Username).ToArray();

				Debug.WriteLine(account.Username);
				// accounts list should never have more than one item
				foreach (var item in accounts)
				{
					if (item.Username == account.Username && Verify(account.Password, item.Password))
					{
						return new
						{
							success = true,
							Username = account.Username,
							Password = account.Password
						};
					}
				}
				return new
				{
					success = false,
					message = "Incorrect username or password"
				};

			} catch (Exception err)
			{
				Debug.WriteLine(err);
				return new
				{
					success = "false",
				};
			}
		}
    }
}