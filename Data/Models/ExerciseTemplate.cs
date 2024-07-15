namespace LightWeight.Data.Models
{
    public class ExerciseTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
        public int PrimaryMuscleGroupId { get; set; }
        public PrimaryMuscleGroup PrimaryMuscleGroup { get; set; }
        public List<Exercise> Exercises { get; set; }
        public List<WorkoutTemplate> WorkoutTemplates { get; set; }
    }
}
