using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace AssesmentAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountsController : Controller
	{
		private InMemoryRepo _data;
		public AccountsController(InMemoryRepo _repo)
		{
			_data = _repo;
		}


		//GET
		[HttpGet()]
		public List<Accounts> Get()
		{
			return _data.Accounts;
		}

		// GET /id
		
		[HttpGet("{id}")]
		public List<Accounts> Get(int id)
		{
			var accounts = _data.Accounts.FirstOrDefault(account=> account.Id == id);
			return _data.Accounts;
		}


		// POST 
		[HttpPost]
		public dynamic Post(Accounts acc) {

			if (acc.UserId != null)
			{
				_data.Accounts.Add(acc);
			}
			else
			{
				return NotFound("No UserId found");
			}


			return 0;
		}
		
		// PUT 
		[HttpPost("{id}")]
		public dynamic Put(int id, [FromBody]Accounts account) { 

			var acc = _data.Accounts.FirstOrDefault(a=> a.Id == id);

			if (acc != null) {
				if (acc.UserId != null)
				{
					acc.Website = account.Website;
					acc.Type = account.Type;
					acc.Id = id;
					acc.UserId = account.UserId;
				}
				else
				{
					return NotFound("No UserId found");
				}
				
			}

			return 0;
		
		}

		//Delete 

		[HttpDelete("{id}")]
		public void Delete(int id) { 
			var acc = _data.Accounts.FirstOrDefault(a=> a.Id == id);
			if (acc != null) { 

				var userId = acc.UserId;
				var isUserExists = _data.Users.Any(u=>u.Id == userId);

				if (isUserExists) { 
					var user = _data.Users.FirstOrDefault(u=>u.Id == userId);
					_data.Users.Remove(user);
				}
			
				_data.Accounts.Remove(acc);
			}

		
		}



	}
}
