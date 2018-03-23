using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    [Table("mst_job_Service_hdr")]
    public class JobServiceHead
    {
        [Key]
        public int JobServiceHeadID { get; set; }
        public string Name { get; set; }
        public List<JobService> JobServices { get; set; }
    }
}
