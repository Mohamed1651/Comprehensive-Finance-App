import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';
import fs from 'fs';

export default defineConfig({
    plugins: [react()],
    server: {
        https: {
            key: fs.readFileSync('C:/Users/khada/source/repos/certs/localhost-key.pem'),
            cert: fs.readFileSync('C:/Users/khada/source/repos/certs/localhost.pem'),
        },
        port: 5173, // optional, but ensures matching with backend CORS policy
    },
});
