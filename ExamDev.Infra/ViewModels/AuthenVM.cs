using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamDev.Infra.ViewModels
{
    public class AuthenVM
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("ชื่อ")]
        public string AuthenName { get; set; }
        public bool Status { get; set; } = true;

    }
}
