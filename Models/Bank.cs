using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    [Table("mst_bank")]
    public class Bank
    {
        [Key]
        public int BankID { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
    }
}
