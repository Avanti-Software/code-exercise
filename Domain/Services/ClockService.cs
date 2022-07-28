using CodeExercise.Domain.Models;
using CodeExercise.Domain.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.Domain.Services
{
	public class ClockService
	{
		private IClockRepo clockRepo;
		public ClockService(IClockRepo clockRepo)
		{
			this.clockRepo = clockRepo;
		}

		public async Task<Clock?> GetClock(int serialNo)
		{
			return await clockRepo.GetClock(serialNo);
		}

		public async Task<bool> UpdateClock(Clock clock)
		{
			return await clockRepo.UpdateClock(clock);
		}
	}
}
