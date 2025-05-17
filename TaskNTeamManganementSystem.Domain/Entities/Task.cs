using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskNTeamManganementSystem.Domain.Entities
{
    public class Task
    {
        //Id, Title, Description, Status (Todo / InProgress / Done), AssignedToUserId,
        //CreatedByUserId, TeamId, DueDate
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Title { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(max)")]
        public string? Description { get; set; }
        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = string.Empty;
        [ForeignKey("AssignedToUser")]
        public int AssignedToUserId { get; set; }
        [ForeignKey("CreatedByUser")]
        public int CreatedByUserId { get; set; }
        [ForeignKey("Team")]
        public int TeamId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DueDate { get; set; } = DateTime.Now;
    }
}
