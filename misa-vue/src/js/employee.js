import Table from '../../lib/mtable.js';
window.onload = function () {
    // new EmployeePage();
    new Table();
};



class EmployeePage {
    ListEmployee;
    constructor() {
        this.intEvents();
        this.loadData();
    }
    /**
     * Load dữ liệu cho table
     * Author: NVMANH (23/02/2023)
     */
    loadData() {
        try {
            // gọi api thực hiện lấy dữ liệu:
            fetch("https://apidemo.laptrinhweb.edu.vn/api/v1/Employees")
                .then(res => res.json())
                .then(data => {
                    console.log(data);
                    this.ListEmployee = data;
                    // Build table:
                    this.buildDataTable(data);
                })

        } catch (error) {
            console.log(error);
        }
    }

    /**
     * Load dữ liệu cho table
     * Author: NVMANH (23/02/2023)
     */
    buildDataTable(data) {
        try {
            let table = document.getElementById("tbEmployeeList");
            let bodyTable = table.lastElementChild;

            // Duyệt các tiêu đề của table, đọc các thông tin được khai báo:
            let thList = table.getElementsByTagName("th");

            // Duyệt các đối tượng trong danh sách dữ liệu -> lấy ra các thông tin tương ứng và build tr...
            for (const item of data) {
                let trElement = document.createElement("tr");
                for (const col of thList) {
                    // Lấy ra type:
                    const type = col.getAttribute("type");
                    if (type == "checkbox") {
                        // checkbox
                        let tdCheckBox = document.createElement("td");
                        tdCheckBox.classList.add("text-align--left");
                        let checkElement = document.createElement("input");
                        checkElement.setAttribute("type", "checkbox");
                        tdCheckBox.append(checkElement);
                        trElement.append(tdCheckBox);
                    } else {
                        // Lấy ra model-name:
                        const modelName = col.getAttribute("model-name");
                        const value = item[modelName];
                        let tdElement = document.createElement("td");
                        tdElement.textContent = value;
                        trElement.append(tdElement);
                    }

                }
                bodyTable.append(trElement);
            }
            // Tạo từng dòng dữ liệu tương ứng từng đối tượng trong danh sách nhân viên, sau đó đẩy lên table:
            // 1. Duyệt từng đối tượng trong danh sách:
            // for (const item of this.ListEmployee) {
            //     for (const key in item) {
            //         if (Object.hasOwnProperty.call(item, key)) {
            //             const element = item[key];

            //         }
            //     }
            //     // 2. Lấy ra các thông tin cần thiết:
            //     const employeeCode = item.EmployeeCode;
            //     const fullName = item.FullName;
            //     const genderName = item.GenderName;
            //     const dob = item.DateOfBirth;
            //     const salary = item["Salary"];

            //     // 3. Build html thể hiện các thông tin trên table

            //     let trElement = document.createElement("tr");

            //     // checkbox
            //     let tdCheckBox = document.createElement("td");
            //     tdCheckBox.classList.add("text-align--left");
            //     let checkElement = document.createElement("input");
            //     checkElement.setAttribute("type", "checkbox");
            //     tdCheckBox.append(checkElement);

            //     trElement.append(tdCheckBox);

            //     // Mã nhân viên
            //     trElement.append(this.buildTdElement(employeeCode));

            //     // Họ và tên
            //     trElement.append(this.buildTdElement(fullName));

            //     // Giới tính: --> căn trái
            //     trElement.append(this.buildTdElement(genderName));

            //     // Ngày sinh: ---> căn giữa
            //     trElement.append(this.buildTdElement(dob,"text-align--center",1));

            //     // Mức lương: --> căn phải
            //     trElement.append(this.buildTdElement(salary,"text-align--right",2));

            //     // 4. Đẩy vào table:
            //     // Xác định vị trí append vào table:
            //     bodyTable.append(trElement);
            // }
        } catch (error) {
            console.log(error);
        }
    }

    buildTdElement(value, className = "text-align--left", formatType) {
        let tdElement = document.createElement("td");
        try {
            tdElement.classList.add(className);
            // Định dạng dữ liệu:
            switch (formatType) {
                case 1:
                    // Định dạng ngày tháng:
                    value = this.formatDate(value);
                    break;
                case 2:
                    // Định dạng tiền:
                    value = this.formatMoney(value);
                    break;

                default:
                    break;
            }
            tdElement.textContent = value;
            return tdElement;
        } catch (error) {
            return tdElement;
        }
    }
    formatDate(date) {
        try {
            date = new Date(date);
            // Lấy ra ngày:
            let dateValue = date.getDate();
            // Lấy ra tháng:
            let month = date.getMonth() + 1;
            // Lấy ra năm:
            let year = date.getFullYear();
            return `${dateValue}/${month}/${year}`;
        } catch (error) {
            return "";
        }
    }
    formatMoney(money) {
        try {

        } catch (error) {
            return "";
        }
    }
    intEvents() {

    }
}

function createEvents() {
    try {
        document.getElementById("btnCancel").addEventListener("click", onCloseFormDetail);
        document.querySelectorAll("div [required]").forEach(function (el) {
            el.addEventListener("blur", onValidateFiedEmpty);
        })
        // document.getElementsByClassName("input--required")
    } catch (error) {
        console.log(error);
    }
}

/**
 * 
 */
function onValidateFiedEmpty() {
    try {
        // Lấy ra value trong input vừa nhâp:
        let input = this;
        console.log(this);
        const value = input.value;
        let elErrorInfo = this.nextElementSibling;
        // Kiểm tra value có trống hay không?
        if (value.trim() == "".trim() || value == null || value == undefined) {
            // Nếu dữ liệu trống thì hiển thị thông báo lỗi.
            console.log("Dữ liệu mã nhân viên không được phép trống!");
            // Gán border có màu đỏ:
            // input.style.borderColor = "red";
            input.classList.add("input--error");
            // Hiển thị thông tin lỗi:
            // 1. Lấy ra element thông tin lỗi:
            // 2. Đặt hiển thị hoặc thêm phần hiển thị thông tin lỗi:
            // elErrorInfo.style.display = 'block';

            // Kiểm tra xem đã có element thông tin lỗi chưa?
            let elErrorExits = this.nextElementSibling;
            debugger
            if (elErrorExits == null) {
                // Tạo element thông tin lỗi:
                let elError = document.createElement("div");
                elError.classList.add("error-info");
                elError.textContent = "Mã nhân viên không được phép trống.";
                // Sử dụng element cha của input và append:
                this.parentElement.append(elError);
            }

        } else {
            console.log("OK!");
            // Bỏ border có màu đỏ:
            //  input.style.borderColor = "#50B83C";
            input.classList.remove("input--error");
            //  elErrorInfo.style.display = 'none';
            let elErrorExits = this.nextElementSibling;
            debugger
            if (elErrorExits != null) {
                elErrorExits.remove();
            }
        }

    } catch (error) {

    }
}


function loadData() {
    console.log("Gọi api load data!");;
}


function btnAddOnClick() {
    // Hiển thị form thêm mới:
    document.getElementById("frmDetail").style.display = "block";
}


function onCloseFormDetail() {
    document.getElementById("frmDetail").style.display = "none";
}