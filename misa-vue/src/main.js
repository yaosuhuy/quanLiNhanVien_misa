import { createApp } from 'vue'
import App from './App.vue'
import MInput from './components/base/MInput.vue'
import MDate from './components/base/MDatePicker.vue'

const app = createApp(App);
app.mount('#app');
app.component("MInput", MInput);
app.component("MDate", MDate);
