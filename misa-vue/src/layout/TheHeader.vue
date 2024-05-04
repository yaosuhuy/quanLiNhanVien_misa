<template>
    <header>
        <div class="header__left">
            <button class="header--bars" @click="showAndHideMenu()" hidden></button>
            <div class="header--toggle"></div>
            <div class="header--logo">

            </div>
            <!-- <input type="text" class="header--search">
            </input> -->
        </div>

        <div class="header__right">
            <div class="header--employee-image"><a href="http://127.0.0.1:5500/login.html">Đăng nhập</a></div>
        </div>
        <TheMenuMobile v-if="isShowMenu"></TheMenuMobile>
    </header>
</template>

<script>
import TheMenuMobile from "./TheMenuMobile.vue"
export default {
    name: "TheHeader",
    components: { TheMenuMobile},
    methods:{
        showAndHideMenu(){
            this.isShowMenu = !this.isShowMenu
        }
    },
    data(){
    return {
        isShowMenu: false,
    };
},
}
</script>
<style lang="">
    
</style>