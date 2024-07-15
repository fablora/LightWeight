namespace LightWeight.Data.Models
{
    public class WorkoutTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<ExerciseTemplate> ExerciseTemplates { get; set; }
    }
}
