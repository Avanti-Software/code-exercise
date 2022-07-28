using CodeExercise.Domain.Models;

namespace CodeExercise.Data.Repos
{
	public class ClockMappingRepo
	{
		public async Task<Dictionary<int, Tenant>> GetClocksMapping() => 
			await Database.Instance.GetClocksMapping();
	}
}