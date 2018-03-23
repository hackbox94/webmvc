using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    [Table("mst_job_service")]
    public class JobService
    {
        [Key]
        public int JobServiceID { get; set; }
        public string Name { get; set; }
        public decimal GovtFees { get; set; }
        public Nullable<int> JobServiceHeadID { get; set; }
        public virtual JobServiceHead JobServiceHeads { get; set; }
        public virtual List<PriceMatrix> PriceMatrices { get; set; }



    }
}
