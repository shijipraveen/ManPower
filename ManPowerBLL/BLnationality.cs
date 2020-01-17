using System;
using System.Collections;
using System.Collections.Generic;
using ManPowerModel;
using ManPowerDAL;
using System.Data;



namespace ManPowerBLL
{
    public class BLnationality
    {
        DLnationality dlObj = new DLnationality();
        

        public int InsertNationality(Nationality Nat)
        {
            try
            {
                return dlObj.InsertNationality(Nat);
                //return dlObj.AddNationality(Nat.CountryName, Nat.CountryCode);
            }
            catch //(Exception ex)
            {
                throw;
            }
            finally
            {
                dlObj = null;
            }
        }


        public List<Nationality> SelectNationalities()
        {
            try
            {
                DataTable dt = dlObj.SelectNationalities();

                if (dt != null)
                {
                    List<Nationality> lst = new List<Nationality>();

                    foreach (DataRow dr in dt.Rows)

                        lst.Add(new Nationality(dr["CountryName"].ToString(), dr["CountryCode"].ToString()));

                    return lst;
                }
                else
                    return null;
            }
            catch// (Exception ex)
            {
                throw;
            }
            finally
            {
                dlObj = null;
            }
        }

        public Nationality SelectNationality(string CountryName)
        {
            try
            {
                DataRow dr = dlObj.SelectNationality(CountryName);

                if (dr != null)
                    return new Nationality(dr["CountryName"].ToString(), dr["CountryCode"].ToString());
                else
                    return null;
            }
            catch //(Exception ex)
            {
                throw;
            }
            finally
            {
                dlObj = null;
            }
        }
        public string Validate(Nationality nationality)
        {
            string errorMessage = "";

            if (nationality.CountryName == "")
                errorMessage = errorMessage + "Please enter a country name";
            
            if(nationality.CountryName.Length > 50)
                errorMessage = errorMessage + "\nMaximum length of country name is 50 characters";

            if (nationality.CountryCode.Length > 5)
                return "\nMaximum length of country code is 5 characters";

            return errorMessage;
            
           
        }
        public int UpdateNationality(string OldCountryName, Nationality Nat)
        {

            try
            {
                
                return dlObj.UpdateNationality(OldCountryName, Nat);
            }
            catch// (Exception ex)
            {
                throw;
            }
            finally
            {
                dlObj = null;
            }
        }
        public int DeleteNationality(string CountryName)
        {
            try
            {
                return dlObj.DeleteNationality(CountryName);
            }
            catch //(Exception ex)
            {
                throw;
            }
            finally
            {
                dlObj = null;
            }
        }
    }
}
