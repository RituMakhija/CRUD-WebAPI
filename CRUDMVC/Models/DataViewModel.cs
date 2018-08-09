using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDMVC.Models
{
    public class DataViewModel
    {       
        public int SlNo { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public DetailViewModel Detail { get; set; }     
    }

    public class DetailViewModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string EmailID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Department { get; set; }
        public string TenthBoard { get; set; }
        public Nullable<int> TenthMarks { get; set; }
        public string TwelfthBoard { get; set; }
        public Nullable<int> TwelfthMarks { get; set; }

        public ICollection<DataViewModel> Students { get; set; }
    }
}