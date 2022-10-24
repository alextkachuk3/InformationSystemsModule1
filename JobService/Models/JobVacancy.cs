using System.ComponentModel.DataAnnotations;

namespace JobService.Models
{
    public class JobVacancy
    {
        public JobVacancy() { }

        public JobVacancy(User user, string title, int salary, string description)
        {
            User = user;
            Title = title;
            Salary = salary;
            Description = description;
        }

        public int Id { get; set; }

        [Required]
        public User? User { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Description { get; set; }

        public int Salary { get; set; }

        public bool Remote { get; set; }

        public Settlement? Settlement { get; set; }

        public List<HardSkill>? HardSkills { get; set; }
    }
}
