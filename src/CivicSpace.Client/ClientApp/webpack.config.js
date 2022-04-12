const path = require('path');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");

module.exports = {
    mode: 'development',
    entry: {
        main: './src/index.tsx'
    },
    output: {
        path: path.resolve(__dirname, '../wwwroot/js'),
        filename: 'index.js',
        publicPath: 'js/'
    },
    resolve: {
        extensions: ['*', '.ts', '.tsx', '.js', '.jsx']
    },
    plugins: [
        new MiniCssExtractPlugin({
            attributes: {
                id: "target",
                "data-target": "example",
            },
        }),
    ],
    module: {
        rules: [{
                test: /\.tsx?$/,
                use: 'ts-loader',
                exclude: /node_modules/,
            }, {
                test: /\.(js|jsx)/,
                exclude: /node_modules/,
                use: {
                    loader: 'babel-loader',
                    options: {
                        'presets': ['@babel/preset-env', '@babel/preset-react']
                    }
                }
            }, {
                test: /\.(png|jpe?g|gif|svg)(\?.*)?$/,
                loader: 'url-loader',
            }, {
            test: /\.(sa|sc|c)ss$/,
            use: [{
                loader: MiniCssExtractPlugin.loader,
                options: {
                    publicPath: '../'
                }
            }, {
                loader: 'css-loader',
            }, // translates CSS into CommonJS
            {
                loader: 'postcss-loader',
            }, // Add vendor prefixes on build css file
            {
                loader: 'sass-loader',
            } // compiles Sass to CSS
            ]
        },]
    }
};