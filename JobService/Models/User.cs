using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JobService.Models
{
    [Index(nameof(Login), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength:100, MinimumLength = 4)]
        public string? Login { get; set; }

        [Required]
        public string? PasswordHash { get; set; }

        [Required]
        [StringLength(maximumLength: 100)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(maximumLength: 100)]
        public string? LastName { get; set; }

        [Required]
        public Settlement? Settlement { get; set; }

        public List<HardSkill>? HardSkills { get; set; }

        public List<JobInfo>? JobHistory { get; set; }

        public List<JobVacancy>? JobVacancies { get; set; }

    }
}
