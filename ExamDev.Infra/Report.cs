using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamDev.Infra
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Module { get; set; }
        [Required]
        public string SubModule { get; set; }
        [Required]
        public string JobDescript { get; set; }
        public string JobType { get; set; }
        public string WorkPerformed { get; set; }
        public string? Solution { get; set; }
        public string? PjId { get; set; }
        public string Type { get; set; }
        [Required]
        public string Receiveway { get; set; }
        [Required]
        public string Informer { get; set; }
        public int Tel { get; set; }
        [Required]
        public string Respond { get; set; }
        public bool Status { get; set; } = false;
        public int Days { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }


        

    }
}
