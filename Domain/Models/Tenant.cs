using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.Domain.Models
{
	public record class Tenant(string Name)
	{
		public bool IsValid => !string.IsNullOrWhiteSpace(Name);
	}
}
