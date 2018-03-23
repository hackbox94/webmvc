using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    [Table("mst_pricematrix")]
    public class PriceMatrix
    {
        [Key]
        public int PriceMatrixID { get; set; }
        public decimal Price { get; set; }
        public Nullable<int> JobServicesID { get; set; }
        public virtual JobService JobServices { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public virtual Company Companys { get; set; }

    }
}
