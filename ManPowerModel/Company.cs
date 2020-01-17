using System;
using System.Collections.Generic;
using System.Text;

namespace ManPowerModel
{
    public class Company
    {
       
            public String CompanyName { get; set; }
            public String Address { get; set; }
            public String Phone { get; set; }
            public String Fax { get; set; }
            public String Mobile { get; set; }
            public String Email { get; set; }
            public String Website { get; set; }
            public String RegisterNo { get; set; }
            public String BarcodeHeading { get; set; }
            public String IncomeTaxNo { get; set; }
            public String Description { get; set; }
            public Byte[] logo { get; set; }
            public DateTime BookBeginningDate { get; set; }
            public DateTime CRexpiryDate { get; set; }
            public Company()
            {

            }
            public Company(string CompanyName, string Address, string Phone, string Fax, string Mobile, string Email, string Website, string RegisterNo, string BarcodeHeading, string IncomeTaxNo, string Description, Byte[] logo, DateTime BookBeginningDate, DateTime CRexpiryDate)
            {
                this.CompanyName = CompanyName;
                this.Address = Address;
                this.Phone = Phone;
                this.Fax = Fax;
                this.Mobile = Mobile;
                this.Email = Email;
                this.Website = Website;
                this.RegisterNo = RegisterNo;
                this.BarcodeHeading = BarcodeHeading;
                this.IncomeTaxNo = IncomeTaxNo;
                this.Description = Description;
                this.logo = logo;
                this.BookBeginningDate = BookBeginningDate;
                this.CRexpiryDate = CRexpiryDate;
            }



        }
    }
