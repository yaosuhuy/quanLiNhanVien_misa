using Demo.WebApplication.API.Enums;

namespace Demo.WebApplication.API.Entities.DTO
{
    public class CreateEmployee
    {
       

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        public string EmployeeFullName { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public Gender EmployeeGender { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime EmployeeDateOfBirth { get; set; }

        /// <summary>
        /// Chức vụ
        /// </summary>
        public string EmployeePositionName { get; set; }

        /// <summary>
        /// Id phòng ban
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Số cmtnd
        /// </summary>
        public string EmployeeIdCard { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string EmployeeAddress { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string EmployeePhoneNumber { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string EmployeeEmail { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
       
    }
}
