<template lang="">
    <div class="input-wrapper">
        <!-- phải có label truyền vào thì mới có label -->
        <label v-if = "label" class="input__label">{{ label }}<span class = "required" v-if="required"> *</span>:</label>
            <input
                :isFocus = "true"
                :class = "{'input--error':invalid}"
                id="txtPositionName"
                property-name="PositionName"
                :type = "typeInput"
                class="input"
                v-model = "value"
                @blur = "onValidateBlur"
            />
    </div>
</template>
<script>
export default {
    name: "MDate",
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
        isFocus: {
            type: Boolean,
            required: false,
            default: false
        }
    },
    watch: {
        value: function (newValue) {
            console.log("Chức danh bên trong: ", newValue);
            this.$emit("update:modelValue", newValue)
        }
    },
    created() {
       
        if (this.modelValue) {
            var date = new Date(this.modelValue);
            let dateString = date.getDate();
            dateString = dateString < 10 ?`0${dateString}`:dateString;
            let month = date.getMonth()+1;
            month = month < 10 ? `0${month}`:month;
            let year = date.getFullYear();
            // khi MInput được khởi tạo thì gán 
            this.value = `${year}-${month}-${dateString}`;
            // VD: thằng modelValue chính là thằng positionName
            // Nó sẽ tự hiểu cái positionName là modelValue
            console.log("modelValue", this.modelValue)
        }
    },
    data() {
        return {
            value: null,
            invalid: false
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
</style>