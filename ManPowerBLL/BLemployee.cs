using System;
using ManPowerModel;
using ManPowerDAL;
using System.Data;

namespace ManPowerBLL
{
    public class BLemployee
    {
        DLemployee dlObj = new DLemployee();
        public int AddEmployee(Employee emp)
        {

            try
            {
                return dlObj.AddEmployee(emp);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                dlObj = null;
            }

        }
        public Employee SelectEmployee(int EmpId)
        {
            try
            {

                DataRow dr = dlObj.SelectEmployee(EmpId);
                if (dr != null)
                    return new Employee(Convert.ToInt32(dr["EmpId"]), dr["EmpCode"].ToString(), dr["EmpName"].ToString(), dr["FatherName"].ToString(), dr["Address"].ToString(), dr["PhoneNo"].ToString(), dr["Nationality"].ToString(), dr["Gender"].ToString(), dr["MaritalStatus"].ToString(), Convert.ToDateTime(dr["DateOfBirth"]), dr["PassportNo"].ToString(), Convert.ToDateTime(dr["PassportExpiryDate"]), dr["LabourCardNo"].ToString(), Convert.ToDateTime(dr["LabourCardExpiryDate"]), dr["NoOfChildren"].ToString(), dr["BloodGroup"].ToString(), dr["BankAccNo"].ToString(), dr["BankName"].ToString(), dr["BankBranch"].ToString(), dr["Qualification"].ToString(), Convert.ToInt32(dr["YearOfPassing"]), dr["PercentageOfMarks"].ToString(), dr["University"].ToString(),Convert.ToDecimal( dr["YearsOfExperience"]),dr["EmployeeStatus"].ToString(),(dr["EmpPhoto"] == DBNull.Value ? null : (Byte[])dr["EmpPhoto"]), dr["SponsorName"].ToString(), dr["VisaNo"].ToString(), Convert.ToDateTime(dr["VisaExpiryDate"]), Convert.ToDecimal(dr["AnnualLeaveMaturity"])); 
                else
                    return null;

            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
        public DataTable SelectEmployees()
        {
            try
            {
                return dlObj.SelectEmployees();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                dlObj = null;
            }
        }
       

        public void DeleteEmployee(int EmpId)
        {
            try
            {
               dlObj.DeleteEmployee(EmpId);
            }
            catch
            {

            }
        }
            public int UpdateEmployee(Employee emp)
        {
            try
            {
                return dlObj.UpdateEmployee(emp);
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }
    }
}
