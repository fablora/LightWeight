using Microsoft.AspNetCore.Identity;

namespace LightWeight.Data.Models
{
    public class User : IdentityUser
    {

        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double BodyFat { get; set; }
        public List<Workout> Workouts { get; set; }
        public List<WorkoutTemplate> WorkoutTemplates { get; set; }
    }
}