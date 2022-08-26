using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobApi.Models
{
    public class Job
    {
        public int JobId { get; set; }

        [Column(TypeName = "character varying(30)")]
        public string EmployeeName { get; set; }

        [Column(TypeName = "character varying(30)")]
        public string EmployeeDepartment { get; set; }

        [Column(TypeName = "character varying(100)")]
        public string JobContent { get; set; }

        [Column(TypeName = "character varying(30)")]
        public string DueDate { get; set; }

        [Column(TypeName = "character varying(30)")]
        public string Status { get; set; }

    }
}
