using System.Text.RegularExpressions;

namespace AddressBookApp.UIW.VM.EX
{
    public static class AddressViewModelExtensions
    {
        public static (bool, string) Validate(this AddressViewModel vm)
        {
            if (vm == null) return (false, "invalid-data");
            if (string.IsNullOrWhiteSpace(vm.FullName)) return (false, "fullname-required");
            if (string.IsNullOrWhiteSpace(vm.Phone)) return (false, "phone-required");
            string digits = Regex.Replace(vm.Phone, @"\D", "");
            if (digits.Length < 7) return (false, "phone-invalid");
            if (vm.DOB == default) return (false, "dob-required");
            int age = CalculateAge(vm.DOB);
            if (age < 0) return (false, "dob-invalid");
            return (true, "");
        }

        public static int CalculateAge(DateTime dob)
        {
            DateTime today = DateTime.UtcNow.Date;
            int age = today.Year - dob.Year;
            if (today.Month < dob.Month || (today.Month == dob.Month && today.Day < dob.Day)) age--;
            return age;
        }

        public static void UpdateAge(this AddressViewModel vm)
        {
            vm.Age = CalculateAge(vm.DOB);
        }
    }
}
