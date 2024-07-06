module.exports = {
    devServer: {
        proxy: {
            '/api': {
                target: 'https://localhost:7201',
                changeOrigin: true,
                secure:false
            }
        }
    }
};