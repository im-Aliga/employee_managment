using EmployeeManagment_.Utilities;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagment_.ViewModels
{
    public class EmployeeUpdateViewModel
    {
        public string EmployeeCode { get; set; }

        [RegularExpression(@"[A-Za-z]{3,20}")]
        public string EmployeeName { get; set; }

        [RegularExpression(@"[A-Za-z]{3,20}")]
        public string EmployeeLastname { get; set; }

        [RegularExpression(@"[A-Za-z]{3,20}")]
        public string EmployeeFathername { get; set; }
        [ValidFinAtributie]
        public string FinCode { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public EmployeeUpdateViewModel()
        {

        }

        public EmployeeUpdateViewModel(string employeeCode, string employeeName, string employeeLastname, string employeeFathername, string finCode, string email)
        {
            EmployeeCode=employeeCode;
            EmployeeName = employeeName;
            EmployeeLastname = employeeLastname;
            EmployeeFathername = employeeFathername;
            FinCode = finCode;
            Email = email;
        }

    }
}
