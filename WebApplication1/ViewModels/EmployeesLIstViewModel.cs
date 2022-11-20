namespace EmployeeManagment_.ViewModels
{
    public class EmployeesLIstViewModel
    {
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastname { get; set; }
        public string EmployeeFathername { get; set; }
        public bool IsDeleted { get; set; }

        public EmployeesLIstViewModel(bool isDeleted, string employeeCode, string employeeName, string employeeLastname, string employeeFathername)
        {

            IsDeleted=isDeleted;    
            EmployeeCode = employeeCode;
            EmployeeName = employeeName;
            EmployeeLastname = employeeLastname;
            EmployeeFathername = employeeFathername;
        }
        
    }
}
