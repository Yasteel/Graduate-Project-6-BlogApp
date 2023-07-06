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
          './src/ProfilePage.ts'

      ],
      output: {
        entryFileNames: `assets/[name].js`,
        chunkFileNames: `assets/[name].js`,
        assetFileNames: `assets/[name].[ext]`
      }
    }
  },
  
})
