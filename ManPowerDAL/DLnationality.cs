using System;
using System.Data.SqlClient;
using ManPowerModel;
using System.Data;

namespace ManPowerDAL
{
    public class DLnationality
    {

        SqlConnection con = new SqlConnection(@"Data Source=tcp:laptop-002\sqlexpress,55331;Initial Catalog=dbManpower;User ID=sa; password=admin@1234");
        public int InsertNationality(Nationality Nat)
        {
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "InsertNationality";  /* Stored Procedure name */
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                ///* Getting value from property and passing it to parameters declared in Stored Procedure. */
                cmd.Parameters.AddWithValue("@CountryName", Nat.CountryName);
                cmd.Parameters.AddWithValue("@CountryCode", Nat.CountryCode);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
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
            catch //(Exception ex)
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

        //public int AddNationality(string CountryName,  string CountryCode)
        //{
        //    int result;
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandText = "InsertNationality";  /* Stored Procedure name */
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Connection = con;

        //        ///* Getting value from property and passing it to parameters declared in Stored Procedure. */
        //        cmd.Parameters.AddWithValue("@CountryName", CountryName);
        //        cmd.Parameters.AddWithValue("@CountryCode", CountryCode);

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

        public DataTable SelectNationalities()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("SelectNationalities", con);
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
            catch //(Exception ex)
            {
                throw;
            }
            finally
            {
                ds.Dispose();
            }
        }



        public DataRow SelectNationality(string CountryName)
        {

            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("SelectNationality", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CountryName", CountryName);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
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

        public int UpdateNationality(string OldCountryName, Nationality Nat)
        {
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UpdateNationality";  /* Stored Procedure name */
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@OldCountryName", OldCountryName);
                cmd.Parameters.AddWithValue("@CountryName", Nat.CountryName);
                cmd.Parameters.AddWithValue("@CountryCode", Nat.CountryCode);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
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
            catch //(Exception ex)
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

        public Int32 DeleteNationality(string CountryName)
        {
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand("DeleteNationality", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CountryName", CountryName);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
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
            catch //(Exception ex)
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
