using CodeExercise.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.Domain.Repos
{
	public interface IClockRepo
	{
		Task<Clock?> GetClock(int serialNo);
		Task<bool> UpdateClock(Clock clock);
	}
}
