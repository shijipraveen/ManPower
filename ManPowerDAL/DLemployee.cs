using System;
using ManPowerModel;
using System.Data;
using System.Data.SqlClient;

namespace ManPowerDAL
{
    public class DLemployee
    {


        SqlConnection con = new SqlConnection(@"Data Source=tcp:laptop-002\sqlexpress,55331;Initial Catalog=dbManpower;Persist Security Info=True;User ID=sa;Password=admin@1234");
        public int AddEmployee(Employee emp)
        {
           
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                SqlCommand cmd = new SqlCommand("InsertEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpCode", emp.EmpCode);
                cmd.Parameters.AddWithValue("@EmpName", emp.EmpName);

                cmd.Parameters.AddWithValue("FatherName", emp.FatherName);
                cmd.Parameters.AddWithValue("@Address", emp.Address);
                cmd.Parameters.AddWithValue("@PhoneNo", emp.PhoneNo);
                cmd.Parameters.AddWithValue("@Nationality", emp.Nationality);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@MaritalStatus", emp.MaritalStatus);
                cmd.Parameters.AddWithValue("@DateOfBirth", emp.DateOfBirth);
                cmd.Parameters.AddWithValue("@PassportNo", emp.PassportNo);
                cmd.Parameters.AddWithValue("@PassportExpiryDate", emp.PassportExpiryDate);
                cmd.Parameters.AddWithValue("@LabourCardNo", emp.LabourCardNo);
                cmd.Parameters.AddWithValue("@LabourCardExpiryDate", emp.LabourCardExpiryDate);
                cmd.Parameters.AddWithValue("@NoOfChildren", emp.NoOfChildren);
                cmd.Parameters.AddWithValue("@BloodGroup", emp.BloodGroup);
                cmd.Parameters.AddWithValue("@BankAccNo", emp.BankAccNo);
                cmd.Parameters.AddWithValue("@BankName", emp.BankName);
                cmd.Parameters.AddWithValue("@BankBranch", emp.BankBranch);
                cmd.Parameters.AddWithValue("@Qualification", emp.Qualification);
                cmd.Parameters.AddWithValue("@YearOfPassing", emp.YearOfPassing);
                cmd.Parameters.AddWithValue("@PercentageOfMarks", emp.PercentageOfMarks);
                cmd.Parameters.AddWithValue("@University", emp.University);
                cmd.Parameters.AddWithValue("@YearsOfExperience", emp.YearsOfExperience);
                cmd.Parameters.AddWithValue("@EmployeeStatus", emp.EmployeeStatus);
                if(emp.EmpPhoto != null)
                    cmd.Parameters.AddWithValue("@EmpPhoto", emp.EmpPhoto);
                cmd.Parameters.AddWithValue("@SponsorName", emp.SponsorName);
                cmd.Parameters.AddWithValue("@VisaNo", emp.VisaNo);
                cmd.Parameters.AddWithValue("@VisaExpiryDate", emp.VisaExpiryDate);
                cmd.Parameters.AddWithValue("AnnualLeaveMaturity", emp.AnnualLeaveMaturity);
                cmd.Parameters.AddWithValue("@EmpId", 0).Direction = ParameterDirection.Output;
                int result = cmd.ExecuteNonQuery();
                if (result < 1)
                {


                    return -1; // No rows affected, insertion failed
                }

                int EmpId = Convert.ToInt32(cmd.Parameters["@EmpId"].Value);

                
                cmd.Dispose();
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            
        }

        public DataRow SelectEmployee(int EmpId)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("SelectEmployee", con);

                cmd.Parameters.AddWithValue("@EmpId", EmpId);




                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds, "res");
                cmd.Dispose();
                return ds.Tables["res"].Rows[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ds.Dispose();
            }
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }

        }
        public DataTable SelectEmployees()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("SelectEmployees", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds, "res");
                cmd.Dispose();
                return ds.Tables["res"];
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ds.Dispose();
            }
        }
        //public int DeleteEmployee(Employee emp)
        //{
        //    int result;
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("DeleteEmployee", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@EmpId", EmpId);
        //        if (con.State == ConnectionState.Closed)
        //        {
        //            con.Open();
        //        }
        //        result = cmd.ExecuteNonQuery();
        //        cmd.Dispose();
        //        if (result > 0)
        //        {
        //            return result;
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (con.State != ConnectionState.Closed)
        //        {
        //            con.Close();
        //        }
        //    }
        //}

        public DataRow DeleteEmployee(int EmpId)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("DeleteEmployee", con);

                cmd.Parameters.AddWithValue("@EmpId", EmpId);




                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds, "res");
                cmd.Dispose();
                return ds.Tables["res"].Rows[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ds.Dispose();
            }
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }

        }
        public int UpdateEmployee(Employee emp)
        {

            try
            {


                SqlCommand cmd = new SqlCommand("UpdateEmployee", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpCode", emp.EmpCode);
                cmd.Parameters.AddWithValue("@EmpName", emp.EmpName);
                cmd.Parameters.AddWithValue("FatherName", emp.FatherName);
                cmd.Parameters.AddWithValue("@Address", emp.Address);
                cmd.Parameters.AddWithValue("@PhoneNo", emp.PhoneNo);
                cmd.Parameters.AddWithValue("@Nationality", emp.Nationality);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@MaritalStatus", emp.MaritalStatus);
                cmd.Parameters.AddWithValue("@DateOfBirth", emp.DateOfBirth);
                cmd.Parameters.AddWithValue("@PassportNo", emp.PassportNo);
                cmd.Parameters.AddWithValue("@PassportExpiryDate", emp.PassportExpiryDate);
                cmd.Parameters.AddWithValue("@LabourCardNo", emp.LabourCardNo);
                cmd.Parameters.AddWithValue("@LabourCardExpiryDate", emp.LabourCardExpiryDate);
                cmd.Parameters.AddWithValue("@NoOfChildren", emp.NoOfChildren);
                cmd.Parameters.AddWithValue("@BloodGroup", emp.BloodGroup);
                cmd.Parameters.AddWithValue("@BankAccNo", emp.BankAccNo);
                cmd.Parameters.AddWithValue("@BankName", emp.BankName);
                cmd.Parameters.AddWithValue("@BankBranch", emp.BankBranch);
                cmd.Parameters.AddWithValue("@Qualification", emp.Qualification);
                cmd.Parameters.AddWithValue("@YearOfPassing", emp.YearOfPassing);
                cmd.Parameters.AddWithValue("@PercentageOfMarks", emp.PercentageOfMarks);
                cmd.Parameters.AddWithValue("@University", emp.University);
                cmd.Parameters.AddWithValue("@YearsOfExperience", emp.YearsOfExperience);
                cmd.Parameters.AddWithValue("@EmployeeStatus", emp.EmployeeStatus);
                if(emp.EmpPhoto != null)
                    cmd.Parameters.AddWithValue("@EmpPhoto", emp.EmpPhoto);
                cmd.Parameters.AddWithValue("@SponsorName", emp.SponsorName);
                cmd.Parameters.AddWithValue("@VisaNo", emp.VisaNo);
                cmd.Parameters.AddWithValue("@VisaExpiryDate", emp.VisaExpiryDate);
                cmd.Parameters.AddWithValue("AnnualLeaveMaturity", emp.AnnualLeaveMaturity);
                cmd.Parameters.AddWithValue("@EmpId", emp.EmpId);

                int result = cmd.ExecuteNonQuery();
                if (result < 1)

                    return -1; // No rows affected, insertion failed

                int EmpId = Convert.ToInt32(cmd.Parameters["@EmpId"].Value);

         
                cmd.Dispose();
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }



            // return Convert.ToInt32(cmd.Parameters["@EmpId"].Value);




        }

        }
           
        }
    

