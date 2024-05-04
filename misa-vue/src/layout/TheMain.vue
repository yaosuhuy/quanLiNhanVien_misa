<template>
  <div class="content">
    <div class="page__header">
      <div class="page-header__left heading">Quản lí nhân viên</div>
      <div class="page-header__right">
        <button class="btn btn--default" @click="isShowPopup = true">
          <i class="btn--icon fa-solid fa-plus" style="margin-right: 8px"></i>
          Thêm mới
        </button>
        <button class="btn-square btn-more">
          <i class="fa-solid fa-ellipsis"></i>
        </button>
      </div>
    </div>
    <!-- main content -->
    <div class="page__content">
      <div class="table-wrapper">
        <div class="table__toolbar">
          <!-- search -->
          <div class="table-toolbar__left">
            <!-- <div class="table__search">
              <input type="text" class="icon icon-search input-search input-icon" placeholder="Tìm kiếm trong danh sách"
                 />
            </div> -->
          </div>
          <div class="table-toolbar__right">
            <div class="table__search">
              <input ref = inputSearch type="text" class="icon icon-search input-search input-icon" placeholder="Tìm kiếm" @keyup="searchEmployee"
                 />
            </div>
            <!-- <div class="table__select">
              <select name="" id="table__select">
                <option selected disabled>Chọn công ty</option>
                <option value="">1</option>
                <option value="">2</option>
                <option value="">3</option>
              </select>
            </div> -->
            <button class="btn-square btn-filter">
              <i class="fa-regular fa-filter"></i>
            </button>
            <button class="btn-square btn-setting">
              <i class="fa-regular fa-gear"></i>
            </button>
          </div>
        </div>
        <div class="table">
          <table class="employee-table">
            <thead>
              <tr>
                <th>MÃ NHÂN VIÊN</th>
                <th>HỌ VÀ TÊN</th>
                <th>GIỚI TÍNH</th>
                <th>NGÀY SINH</th>
                <th>CHỨC DANH</th>
                <th>SỐ CCCD</th>
                <th>ĐỊA CHỈ</th>
                <th>SỐ ĐIỆN THOẠI</th>
                <th>EMAIL</th>
                <th>CHỨC NĂNG</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="(item, id) in employees" :key="id" @dblclick="rowOnDbClick(item)">
                <td>{{ item.employeeCode }}</td>
                <td>{{ item.employeeFullName }}</td>
                <td>{{ formatGender(item.employeeGender) }}</td>
                <td>{{ formatDate(item.employeeDateOfBirth) }}</td>
                <td>{{ item.employeePositionName }}</td>
                <td>{{ item.employeeIdCard }}</td>
                <td>{{ item.employeeAddress }}</td>
                <td>{{ item.employeePhoneNumber }}</td>
                <td>{{ item.employeeEmail }}</td>
                <td style="z-index = 1">
                  <MDropdown @delete="deleteEmployee(item.employeeId)"></MDropdown>
                </td>
              </tr>
        
            </tbody>
          </table>
        </div>

        <div class="table__paging">
          <div class="table__paging-left">
            <div class="table-total">Tổng số: {{ recordCount }} bản ghi</div>
          </div>

          <div class="table__paging-right">
            <div class="table-unit" style="margin-right: 63px">Bản ghi/Trang</div>
            <div class="table--number-select">
              <select name="" id="table--number-select">
                <option value="">50</option>
                <option value="">60</option>
                <option value="">70</option>
              </select>
            </div>
            <div class="table--number-records" style="margin-left: 30px">
              1-9 records
            </div>
            
          </div>
        </div>
      </div>
    </div>

    <!-- THÔNG BÁO -->
    <div id="dialog-notice" class="dialog" hidden>
      <div class="dialog-container">
        <div class="dialog__button"><i class="icofont-close"></i></div>
        <div class="dialog__header">
          <div class="dialog__title">Dữ liệu không hợp lệ</div>
        </div>
        <div class="dialog__content">
          <li>Mã nhân viên không hợp lệ.</li>
          <li>Ngày sinh không được lớn hơn ngày hiện tại.</li>
          <li>Email không đúng định dạng.</li>
        </div>
        <div class="dialog__footer">
          <button class="btn btn--default bg--green dialog__button--accept">
            Đồng ý
          </button>
          <!-- <button class="btn btn--default border--gray">Hủy bỏ</button> -->
        </div>
      </div>
    </div>
    <EmployeeDetail v-if="isShowPopup" :LeNgocHan="hidePopup" :employeeId="employeeIdSelected" @hideMe="hidePopup" @save="clickAdd"
      :employeeInput="empSelected"></EmployeeDetail>
    <!-- <EmployeeDetail v-if="isShowPopup"></EmployeeDetail> -->

  </div>
</template>
<script>
import EmployeeDetail from "@/views/employee/EmployeeDetail.vue";
import MDropdown from "@/views/employee/MDropdown.vue";
// import axios from 'axios';
// import EmployeeDetailSelected from "@/views/employee/EmployeeDetailSelected.vue";

export default {
  name: "TheMain",

  // props: hứng dữ liệu
  // khong the bi thay doi trong chinh component nay
  props: ["name"],
  components: { EmployeeDetail, MDropdown },

  created() {
    fetch("https://localhost:44302/api/Employees", { mode: 'no-cors' })
      .then((res) => res.json())
      .then((data) => {
        console.log(data);
        this.employees = data;
        this.recordCount = this.employees.length
      });
  },

  // method: cac phuong thuc
  methods: {
    /*
    hàm click đúp chuột hiện thông tin nhân viên
    author: LVQHUY (06/04/2023)
    */
    rowOnDbClick(employee) {
      this.isShowPopup = true;
      this.employeeIdSelected = employee.employeeId;
      this.empSelected = employee;
    },

    /*
    hàm click chuột thêm nhân viên
    author: LVQHUY (06/04/2023)
    */
    btnAddOnClick() {
      this.isShowPopup = true;
    },

    /*
    hàm ẩn form nhân viên
    author: LVQHUY (06/04/2023)
    */
    hidePopup() {
      this.isShowPopup = false;
    },

    /*
    hàm xóa 1 nhân viên
    author: LVQHUY (07/04/2023)
    */
    deleteEmployee(employeeId) {
      fetch(`https://localhost:44302/api/Employees/${employeeId}`, {
        method: "DELETE",
        headers: {
          "content-type": "application/json",
        },
      })
        .then((res) => res.text())
        .then((data) => {
          console.log(data);

        })
        .catch((err) => {
          console.log(err);

        });
      // location.reload();
    },

    /*
    hàm định dạng ngày tháng
    author: LVQHUY (07/04/2023)
    */

    formatDate(date) {
      try {
        date = new Date(date);
        // Lấy ra ngày
        let dateValue = date.getDate();
        // Lấy ra tháng
        let month = date.getMonth() + 1;
        // Lấy ra năm
        let year = date.getFullYear();

        return `${dateValue}/${month}/${year}`;
      } catch (error) {
        return ""

      }
    },

    formatGender(number){
      let gender = ""
      if (number === 0) gender = "Nam"
      if (number === 1) gender = "Nữ"
      if (number === 2) gender = "Khác"
      return gender
    },

    // Tìm kiếm
    searchEmployee(){
      let key = this.$refs.inputSearch.value;
      fetch(
        `https://localhost:44302/api/Employees/SearchEmployeeByNameOrCode?keySearch=${key}`
      )
        .then((res) => res.json())
        .then((data) => {
          this.employees = data;
        });
      if (!key) {
        fetch(`https://localhost:44302/api/Employees`)
          .then((res) => res.json())
          .then((data) => {
            this.employees = data;
          });
      }
    },

    // Ẩn
    hideRow(index) {
      // Thay đổi giá trị của mảng hiddenRows để ẩn hàng
      this.hiddenRows.push(index);
    },
    isRowHidden(index) {
      // Kiểm tra xem hàng có nên được hiển thị hay không
      return this.hiddenRows.includes(index);
    }


  },
  // chua du lieu ma component nay se lam viec
  data() {
    return {
      fullName: "Lê Văn Quang Huy",
      employees: [
      ],
      isShowPopup: false,
      employeeIdSelected: null,
      empSelected: {},
      recordCount: 0,
      hiddenRow:[],
      isHidden: false
    };
  },
};
</script>
<style scoped>
.dropdown-item {
  cursor: pointer;
}
</style>