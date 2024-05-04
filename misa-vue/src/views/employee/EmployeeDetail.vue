<template lang="">
    <!-- Form chi tiết -->
    <div id="popup-employee-detail" class="popup">
      <form class="popup-container" @submit.prevent = "saveEmployee()">
        <div id="btn-close" class="popup__button" @click="btnCloseOnClick">
          <i class="icofont-close"></i>
        </div>
        <div class="popup__header">
          <div class="popup__title">Thông tin nhân viên</div>
        </div>
        <div id="popup-detail" class="popup__content">
          <div class="form-row">
            <div class="form-group">
              <div class="m-row">
                <div class="m-col">
                  <div class="input-wrapper" style="width: 175px">
                    <!-- <label class="input__label" for="txtEmployeeCode"
                      >Mã nhân viên <span class="required">*</span>:</label
                    > -->
                    <m-input label = "Mã nhân viên" typeInput ="text" v-model = "employee.employeeCode" :required = "true"></m-input>
                    <!-- <input
                      id="txtEmployeeCode"
                      property-name="EmployeeCode"
                      required
                      field-label="Mã nhân viên"
                      type="text"
                      class="input input--erro"                      
                      v-model = "employee.employeeCode"
                      v-bind:class = "{'is-invalid':errors.employeeCode}"
                    /> -->
                    <!-- <div class="error-text" >
                                        {{errors.employeeCode}}
                                    </div> -->
                  </div>
                </div>
                <div class="m-col flex-1">
                  <div class="input-wrapper">
                    <!-- <label class="input__label" for="txtEmployeeCode"
                      >Họ và tên <span class="required">*</span>:</label
                    > -->
                    <m-input label = "Họ và tên" v-model = "employee.employeeFullName" :required = "true"></m-input>
                    <!-- <input
                      id="txtEmployeeName"
                      property-name="EmployeeName"
                      required
                      
                      field-label="Họ và tên"
                      type="text"
                      class="input"

                      v-model = "employee.employeeFullName"
                      
                    /> -->
                    <!-- <div class="error-text" hidden>
                                        Họ và tên không được để trống
                                    </div> -->
                  </div>
                </div>
              </div>
              <div class="m-row">
                <div class="m-col w-100">
                  <div class="input-wrapper">
                    <label class="input__label"
                      >Đơn vị <span class="required"
                      >*</span>:</label
                      
                    >
                    <select
                      class="combobox"
                      property-name="DepartmentName"
                      propValue="DepartmentId"
                      m-required
                      field-label="Đơn vị"
                      name="department"
                      id="cbxDepartment"
                      v-model = "employee.DepartmentId"
                    >
                    <option value="">-- Chọn phòng ban --</option>
                                        <option value="142cb08f-7c31-21fa-8e90-67245e8b283e">Phòng nhân sự</option>
                                        <option value="17120d02-6ab5-3e43-18cb-66948daf6128">Phòng đào tạo</option>
                                        <option value="469b3ece-744a-45d5-957d-e8c757976496">Phòng sản xuất</option>
                                        <option value="4e272fc4-7875-78d6-7d32-6a1673ffca7c">Phòng hành chính</option>
                    </select>
                    <!-- <div class="error-text" hidden>
                                        Đơn vị không được để trống
                                    </div> -->
                  </div>
                </div>
              </div>
              <div class="m-row">
                <div class="m-col w-100">
                  <m-input label = "Chức danh" v-model = "employee.employeePositionName" :required = "false"></m-input>
                  <!-- <div class="input-wrapper">
                    <div class="input-wrapper">
                      <label class="input__label">Chức danh:</label>
                      <input
                        id="txtPositionName"
                        property-name="PositionName"
                        type="text"
                        class="input"
                        v-model = "employee.employeePositionName"                       
                      />
                    </div>
                  </div> -->
                </div>
              </div>
            </div>
            <div class="form-group">
              <div class="m-row">
                <div class="m-col">
                  <div class="input-wrapper">
                    <!-- <label class="input__label" for="dtDateOfBirth"
                      >Ngày sinh:</label
                    > -->
                    <m-date :class="minputdateofbirth" label = "Ngày sinh" v-model = "employee.employeeDateOfBirth" :required = "false" typeInput = "date"></m-date>
                    <!-- <input
                      id="dtDateOfBirth"
                      property-name="DateOfBirth"
                      
                      type="date"
                      class="input"
                      v-model = "employee.employeeDateOfBirth"
                    /> -->
                  </div>
                </div>
                <div class="m-col">
                  <div class="radio-wrapper">
                    <label class="input__label" for="txtEmployeeCode"
                      >Giới tính:</label
                    >
                    <div class="radio-data flex">
                      <div class="radio-item">
                        <input
                          id="gender--male"
                          type="radio"
                          class="radio"
                          value="0"
                          name="gender"
                        /><label for="gender--male">Nam</label>
                      </div>
                      <div class="radio-item">
                        <input
                          id="gender--female"
                          type="radio"
                          class="radio"
                          value="1"
                          name="gender"
                        /><label for="gender--female">Nữ</label>
                      </div>
                      <div class="radio-item">
                        <input
                          id="gender--other"
                          type="radio"
                          class="radio"
                          value="2"
                          name="gender"
                        /><label for="gender--other">Khác</label>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="m-row">
                <div class="m-col w-100">
                  <div class="input-wrapper">
                    <label
                      class="input__label"
                      for="txtIdentityNumber"
                      title="Số chứng minh thư nhân dân"
                      >Số CMTND:</label
                    >
                    <input type="text" class="input" v-model = "employee.employeeIdCard"/>
                  </div>
                </div>
                <div class="m-col w-100">
                  <div class="input-wrapper">
                    <label class="input__label" for="txtIdentityNumber"
                      >Ngày cấp:</label
                    >
                    <input type="text" class="input" />
                  </div>
                </div>
              </div>
              <div class="m-row">
                <div class="m-col w-100">
                  <div class="input-wrapper">
                    <div class="input-wrapper">
                      <label class="input__label" for="txtIdentityAddress"
                        >Nơi cấp:</label
                      >
                      <input type="text" class="input" v-model="employee.employeePeopleIdLocation"/>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="form-row">
            <div class="m-row">
              <div class="m-col w-100">
                <div class="input-wrapper">
                  <div class="input-wrapper">
                    <label class="input__label" for="txtAddress"
                      >Địa chỉ:</label
                    >
                    <input type="text" class="input" v-model = "employee.employeeAddress"/>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="form-row">
            <div class="m-row">
              <div class="m-col">
                <div class="input-wrapper">
                  <div class="input-wrapper">
                    <label class="input__label" title="Số điện thoại di động"
                      >ĐT Di động:</label
                    >
                    <input id="txtPhoneNumber" type="text" class="input"
                      
                    v-model = "employee.employeePhoneNumber"
                    />
                  </div>
                </div>
              </div>
              <div class="m-col">
                <div class="input-wrapper">
                  <div class="input-wrapper">
                    <label class="input__label" title="Số điện thoại cố định"
                      >ĐT Cố định:</label
                    >
                    <input id="txtTelephoneNumber" type="text" class="input" />
                  </div>
                </div>
              </div>
              <div class="m-col">
                <div class="input-wrapper">
                  <div class="input-wrapper">
                    <label class="input__label">Email:</label>
                    <input id="txtEmail" type="text" class="input" v-model = "employee.employeeEmail"/>
                    <div class="error-text" hidden>
                      Email không đúng định dạng
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="m-row">
              <div class="m-col">
                <div class="input-wrapper">
                  <div class="input-wrapper">
                    <label class="input__label">TK ngân hàng:</label>
                    <input type="text" class="input" v-model = "employee.employeeBankNumber"/>
                  </div>
                </div>
              </div>
              <div class="m-col">
                <div class="input-wrapper">
                  <div class="input-wrapper">
                    <label class="input__label">Tên ngân hàng:</label>
                    <input type="text" class="input" />
                  </div>
                </div>
              </div>
              <div class="m-col">
                <div class="input-wrapper">
                  <div class="input-wrapper">
                    <label class="input__label">Chi nhánh:</label>
                    <input type="text" class="input" />
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="popup__footer">
          <div class="footer___right" @click = "created">
            <button id="btn-save" class="btn btn--default bg--green" @click = "updateEmployee(employee.employeeId)" type = "submit">
              Cất
            </button>
            <button id="btn-saveadd" @click = "saveEmployee()" type = "submit" class="btn btn--default border--gray" >
              Cất và thêm
            </button>
          </div>
          <div class="footer___left">
            <button @click="btnCloseOnClick" id="btnCancel" class="btn btn--default border--gray">
              Hủy bỏ
            </button>
          </div>
        </div>
      </form>
    </div>
</template>
<script>
// import axios from 'axios';

export default {
  name: "EmployeeDetail",

  props: ["employeeCode", "LeNgocHan", "employeeId", "employeeInput"],
  // itemEdit:{
  //   type: Object,
  //   default: null,
  // },

  watch: {

    // console.log("employee thay đổi", newVal);

    employeeName: function (newVal, oldVal) {
      console.log("Họ tên đã thay đổi: ", newVal);
      console.log("Họ tên cũ là: ", oldVal)
    },
    employee: {
      handler: function (newValue) {
        console.log("Thông tin chức danh: ", newValue.PositionName);
      }
    },
    deep: true
  },

  /*
  EmployeeCode: function (newVal) {
    console.log("employee thay doi", newVal)
    // Lấy data về:

    fetch(`http://localhost:3000/employee/${newVal}`)
      .then((res) => res.json())
      .then((data) => (this.employee = data));

  }
  */

  // chua du lieu ma component nay se lam viec
  data() {
    return {
      employee: {},
      stockData: null,
    };
  },

  // updated() {

  // },

  created() {
    // Lưu trữ dữ liệu ban đầu (trước khi bị chỉnh sửa):
    this.stockData = JSON.stringify(this.employeeInput);
    // Chuyển dữ liệu từ prop sang data:
    this.employee = JSON.parse(this.stockData);
    console.log("2. created");
    // Lấy data về:
    if (this.employeeId) {
      fetch(`https://localhost:44302/api/Employees/${this.employeeId}`)
        .then(res => res.json())
        .then((data) => {
          this.employee = data;
          console.log(data);
        })
    }
  },

  // beforeCreate(){

  // },

  // beforeMount(){

  // },

  // mounted(){

  // },

  // beforeUpdate(){

  // },

  // updated(){

  // },

  // beforeUnmount(){

  // },

  // unmounted(){

  // },

  // Tất cả các hàm / chức năng mình viết trong đây
  methods: {
    // Ẩn form
    // Author: Huy (28/3/2023)
    btnCloseOnClick() {
      // Kiểm tra dữ liệu đã thay đổi hay chưa?
      const newData = JSON.stringify(this.employee);
      if (newData != this.stockData) {
        alert("Bạn đã thay đổi dữ liệu, có muốn xóa không?");
        // return;
      }
      this.LeNgocHan()
    },


    /*
    Hàm thêm nhân viên vào form
    author: LVQHUY (07/04/2023)
    */
    saveEmployee() {
      fetch("https://localhost:44302/api/Employees", {
        method: "POST",
        body: JSON.stringify(this.employee),
        headers: {
          "Content-type": "application/json; charset=UTF-8",
        },
      })
        .then((res) => res.json())
        .then((data) => {
          console.log(data);
          this.employee = data;
        });
      this.$emit("hideMe");
      console.log(this.employee);
      location.reload();
    },
    /*
    Hàm update thông tin nhân viên
    */
    updateEmployee() {
      fetch(`https://localhost:44302/api/Employees/${this.employeeId}`, {
        method: "PUT",
        body: JSON.stringify(this.employee),
        headers: {
          "Content-type": "application/json; charset=UTF-8",
        },
      })
        .then((res) => res.json())
        .then((data) => {
          console.log(data);
          data = this.employee;
        });
      console.log(this.employeeId);
      this.$emit("hideMe");
      console.log(this.employee);
    },

    btnAddOrUpdateEmployee() {
      // insert or update
      this.getEmployeeByCode("closeForm");
    },
  },
};
</script>
<style>
.is-invalid {
  border: 1px solid red;
}
</style>
