using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskNTeamManganementSystem.Domain.Entities
{
    public class User
    {
        //: Id, FullName, Email, Role(Admin / Manager / Employee)
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string FullName { get; set; } = string.Empty;
        [MaxLength(200)]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Role { get; set; } = string.Empty;
    }
}
