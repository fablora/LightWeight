namespace LightWeight.Data.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public int ExerciseTemplateId { get; set; }
        public ExerciseTemplate ExerciseTemplate { get; set; }
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }
        public List<Set> Sets { get; set; }
    }
}
