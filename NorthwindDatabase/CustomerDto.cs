using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDatabase
{
    [Serializable()]
    public class CustomerDto : ISerializable
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string EmailAddress { get; set; }
        public string JobTitle { get; set; }
        public string BusinessPhone { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string FaxNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string ZipPostalCode { get; set; }
        public string CountryRegion { get; set; }
        public string WebPage { get; set; }
        public string Notes { get; set; }
        public byte[] Attachments { get; set; }

        public CustomerDto() { }

        public CustomerDto(SerializationInfo info, StreamingContext context)
        {
            Id = (int)info.GetValue("Id", typeof(int));
            Company = (string)info.GetValue("CusLName", typeof(string));
            LastName = (string)info.GetValue("LastName", typeof(string));
            FirstName = (string)info.GetValue("FirstName", typeof(string));
            EmailAddress = (string)info.GetValue("EmailAddress", typeof(string));
            JobTitle = (string)info.GetValue("JobTitle", typeof(string));
            BusinessPhone = (string)info.GetValue("BusinessPhone", typeof(string));
            HomePhone = (string)info.GetValue("HomePhone", typeof(string));
            MobilePhone = (string)info.GetValue("MobilePhone", typeof(string));
            FaxNumber = (string)info.GetValue("FaxNumber", typeof(string));
            Address = (string)info.GetValue("Address", typeof(string));
            City = (string)info.GetValue("City", typeof(string));
            StateProvince = (string)info.GetValue("StateProvince", typeof(string));
            ZipPostalCode = (string)info.GetValue("ZipPostalCode", typeof(string));
            CountryRegion = (string)info.GetValue("CountryRegion", typeof(string));
            WebPage = (string)info.GetValue("WebPage", typeof(string));
            Notes = (string)info.GetValue("Notes", typeof(string));
            Attachments = (byte[])info.GetValue("Attachments", typeof(byte[]));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("Company", Company);
            info.AddValue("LastName", LastName);
            info.AddValue("FirstName", FirstName);
            info.AddValue("EmailAddress", EmailAddress);
            info.AddValue("JobTitle", JobTitle);
            info.AddValue("BusinessPhone", BusinessPhone);
            info.AddValue("HomePhone", HomePhone);
            info.AddValue("MobilePhone", MobilePhone);
            info.AddValue("FaxNumber", FaxNumber);
            info.AddValue("Address", Address);
            info.AddValue("City", City);
            info.AddValue("StateProvince", StateProvince);
            info.AddValue("ZipPostalCode", ZipPostalCode);
            info.AddValue("CountryRegion", CountryRegion);
            info.AddValue("WebPage", WebPage);
            info.AddValue("Notes", Notes);
            info.AddValue("Attachments", Attachments);
        }
    }
}
