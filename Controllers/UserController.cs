using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssesmentAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		
		private InMemoryRepo _data;

		public UserController(InMemoryRepo _repo) { 
			_data =  _repo;
		}

		// GET: api/<UserController>
		[HttpGet]
		public List<Users> Get()
		{
			return _data.Users;
		}

		// GET api/<UserController>/5
		[HttpGet("{id}")]
		public Users Get(int id)
		{
			var u = _data.Users.FirstOrDefault(u=>u.Id == id);
			return u;
		}

		// POST api/<UserController>
		[HttpPost]
		public void Post([FromBody] Users user)
		{
			//user.Id = _data.Users.Any()?_data.Users.Max(u=>u.Id)+1:1;
			_data.Users.Add(user);
		}

		// PUT api/<UserController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] Users value)
		{
			var user = _data.Users.Find(users=>users.Id == id);
			if (user != null)
			{
				user.Status = value.Status;
				user.Id = value.Id;
				user.Age = value.Age;
			}
		}

		// DELETE api/<UserController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			var user = _data.Users.Find(user=>user.Id == id);
			if (user != null)
			{
				_data.Users.Remove(user);
			}
		}
	}
}
