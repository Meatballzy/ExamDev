using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamDev.Infra
{
    public class Authen
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "กรุณาใส่ชื่อ Authen")]
        [DisplayName("ชื่อ")]
        public string AuthenName { get; set; }
        public bool Status { get; set; } = true;

    }
}
