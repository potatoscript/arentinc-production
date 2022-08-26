using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobApi.Models
{
    public class Employee
    {
        // This will be the primaryKey
        public int EmployeeId { get; set; }

        [Column(TypeName = "character varying(30)")]
        public string Name { get; set; }

        [Column(TypeName = "character varying(30)")]
        public string Position { get; set; }

        [Column(TypeName = "character varying(30)")]
        public string Department { get; set; }

        [Column(TypeName = "character varying(30)")]
        public string Email { get; set; }

    }
}
