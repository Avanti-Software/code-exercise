namespace CodeExercise.Domain.Models
{
	public class Clock
	{
		public int SerialNo { get; set; } = -1;
		public bool Active { get; set; } = true;
		public string Description { get; set; } = "";
		public string TimeZone { get; set; } = "";
	}
}