<template lang="">
    <div class="input-wrapper">
        
        <!-- phải có label truyền vào thì mới có label -->
        <label v-if = "label" class="input__label">{{ label }}<span class = "required" v-if="required"> *</span>:</label>
            <input 
                :class = "{'input--error':invalid}"
                :type = "typeInput"
                class="input"
                v-model = "value"
                @blur = "onValidateBlur"
                @input = "onValidateBlur"
            />
        <div v-if = "invalid" :class = "{'error--info':invalid}" @blur = "onValidateBlur">
            <div class="error--text">
                Vui lòng không để trống trường này
            </div>    
        </div>
    </div>
</template>
<script>
export default {
    name: "MInput",
    props: {
        modelValue: [String, Number, Boolean],
        typeInput: {
            type: String,
            default: "text",
            required: false
        },
        label: {
            type: String,
            required: false,
        },
        required: {
            type: Boolean,
            required: false,
            default: false
        },
        // isFocus: {
        //     type: Boolean,
        //     required: false,
        //     default: false
        // }
    },
    watch: {
        value: function (newValue) {
            console.log("Chức danh bên trong: ", newValue);
            this.$emit("update:modelValue", newValue)
        }
    },
    created() {
        // khi MInput được khởi tạo thì gán 
        this.value = this.modelValue;
        // VD: thằng modelValue chính là thằng positionName
        // Nó sẽ tự hiểu cái positionName là modelValue
    },
    data() {
        return {
            value: null,
            invalid: false,
            invalidInfo: null,
        }
    },
    methods: {
        onValidateBlur() {
            if (this.required && !this.value) {
                this.invalid = true
            }
            else {
                this.invalid = false
            }
        }
    }
} 
</script>
<style scoped>
@import url(../../css/components/input.css);

.error--text {
    color: red;
    position: relative;
}
</style>