using System;
using ManPowerDAL;
using ManPowerModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;



namespace ManPowerBLL
{
    public class BLcompany
    {
        public  Company SelectCompany()
        {
            DLcompany dlObj = new DLcompany();

            try
            {
                DataRow dr = dlObj.SelectCompany();
                if (dr != null)
                    return new Company(dr["CompanyName"].ToString(), dr["Address"].ToString(), dr["Phone"].ToString(), dr["Fax"].ToString(), dr["Mobile"].ToString(), dr["Email"].ToString(), dr["Website"].ToString(), dr["RegisterNo"].ToString(), dr["BarcodeHeading"].ToString(), dr["IncomeTaxNo"].ToString(), dr["Description"].ToString(), (dr["Logo"] == DBNull.Value ? null : (Byte[])dr["Logo"]), Convert.ToDateTime(dr["BookBeginningDate"]), Convert.ToDateTime(dr["CRexpiryDate"]));
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
        public int UpdateCompany(Company cmp)
        {
            DLcompany dlObj = new DLcompany();

            try
            {
                return dlObj.UpdateCompany(cmp);
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

        public string validateEmail(Company cmp)
        {
            string emailpattern = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            return (emailpattern);
          
        }
        public string validateWebsite(Company cmp)
        {
            string websitepattern = @"(\b(http | ftp | https):(\/\/|\\\\)[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=% &:/ ~\+#]*[\w\-\@?^=%&/~\+#])?|\bwww\.[^\s])";
            //string websitepattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            return (websitepattern);
        }

    }
}
