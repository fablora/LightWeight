namespace LightWeight.Data.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Duration { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<Exercise> Exercises { get; set; }
    }
}
