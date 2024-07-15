namespace LightWeight.Data.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ExerciseTemplate> ExerciseTemplates { get; set; }
    }
}
