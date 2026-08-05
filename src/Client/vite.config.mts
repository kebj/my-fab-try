import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";
import tailwindcss from '@tailwindcss/vite';

import path from 'path';
import { fileURLToPath } from "url";
const proxyPort = process.env.SERVER_PROXY_PORT || "5000";
const proxyTarget = "http://localhost:" + proxyPort;

const __dirname = path.dirname(fileURLToPath(import.meta.url));

// https://vitejs.dev/config/
export default defineConfig({
    plugins: [
        react(),
        tailwindcss(),
    ],
    build: {
        outDir: "../../deploy/public",
        emptyOutDir: true
    },
    resolve: {
        alias: {
            "@": path.resolve(__dirname),
        },
    },
    server: {
        port: 8080,
        proxy: {
            // redirect requests that start with /api/ to the server on port 5000
            "/api/": {
                target: proxyTarget,
                changeOrigin: true,
            }
        },
        watch: {
            ignored: [ "**/*.fs" ]
        },
    }
});