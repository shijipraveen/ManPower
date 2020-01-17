using System;

namespace ManPowerModel
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string FatherName { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PassportNo { get; set; }
        public DateTime PassportExpiryDate { get; set; }
        public string LabourCardNo { get; set; }
        public DateTime LabourCardExpiryDate { get; set; }
        public string NoOfChildren { get; set; }
        public string BloodGroup { get; set; }
        public string BankAccNo { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public string Qualification { get; set; }
        public int YearOfPassing { get; set; }
        public string PercentageOfMarks { get; set; }
        public string University { get; set; }
        public decimal YearsOfExperience { get; set; }
        public string EmployeeStatus { get; set; }
        public Byte[] EmpPhoto { get; set; }
        public string SponsorName { get; set; }
        public string VisaNo { get; set; }
        public DateTime VisaExpiryDate { get; set; }
        public decimal AnnualLeaveMaturity { get; set; }

        public Employee()
        {

        }

        public Employee(int EmpId, string EmpCode, string EmpName, string FatherName, string Address, string PhoneNo, string Nationality, string Gender, string MaritalStatus, DateTime DateOfBirth, string PassportNo, DateTime PassportExpiryDate, string LabourCardNo, DateTime LabourCardExpiryDate, string NoOfChildren, string BloodGroup, string BankAccNo, string BankName, string BankBranch, string Qualification, int YearOfPassing, string PercentageOfMarks, string University, decimal YearsOfExperience, string EmployeeStatus, Byte[] EmpPhoto, string SponsorName, string VisaNo, DateTime VisaExpiryDate, decimal AnnualLeaveMaturity)
        {
            this.EmpId = EmpId;
            this.EmpCode = EmpCode;
            this.EmpName = EmpName;
            this.FatherName = FatherName;
            this.Address = Address;
            this.PhoneNo = PhoneNo;
            this.Nationality = Nationality;
            this.Gender = Gender;
            this.MaritalStatus = MaritalStatus;
            this.DateOfBirth = DateOfBirth;
            this.PassportNo = PassportNo;
            this.PassportExpiryDate = PassportExpiryDate;
            this.LabourCardNo = LabourCardNo;
            this.LabourCardExpiryDate = LabourCardExpiryDate;
            this.NoOfChildren = NoOfChildren;
            this.BloodGroup = BloodGroup;
            this.BankAccNo = BankAccNo;
            this.BankName = BankName;
            this.BankBranch = BankBranch;
            this.Qualification = Qualification;
            this.YearOfPassing = YearOfPassing;
            this.PercentageOfMarks = PercentageOfMarks;
            this.University = University;
            this.YearsOfExperience = YearsOfExperience;
            this.EmployeeStatus = EmployeeStatus;
            this.EmpPhoto = EmpPhoto;
            this.SponsorName = SponsorName;
            this.VisaNo = VisaNo;
            this.VisaExpiryDate = VisaExpiryDate;
            this.AnnualLeaveMaturity = AnnualLeaveMaturity;







        }
    }
}
