using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamDev.Infra
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Authen")]
        public int AuthenId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public bool Status { get; set; } = true;
        

    }
}
