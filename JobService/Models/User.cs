using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JobService.Models
{
    [Index(nameof(Login), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Login field is required.")]
        [StringLength(maximumLength:100, MinimumLength = 4)]
        public string Login { get; set; }


        public string Name { get; set; }
    }
}
