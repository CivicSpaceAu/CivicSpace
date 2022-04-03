const path = require('path');

module.exports = {
    mode: 'development',
    entry: {
        main: './wwwroot/js/app.js'
    },
    output: {
        path: path.resolve(__dirname, './wwwroot/js/dist'),
        filename: 'bundle.js',
        publicPath: 'dist/'
    },
    resolve: {
        extensions: ['*', '.js', '.jsx']
    },
    module: {
        rules: [{
            test: /\.(js|jsx)/,
            exclude: /node_modules/,
            use: {
                loader: 'babel-loader',
                options: {
                    'presets': ['@babel/preset-env', '@babel/preset-react']
                }
            }
        }]
    }
};