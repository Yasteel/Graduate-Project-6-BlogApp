import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

console.log("Config executed")

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [vue()],
  server: {
    port: 5000,
  },
  build: {
    outDir: "../wwwroot/client",
    emptyOutDir: true,
    rollupOptions: {
      input: [
          './src/main.ts',
          './src/ProfilePage.ts',
          './src/NavBar.ts',
          './src/Login.ts',
          './src/Register.ts'

      ],
      output: {
        entryFileNames: `assets/js/[name].js`,
        chunkFileNames: `assets/js/[name].js`,
        assetFileNames: `assets/css/[name].[ext]`
      }
    }
  },
  
})
