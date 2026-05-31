using System;
using AddressBookApp.VO;

namespace AddressBookApp.UIW.VM
{
    public class AddressViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }

        public string Department { get; set; }
        public string Status { get; set; }
        public string Skills { get; set; }
        public string MaritalStatus { get; set; }

        public static AddressViewModel FromVO(AddressVO vo)
        {
            if (vo == null) return null;
            return new AddressViewModel
            {
                Id = vo.Id,
                FullName = vo.FullName,
                Phone = vo.Phone,
                Email = vo.Email,
                Gender = vo.Gender,
                DOB = vo.DOB,
                Age = vo.Age,
                Address = vo.Address,
                City = vo.City,
                Pincode = vo.Pincode,
                Department = vo.Department,
                Status = vo.Status,
                Skills = vo.Skills,
                MaritalStatus = vo.MaritalStatus
            };
        }

        public AddressVO ToVO()
        {
            return new AddressVO
            {
                Id = this.Id,
                FullName = this.FullName,
                Phone = this.Phone,
                Email = this.Email,
                Gender = this.Gender,
                DOB = this.DOB,
                Age = this.Age,
                Address = this.Address,
                City = this.City,
                Pincode = this.Pincode,
                CreatedAt = DateTime.UtcNow,
                Department = this.Department,
                Status = this.Status,
                Skills = this.Skills,
                MaritalStatus = this.MaritalStatus
            };
        }
    }
}
