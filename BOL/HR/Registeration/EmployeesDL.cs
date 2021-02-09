using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.HR.Registeration
{
    public class EmployeesDL
    {

        public string Company_Id { get; set; }
        public string Branch_Id { get; set; }
        public decimal Emp_Serial_No { get; set; }
        public string Emp_Id { get; set; }
        public string Emp_Code { get; set; }
        public string Emp_First_Name { get; set; }
        public string Emp_Meduim_Name { get; set; }
        public string Emp_GrandFatherName { get; set; }
        public string Emp_Last_Name { get; set; }
        public string Emp_First_NameEn { get; set; }
        public string Emp_Meduim_NameEn { get; set; }
        public string Emp_GrandFatherNameEn { get; set; }
        public string Emp_Last_NameEn { get; set; }
        public string Emp_Last_NameConv { get; set; }
        public string Birth_Date { get; set; }
        public string WorkStartingDate { get; set; }
        
        public string Birth_Place { get; set; }
        public string Hire_Date { get; set; }
        public string Social_Status_Id { get; set; }
        public string Military_Status_Id { get; set; }
        public string Geneder_Id { get; set; }
        public string Religion_Id { get; set; }
        public string Countery_Id { get; set; }
        public string City_Id { get; set; }
        public string Nationality_Id { get; set; }
        public string Project_Id { get; set; }
        public string Contract_Id { get; set; }
        public string Admin_Id { get; set; }
        public string Dept_Id { get; set; }
        public string Job_Id { get; set; }
        public string JobTitle { get; set; }
        public string Grade_Id { get; set; }
        public string Qualify_Type_Id { get; set; }
        public string Qualify_Id { get; set; }
        public string Shift_Id { get; set; }
        public string Identity_Type_Id { get; set; }
        public string Identity_No { get; set; }
        public string Identity_StartDate { get; set; }
        public string Identity_StartDateHijri { get; set; }
        public string Identity_EndDate { get; set; }
        public string Identity_EndDateHijri { get; set; }
        public string Inside_Phone { get; set; }
        public string Inside_Mobile1 { get; set; }
        public string Inside_Mobile2 { get; set; }
        public string Outside_Phone1 { get; set; }
        public string Outside_Mobile1 { get; set; }
        public string Outside_Mobile2 { get; set; }
        public string Fax { get; set; }
        public string InsideAddress1 { get; set; }
        public string InsideAddress2 { get; set; }
        public string OutsideAddress1 { get; set; }
        public string OutsideAddress2 { get; set; }
        public string BusinessEmail { get; set; }
        public string PrivateEmail { get; set; }
        public string Manager_Id { get; set; }
        public string Bank_No1 { get; set; }
        public string AccountBankNo1 { get; set; }
        public string IBAN_No1 { get; set; }
        public string Bank_No2 { get; set; }
        public string AccountBankNo2 { get; set; }
        public string IBAN_No2 { get; set; }
        public Nullable<byte> HasFingerPrint { get; set; }
        public Nullable<byte> HasAbsence { get; set; }
        public Nullable<byte> HasOverTime { get; set; }
        public Nullable<byte> HasDelay { get; set; }
        public Nullable<byte> HasPermission { get; set; }
        public Nullable<byte> HasMedicalInsurance { get; set; }
        public string Medical_Insurance_No { get; set; }
        public string Medical_Insurance_StartDate { get; set; }
        public string Medical_Insurance_StartDateHijri { get; set; }
        public string Medical_Insurance_EndDate { get; set; }
        public string Medical_Insurance_EndDateHijri { get; set; }
        public string Social_Insurance_No { get; set; }
        public string Notes { get; set; }
        public string InsUser { get; set; }
        public Nullable<System.DateTime> InsDate { get; set; }
        public string UpdateUser { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string DeleteUser { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
        public byte Rec_Status { get; set; }
        public string Prefix { get; set; }
        public string FullNameArabic { get; set; }
        public string FullNameEn { get; set; }
        public string ImagePath { get; set; }
        public string PassportNo { get; set; }
        public string PassportIssueDate { get; set; }
        public string PassportExpiryDate { get; set; }
        public Nullable<byte> IsCommissioner { get; set; }
        
        public Nullable<decimal> Commissioner_Serial_no { get; set; }
        public Nullable<byte> NeedMandate { get; set; }
        public Nullable<System.Guid> EmpHdrId { get; set; }
        public string GradeJob_Id { get; set; }
        public string EmpStatusId { get; set; }
        public Nullable<byte> HasManager { get; set; }
        public string ContractClassify { get; set; }
        public string StartContract { get; set; }
        public string EndContract { get; set; }
        public Nullable<decimal> ContractPeriodByMonth { get; set; }
        public Nullable<byte> IsEmpManager { get; set; }

         public Nullable<byte> DeductInsurance { get; set; }

        
        public string EnrollFPNumber { get; set; }
        public string Attendance_Type { get; set; }
        public string DeliverSalType { get; set; }
        public string ResignationDate { get; set; }

        public Nullable<decimal> TestPeriodInMonth { get; set; }

        public string EndTestPeriodDate { get; set; }





    }
}
