using CodeExercise.Data;
using CodeExercise.Domain.Models;
using CodeExercise.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeExercise.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ClockController : ControllerBase
	{
		private readonly ILogger<ClockController> logger;
		private readonly ClockService clockService;
		private readonly Tenant tenant;

		public ClockController(ILogger<ClockController> logger, Tenant tenant, 
			ClockService clockService)
		{
			this.logger = logger;
			this.tenant = tenant;
			this.clockService = clockService;
		}

		[HttpGet]
		public async Task<Clock?> Get(int sn)
		{
			return await clockService.GetClock(sn);	
		}

		[HttpGet("Tenant")]
		public string GetTenant(int sn)
		{
			return tenant.Name;
		}

		[HttpPost]
		public async Task<bool> Post(string sn, Clock clock)
		{
			return await clockService.UpdateClock(clock);
		}
	}
}