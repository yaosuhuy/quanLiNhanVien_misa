using Microsoft.AspNetCore.Authentication;
using Demo.WebApplication.API.Enums;
namespace Demo.WebApplication.API.Entities
{
    /// <summary>
    /// Thông tin nhân viên
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Id nhân viên / Khóa chính
        /// </summary>
        public Guid EmployeeId { get; set; }

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
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Tạo bởi
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày sửa đổi
        /// </summary>
        public DateTime ModifiedDate { get; set;}

        /// <summary>
        /// Sửa đổi bởi
        /// </summary>
        public string ModifiedBy { get; set;}
        /*
        public Guid EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public string FullName { get; set; }
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime DateIdentityNumber { get; set; }
        public string PlaceIdentityNumber { get; set; }
        public string PositionName { get; set; }
        public string BankNumber { get; set; }
        public string BankName { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        // public string DepartmentId { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Tạo bởi
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày sửa đổi
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Sửa đổi bởi
        /// </summary>
        public string ModifiedBy { get; set; }
        */
    }
}
