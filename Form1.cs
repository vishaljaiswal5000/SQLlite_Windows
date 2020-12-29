using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLlite_Windows
{
    public partial class Form1 : Form
    {
        Boolean isEditing = false;
        string GProject_Code = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UniversityModel data = SetFields();
            SqliteDataAccess.SaveUniversity(data);

            MessageBox.Show("Record saved successfully.");
            button1_Click(sender, e);

        }

        public UniversityModel SetFields()
        {
            UniversityModel ob = new UniversityModel();
            ob.Approval_Amount = txtApporvalAmount.Text;
            ob.Approval_Date = txtApprovalDate.Text;
            if (!String.IsNullOrEmpty(txtFifthPaymentAmount.Text))
                ob.Fifth_Payment_Amount = Convert.ToDecimal(txtFifthPaymentAmount.Text);
            ob.Fifth_Payment_Cheque_Number = txtFifthChequeNumber.Text;
            ob.Fifth_Payment_Date = txtFifthPaymentDate.Text;
            if (!String.IsNullOrEmpty(txtFirstPaymentAmount.Text))
                ob.First_Payment_Amount = Convert.ToDecimal(txtFirstPaymentAmount.Text);
            ob.First_Payment_Cheque_Number = txtFirstChequeNumber.Text;
            ob.First_Payment_Date = txtFirstPaymentDate.Text;
            if (!String.IsNullOrEmpty(txtForuthPaymentAmount.Text))
                ob.Foruth_Payment_Amount = Convert.ToDecimal(txtForuthPaymentAmount.Text);
            ob.Fourth_Payment_Cheque_Number = txtFourthChequeNumber.Text;
            ob.Fourth_Payment_Date = txtFourthPaymentDate.Text;
            ob.Organisation = txtOrganisation.Text;
            ob.Payment_Bank = txtPaymentBank.Text;
            ob.Payment_Bank_Account_Number = txtPaymentBankAccountNumber.Text;
            ob.Programme_Name = txtProgrammeName.Text;
            ob.Program_Leader = txtProgramLeader.Text;
            ob.Project_Code = txtProjectCode.Text;
            if (!String.IsNullOrEmpty(txtSecondPaymentAmount.Text))
                ob.Second_Payment_Amount = Convert.ToDecimal(txtSecondPaymentAmount.Text);
            ob.Second_Payment_Cheque_Number = txtSecondChequeNumber.Text;
            ob.Second_Payment_Date = txtSecondPaymentDate.Text;
            ob.Source_of_Funding = txtSourceofFunding.Text;
            if (!String.IsNullOrEmpty(txtThirdPaymentAmount.Text))
                ob.Third_Payment_Amount = Convert.ToDecimal(txtThirdPaymentAmount.Text);
            ob.Third_Payment_Cheque_Number = txtThirdChequeNumber.Text;
            ob.Third_Payment_Date = txtThirdPaymentDate.Text;

            return ob;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GProject_Code = "";
            isEditing = false;
            txtApporvalAmount.Text = "";
            txtApprovalDate.Text = "";
            txtFifthChequeNumber.Text = "";
            txtFifthPaymentAmount.Text = "";
            txtFifthPaymentDate.Text = null;
            txtFirstChequeNumber.Text = "";
            txtFirstPaymentAmount.Text = "";
            txtFirstPaymentDate.Text = "";
            txtForuthPaymentAmount.Text = "";
            txtFourthChequeNumber.Text = "";
            txtFourthPaymentDate.Text = "";
            txtOrganisation.Text = "";
            txtPaymentBank.Text = "";
            txtPaymentBankAccountNumber.Text = "";
            txtProgramLeader.Text = "";
            txtProgrammeName.Text = "";
            txtProjectCode.Text = "";
            txtSecondChequeNumber.Text = "";
            txtSecondPaymentAmount.Text = "";
            txtSecondPaymentDate.Text = "";
            txtSourceofFunding.Text = "";
            txtThirdChequeNumber.Text = "";
            txtThirdPaymentAmount.Text = "";
            txtThirdPaymentDate.Text = "";
            btnDelete.Visible = false;

        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIpProjectCode.Text))
            {
                UniversityModel data = SqliteDataAccess.GetUniversityByProjectCode(txtIpProjectCode.Text.Trim());
                setupFields(data);
                isEditing = true;
                btnDelete.Visible = true;
                GProject_Code = data.Project_Code;
            }
            else
            {
                MessageBox.Show("enter project code");
            }
        }

        public void setupFields(UniversityModel ob)
        {
            txtApporvalAmount.Text = ob.Approval_Amount;
            txtApprovalDate.Text = ob.Approval_Date;
            txtFifthPaymentAmount.Text = ob.Fifth_Payment_Amount.ToString();

            txtFifthChequeNumber.Text = ob.Fifth_Payment_Cheque_Number;
            txtFifthPaymentDate.Text = ob.Fifth_Payment_Date;

            txtFirstPaymentAmount.Text = ob.First_Payment_Amount.ToString();
            txtFirstChequeNumber.Text = ob.First_Payment_Cheque_Number;
            txtFirstPaymentDate.Text = ob.First_Payment_Date;
            txtForuthPaymentAmount.Text = ob.Foruth_Payment_Amount.ToString();
            txtFourthChequeNumber.Text = ob.Fourth_Payment_Cheque_Number;
            txtFourthPaymentDate.Text = ob.Fourth_Payment_Date;
            txtOrganisation.Text = ob.Organisation;
            txtPaymentBank.Text = ob.Payment_Bank;
            txtPaymentBankAccountNumber.Text = ob.Payment_Bank_Account_Number;
            txtProgrammeName.Text = ob.Programme_Name;
            txtProgramLeader.Text = ob.Program_Leader;
            txtProjectCode.Text = ob.Project_Code;
            txtSecondPaymentAmount.Text = ob.Second_Payment_Amount.ToString();
            txtSecondChequeNumber.Text = ob.Second_Payment_Cheque_Number;
            txtSecondPaymentDate.Text = ob.Second_Payment_Date;
            txtSourceofFunding.Text = ob.Source_of_Funding;
            txtThirdPaymentAmount.Text = ob.Third_Payment_Amount.ToString();
            txtThirdChequeNumber.Text = ob.Third_Payment_Cheque_Number;
            txtThirdPaymentDate.Text = ob.Third_Payment_Date;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                SqliteDataAccess.DeleteUniversity(GProject_Code);
                button1_Click(sender, e);
            }
        }
    }
}
