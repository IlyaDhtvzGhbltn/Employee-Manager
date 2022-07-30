using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeManagement.Entities
{
    [Table("WinClientUser")]
    public class WinClientUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string Role { get; set; }

        [Required]
        [MaxLength(256)]
        public string Login { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}
