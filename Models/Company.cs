using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("mst_company")]
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Area { get; set; }
        public string State { get; set; }
        public string Mobile { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public decimal CreditLimit { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:d}")]
        public Nullable<DateTime> LicenseExpiry { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public Nullable<DateTime> EstCardExpiry { get; set; }
        public virtual List<Employee> Employees { get; set; }
        public virtual List<PriceMatrix> PriceMatrices { get; set; }
    }
}
