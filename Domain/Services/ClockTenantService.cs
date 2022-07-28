using CodeExercise.Domain.Models;
using CodeExercise.Domain.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.Domain.Services
{
	public class ClockTenantService
	{
		private IClockMappingRepo clockMappingRepo;
		public ClockTenantService(IClockMappingRepo clockMappingRepo)
		{
			this.clockMappingRepo = clockMappingRepo;
		}

		public async Task<Tenant?> GetClockTenant(int serialNo)
		{
			Dictionary<int, Tenant> mapping = await clockMappingRepo.GetClocksMapping();
			return mapping[serialNo];
		}
	}
}
