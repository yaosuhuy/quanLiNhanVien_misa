<template lang="">
    <div class = "dropdown-container">
      <div class="dropdown-title">
          Sửa
            <i
            class="fa-regular fa-angle-down"
            style="margin-left: 12px; cursor: pointer"
            @click="showAndHideDropdownItem"
            ></i>
      </div>
      <div class="dropdown-item" 
        v-show = "isShowDropdownItem"
      >
        <div class="dropdown-item--child">
          Nhân bản
        </div>
        <div class="dropdown-item--child" @click = "deleteEmployeeOnBtn">
          Xóa
        </div>
        <div class="dropdown-item--child">
          Ngưng sử dụng
        </div> 
        <div class="dropdown-item--child" @click = "deleteEmployeeOnBtn">
          Ẩn
        </div> 
      </div>           
    </div>    
</template>
<script>
export default {
  name: "MDropdown",
  props: ["name"],
  methods: {
    /*
    hàm ẩn và hiện dropdown
    author: LVQHUY (07/04/2023)
    */
    showAndHideDropdownItem() {
      this.isShowDropdownItem = !this.isShowDropdownItem;
    },

    /*
    hàm xóa bằng nút
    author: LVQHUY (07/04/2023)
    */
    deleteEmployeeOnBtn(employeeId){
      location.reload()
      this.$emit("delete", employeeId)
    },

    // ẩn
    hideEmployeeOnBtn(){
      this.$emit("hide");
    }

  },
  data() {
    return {
      isShowDropdownItem: false,
      isShowItem: false
    };
  },
};
</script>
<style scoped>

.dropdown-container{
  position: relative;
}

.dropdown-title{
  display:flex;
  justify-content: center;
  color: #3390CB;
}
.dropdown-item {
  left: 10px;
  top: 25px;
  display: flex;
  flex-direction: column;
  justify-content: center;
  /* row-gap: 5px; */
  position: absolute;
  width: 110px;
  height: 90px;
  background-color: #fff;
  border: 1px solid #cccccc;
  box-sizing: border-box;
  z-index: 98;

}

.dropdown-item--child {
  height: calc(100% / 3);
  padding: 5px;
  box-sizing: border-box;
}
.dropdown-item--child:hover {
  background-color: #E8E9EC;
  cursor: pointer;
  color: #56CD66;
}
</style>