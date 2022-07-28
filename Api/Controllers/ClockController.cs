using CodeExercise.Data;
using CodeExercise.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeExercise.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ClockController : ControllerBase
	{
		private readonly ILogger<ClockController> logger;

		public ClockController(ILogger<ClockController> logger)
		{
			this.logger = logger;
		}

		[HttpGet]
		public async Task<Clock?> Get(int sn)
		{
			throw new NotImplementedException();
		}

		[HttpGet("Tenant")]
		public string GetTenant(int sn)
		{
			throw new NotImplementedException();
		}

		[HttpPost]
		public async Task<bool> Post(string sn, Clock clock)
		{
			throw new NotImplementedException();
		}
	}
}