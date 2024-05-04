<template>
  <div>
    <TheHeader></TheHeader>
    <TheMenu></TheMenu>
    <TheMain></TheMain>
  </div>
</template>

<script>

// import commonJS from './js/common.js'

// import components
import TheMain from './layout/TheMain.vue';
import TheHeader from './layout/TheHeader.vue';
import TheMenu from './layout/TheMenu.vue';
export default {
  name: 'App',
  components: {
    TheMain, TheHeader, TheMenu
  },
};
</script>

<style>
  @import url(./css/main.css);
</style>