const { defineConfig } = require('@vue/cli-service')
module.exports = defineConfig({
  transpileDependencies: true,
  
})

module.exports = {
  devServer: {
    proxy: 'https://localhost:44302/api/'
  }
}