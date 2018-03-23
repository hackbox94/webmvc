using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    [Table("trn_bill_header")]
    public class SalesHeader
    {
        [Key]
        public int BillHeaderID { get; set; }
        public DateTime BillSalesDateTime { get; set; }
        public string BillNo { get; set; }
        public decimal BillAmount { get; set; }
        public decimal BillDiscountAmount { get; set; }
        public decimal BillPaidAmount { get; set; }
        public string BillRemarks { get; set; }
        public bool IsBillPrinted { get; set; }
    }
}
