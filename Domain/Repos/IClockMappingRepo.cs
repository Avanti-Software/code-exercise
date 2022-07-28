using CodeExercise.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.Domain.Repos
{
	public interface IClockMappingRepo
	{
		Task<Dictionary<int, Tenant>> GetClocksMapping();
	}
}
