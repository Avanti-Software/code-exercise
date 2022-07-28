using CodeExercise.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CodeExercise.Data
{
	public class Database
	{
		private Dictionary<string, Clock[]> clocksByTenant;
		private static string dataDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "data");

		public Database(Dictionary<string, Clock[]> clocksByTenant)
		{
			this.clocksByTenant = clocksByTenant;
		}

		private static Lazy<Database> instance = new Lazy<Database>(() =>
		{
			var clocks = new Dictionary<string, Clock[]>();
			string executingDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
			string[] dataFiles = Directory.GetFiles(dataDir, "*.json");
			foreach (string dataFile in dataFiles)
			{
				string tenant = Path.GetFileNameWithoutExtension(dataFile);
				string json = File.ReadAllText(dataFile);
				clocks.Add(tenant, JsonSerializer.Deserialize<Clock[]>(json)!);
			}
			return new Database(clocks);
		});

		public static Database Instance => instance.Value;

		public Clock[] GetClocks()
		{
			List<Clock> clocks = new List<Clock>();
			clocksByTenant.Values.ToList().ForEach(cs => clocks.AddRange(cs));
			return clocks.ToArray();
		}

		public async Task<Dictionary<int, Tenant>> GetClocksMapping()
		{
			var mapping = new Dictionary<int, Tenant>();
			foreach (KeyValuePair<string, Clock[]> tenantClocks in clocksByTenant)
			{
				string tenant = tenantClocks.Key;
				tenantClocks.Value
					.Select(c => c.SerialNo)
					.ToList()
					.ForEach(s => mapping.Add(s, new Tenant(tenant)));
			}
			await Task.Delay(3000);
			return mapping;
		}

		public async Task<bool> UpdateClock(Tenant tenant, Clock clock)
		{
			Clock[] clocks = clocksByTenant[tenant.Name];
			Clock? dbClock = clocks.FirstOrDefault(c => c.SerialNo == clock.SerialNo);
			if (dbClock != null)
			{
				dbClock.Description = clock.Description;
				dbClock.TimeZone = clock.TimeZone;
				string tenantFile = Path.Combine(dataDir, tenant.Name);
				string json = JsonSerializer.Serialize(clocks);
				await File.WriteAllTextAsync(tenantFile, json);
				return true;
			}
			return false;
		}
	}
}
