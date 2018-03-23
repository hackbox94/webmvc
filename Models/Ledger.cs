using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    [Table("act_Bank_comp_cust_ledger")]
    public class Ledger
    {
        [Key]
        public int LedgerID { get; set; }
        public bool IsOpening { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public decimal CreditAmount { get; set; }
        public decimal DebitAmount { get; set; }
        public string ReferenceNo { get; set; }



    }
}
