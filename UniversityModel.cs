using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLlite_Windows
{
    public class UniversityModel
    {
        public string Project_Code { get; set; }
        public string Organisation { get; set; }
        public string Programme_Name { get; set; }
        public string Source_of_Funding { get; set; }
        public string Program_Leader { get; set; }
        public string Approval_Date { get; set; }
        public string Approval_Amount { get; set; }
        public string First_Payment_Date { get; set; }
        public string Second_Payment_Date { get; set; }
        public string Third_Payment_Date { get; set; }
        public string Fourth_Payment_Date { get; set; }
        public string Fifth_Payment_Date { get; set; }
        public decimal First_Payment_Amount { get; set; }
        public decimal Second_Payment_Amount { get; set; }
        public decimal Third_Payment_Amount { get; set; }
        public decimal Foruth_Payment_Amount { get; set; }
        public decimal Fifth_Payment_Amount { get; set; }
        public string First_Payment_Cheque_Number { get; set; }
        public string Second_Payment_Cheque_Number { get; set; }
        public string Third_Payment_Cheque_Number { get; set; }
        public string Fourth_Payment_Cheque_Number { get; set; }
        public string Fifth_Payment_Cheque_Number { get; set; }
        public string Payment_Bank { get; set; }
        public string Payment_Bank_Account_Number { get; set; }

    }
}
