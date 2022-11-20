using EmployeeManagment_.Utilities;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagment_.ViewModels
{
    public class EmployeeAddViewModel
    {
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

        public EmployeeAddViewModel()
        {
                
        }

        public EmployeeAddViewModel(string employeeName, string employeeLastname, string employeeFathername, string finCode, string email)
        {
            EmployeeName = employeeName;
            EmployeeLastname = employeeLastname;
            EmployeeFathername = employeeFathername;
            FinCode = finCode;
            Email = email;
        }
    }
}
