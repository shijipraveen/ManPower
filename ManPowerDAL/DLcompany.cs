using System;
using ManPowerModel;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ManPowerDAL
{
    public class DLcompany
    {
        
        int result;
        SqlConnection con = new SqlConnection("Data Source=tcp:laptop-002\\sqlexpress,55331;Initial Catalog=dbManpower;User ID=sa;password = admin@1234");

        public DataRow SelectCompany()
        {
            DataSet ds = new DataSet();

            try
            {
                SqlCommand cmd = new SqlCommand("SelectCompany", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds, "res");
                cmd.Dispose();
                return ds.Tables[0].Rows[0];
            }

            catch //(Exception ex)
            {
                throw;
            }
            finally
            {
                ds.Dispose();
            }

        }


        public int UpdateCompany(Company cmp)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("UpdateCompany", con);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CompanyName", cmp.CompanyName);
                cmd.Parameters.AddWithValue("@Address", cmp.Address);
                cmd.Parameters.AddWithValue("@Phone", cmp.Phone);
                cmd.Parameters.AddWithValue("@Fax", cmp.Fax);
                cmd.Parameters.AddWithValue("@Mobile", cmp.Mobile);
                cmd.Parameters.AddWithValue("@Email", cmp.Email);
                cmd.Parameters.AddWithValue("@Website", cmp.Website);
                cmd.Parameters.AddWithValue("@RegisterNo", cmp.RegisterNo);
                cmd.Parameters.AddWithValue("@BarcodeHeading", cmp.BarcodeHeading);
                cmd.Parameters.AddWithValue("@IncomeTaxNo", cmp.IncomeTaxNo);
                cmd.Parameters.AddWithValue("@Description", cmp.Description);
                cmd.Parameters.AddWithValue("@Logo", cmp.logo);
                cmd.Parameters.AddWithValue("@BookBeginningDate", cmp.BookBeginningDate);
                cmd.Parameters.AddWithValue("@CRexpiryDate", cmp.CRexpiryDate);
                

                result = cmd.ExecuteNonQuery();
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

    }
}
