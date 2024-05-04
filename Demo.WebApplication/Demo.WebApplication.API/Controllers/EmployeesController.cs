using Demo.WebApplication.API.Entities;
using Demo.WebApplication.API.Entities.DTO;
using Demo.WebApplication.API.Enums;
using Demo.WebApplication.API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using MySqlConnector;
using System.Reflection;


namespace Demo.WebApplication.API.Controllers
{
    [Route("api/[controller]")] //Attribute
    [ApiController]
    public class EmployeesController : ControllerBase // kế thừa
    {
        /// <summary>
        /// API lấy thông tin chi tiết 1 nhân viên
        /// </summary>
        /// <param name="employeeId"> ID nhân viên muốn lấy </param>
        /// <returns></returns>
        /// Created by: LVQHUY (19/04/2023)
        [HttpGet("{employeeId}")] // Gọi theo url
        public IActionResult GetEmployeeById([FromRoute] Guid employeeId)
        {
            // Chuẩn bị tên stored
            try

            {
                string storedProcedureName = "Proc_Employee_GetByID";

                // Chuẩn bị tham số đầu vào
                var parameters = new DynamicParameters();
                parameters.Add("v_EmployeeID", employeeId);

                // Khởi tạo kết nối tới DB
                string connectionString = "Server=18.179.16.166;Port=3306;Database=MISA.HOU2023_LVQHUY;Uid=nvmanh;Pwd=12345678;";
                var mySqlConnection = new MySqlConnection(connectionString);

                // Thực hiện câu lệnh sql
                var employee = mySqlConnection.QueryFirstOrDefault<Employee>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                // Xử lí kết quả trả về

                // Thành công
                if (employee != null)
                {
                    return StatusCode(200, employee);
                }
                // Thất bại
                else
                {
                    return NotFound();
                }
            }


            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return StatusCode(500, new ErrorResult
                {
                    ErrorCode = Enums.ErrorCode.Exception,
                    DevMsg = Resource.DevMsg_Exception,
                    UserMsg = Resource.UserMsg_Exception,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
            // try catch

        }

        /// <summary>
        /// API lấy thông tin chi tiết 1 nhân viên
        /// </summary>
        /// <returns></returns>
        /// Created by: LVQHUY (19/04/2023)
        [HttpGet] // Gọi theo url
        public IActionResult GetEmployee()
        {
            try
            {
                // Chuẩn bị tên stored
                string storedProcedureName = "Proc_Employee_GetAll";
                //string storedProcedureName = "Proc_employee_GetAll";
                // Chuẩn bị tham số đầu vào

                // Khởi tạo kết nối tới DB
                string connectionString = "Server=18.179.16.166;Port=3306;Database=MISA.HOU2023_LVQHUY ;Uid=nvmanh;Pwd=12345678;";
                var mySqlConnection = new MySqlConnection(connectionString);

                // Thực hiện câu lệnh sql
                var employee = mySqlConnection.Query<Employee>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);

                // Xử lí kết quả trả về

                // Thành công
                if (employee != null)
                {
                    return StatusCode(200, employee);
                }
                // Thất bại
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return StatusCode(500, new ErrorResult
                {
                    ErrorCode = Enums.ErrorCode.Exception,
                    DevMsg = Resource.DevMsg_Exception,
                    UserMsg = Resource.UserMsg_Exception,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
            // try catch
        }

        [HttpDelete("{employeeId}")]
        public IActionResult DeleteEmployee([FromRoute] Guid employeeId)
        {
            // Chuẩn bị tên stored
            try
            {
                string storedProcedureFind = "Proc_Employee_GetByID";
                // Chuẩn bị tham số đầu vào
                var parameters = new DynamicParameters();
                parameters.Add("v_EmployeeID", employeeId);
                // Khởi tạo kết nối tới DB
                string connectionString = "Server=18.179.16.166;Port=3306;Database=MISA.HOU2023_LVQHUY;Uid=nvmanh;Pwd=12345678;";
                var mySqlConnection = new MySqlConnection(connectionString);
                // Thực hiện câu lệnh sql
                var employee = mySqlConnection.QueryFirstOrDefault<Employee>(storedProcedureFind, parameters, commandType: System.Data.CommandType.StoredProcedure);

                // Chuẩn bị stored thứ hai để xóa
                string storedProcedureDelete = "Proc_Employee_Delete";
                // Chuẩn bị tham số đầu vào
                var parametersDelete = new DynamicParameters();
                parametersDelete.Add("v_EmployeeID", employee.EmployeeId);
                var employeeDelete = mySqlConnection.QueryFirstOrDefault<Employee>(storedProcedureDelete, parametersDelete, commandType: System.Data.CommandType.StoredProcedure);
                // Xử lí kết quả trả về
                // Thành công
                if (employee != null)
                {
                    return StatusCode(200, employee);
                }
                // Thất bại
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new ErrorResult
                {
                    ErrorCode = Enums.ErrorCode.Exception,
                    DevMsg = Resource.DevMsg_Exception,
                    UserMsg = Resource.UserMsg_Exception,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }


        /*
        [HttpGet]
        public IActionResult GetPaging(
            [FromQuery] string? keyword,
            [FromQuery] Guid? departmentId,
            [FromQuery] Guid? positionId,
            [FromQuery] int pageSize = 10, //?: nullable
            [FromQuery] int pageNumber = 1
        )
        {
            return StatusCode(200, new PagingResult
            {
                Data = new List<Employee>()
            {
                new Employee {
                EmployeeId = Guid.NewGuid(),
                EmployeeCode = "NV001",
                EmployeeFullName = "HUY",
                EmployeeGender = Enums.Gender.Male,
                EmployeeDateOfBirth = DateTime.Now,
                CreatedDate = DateTime.Now,
                CreatedBy = "admin",
                ModifiedDate = DateTime.Now,
                ModifiedBy = "admin"
                },

                new Employee {
                EmployeeId = Guid.NewGuid(),
                EmployeeCode = "NV002",
                EmployeeFullName = "HUYEN",
                EmployeeGender = Enums.Gender.Female,
                EmployeeDateOfBirth = DateTime.Now,
                CreatedDate = DateTime.Now,
                CreatedBy = "admin",
                ModifiedDate = DateTime.Now,
                ModifiedBy = "admin"
                },
            },
                TotalRecord = 2
            });
        }
        */

        /// <summary>
        /// Thêm nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// Created by: LVQHUY (19/04/2022)
        [HttpPost]
        public IActionResult InsertEmployee([FromBody] CreateEmployee employeeInfo)
        {
            try
            {
                // Chuẩn bị tên stored
                string storedProcedureCreate = "Proc_Employee_Create";
                // Chuẩn bị tham số đầu vào
                var parameters = new DynamicParameters();
                parameters.Add("v_EmployeeCode", employeeInfo.EmployeeCode);
                parameters.Add("v_EmployeeFullName", employeeInfo.EmployeeFullName);
                parameters.Add("v_EmployeeGender", employeeInfo.EmployeeGender);
                parameters.Add("v_EmployeeDateOfBirth", employeeInfo.EmployeeDateOfBirth);
                parameters.Add("v_EmployeePositionName", employeeInfo.EmployeePositionName);
                parameters.Add("v_DepartmentId", employeeInfo.DepartmentId);
                parameters.Add("v_EmployeeIDCard", employeeInfo.EmployeeIdCard);
                parameters.Add("v_EmployeeAddress", employeeInfo.EmployeeAddress);
                parameters.Add("v_EmployeePhoneNumber", employeeInfo.EmployeePhoneNumber);
                parameters.Add("v_EmployeeEmail", employeeInfo.EmployeeEmail);

                // Khởi tạo kết nối tới DB
                string connectionString = "Server=18.179.16.166;Port=3306;Database=MISA.HOU2023_LVQHUY;Uid=nvmanh;Pwd=12345678;";
                var mySqlConnection = new MySqlConnection(connectionString);
                // Thực hiện câu lệnh sql
                var employee = mySqlConnection.Query<CreateEmployee>(storedProcedureCreate, parameters, commandType: System.Data.CommandType.StoredProcedure);

                // Xử lí kết quả trả về
                // Thành công
                if (employee != null)
                {
                    return StatusCode(200, employee);
                }
                // Thất bại
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new ErrorResult
                {
                    ErrorCode = Enums.ErrorCode.Exception,
                    DevMsg = Resource.DevMsg_Exception,
                    UserMsg = Resource.UserMsg_Exception,
                    TraceId = HttpContext.TraceIdentifier,
                    MoreInfo = ex.Message
                });
            }
        }

        [HttpPut("{employeeId}")]
        public IActionResult UpdateEmployee([FromBody] Employee employeeInfo)
        {
            try
            {
                // chuẩn bị stored procedure thứ hai để update
                string storedProcedureUpdate = "Proc_Employee_Update";
                // cbi tham số đầu vào
                var parametersUpdate = new DynamicParameters();
                parametersUpdate.Add("v_EmployeeID", employeeInfo.EmployeeId);
                parametersUpdate.Add("v_EmployeeCode", employeeInfo.EmployeeCode);
                parametersUpdate.Add("v_EmployeeFullName", employeeInfo.EmployeeFullName);
                parametersUpdate.Add("v_EmployeeGender", employeeInfo.EmployeeGender);
                parametersUpdate.Add("v_EmployeeDateOfBirth", employeeInfo.EmployeeDateOfBirth);
                parametersUpdate.Add("v_EmployeePositionName", employeeInfo.EmployeePositionName);
                parametersUpdate.Add("v_DepartmentId", employeeInfo.DepartmentId);
                parametersUpdate.Add("v_EmployeeIDCard", employeeInfo.EmployeeIdCard);
                parametersUpdate.Add("v_EmployeeAddress", employeeInfo.EmployeeAddress);
                parametersUpdate.Add("v_EmployeePhoneNumber", employeeInfo.EmployeePhoneNumber);
                parametersUpdate.Add("v_EmployeeEmail", employeeInfo.EmployeeEmail);

                string connectionString = "Server=18.179.16.166;Port=3306;Database=MISA.HOU2023_LVQHUY;Uid=nvmanh;Pwd=12345678;";
                var mySqlConnection = new MySqlConnection(connectionString);

                var employeeUpdate = mySqlConnection.QueryFirstOrDefault<Employee>(storedProcedureUpdate, parametersUpdate, commandType: System.Data.CommandType.StoredProcedure);
                // Xử lí kết quả trả về
                // Thành công

                
                if (employeeInfo != null)
                {
                    return StatusCode(200, employeeInfo);
                }
                // Thất bại
                else
                {
                    return NotFound();
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new ErrorResult
                {
                    ErrorCode = Enums.ErrorCode.Exception,
                    DevMsg = Resource.DevMsg_Exception,
                    UserMsg = Resource.UserMsg_Exception,
                    TraceId = HttpContext.TraceIdentifier,
                    MoreInfo = ex.Message
                });
            }
        }
    }
}
