using System.Security.Principal;

namespace AssesmentAPI
{
	public class InMemoryRepo
	{
		public List<Users> Users { get; set; } = new();
		public List<Accounts> Accounts { get; set; } = new();
	}
}
