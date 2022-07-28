using CodeExercise.Domain.Models;
using CodeExercise.Domain.Repos;

namespace CodeExercise.Data.Repos
{
	public class ClockRepo : IClockRepo
	{
		private Tenant tenant;
		public ClockRepo(Tenant tenant)
		{
			this.tenant = tenant;
		}

		public Task<Clock?> GetClock(int serialNo)
		{
			return Task.Run(() => Database.Instance.GetClocks().FirstOrDefault(c => c.SerialNo == serialNo));
		}

		public async Task<bool> UpdateClock(Clock clock)
		{
			return await Database.Instance.UpdateClock(tenant, clock);
		}
	}
}