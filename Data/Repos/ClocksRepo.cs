using CodeExercise.Domain.Models;
using CodeExercise.Domain.Repos;

namespace CodeExercise.Data.Repos
{
	public class ClockMappingRepo : IClockMappingRepo
	{
		public async Task<Dictionary<int, Tenant>> GetClocksMapping() => 
			await Database.Instance.GetClocksMapping();
	}
}