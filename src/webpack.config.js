const path = require('path');
const webpack = require('webpack');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const CheckerPlugin = require('awesome-typescript-loader').CheckerPlugin;
const bundleOutputDir = './wwwroot/dist';

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);

    return [{
        stats: { modules: false },
        context: __dirname,
        resolve: { 
            extensions: [ '.js', '.vue' ],
            alias: {
                'vue$': 'vue/dist/vue.esm.js',
                '@': path.resolve(__dirname, './ClientApp')
            }},
        entry: { 'main': './ClientApp/main.js' },
        module: {
            rules: [
                { 
                    test: /\.vue$/, include: /ClientApp/, loader: 'vue-loader', 
                    options: {
                        loaders: { 
                            js: 'babel-loader',
                            sass: ExtractTextPlugin.extract({
                                fallback: 'vue-style-loader',
                                use: 'css-loader!postcss-loader!sass-loader?indentedSyntax'
                            })
                        }
                    } 
                },
                { test: /\.js$/, include: /ClientApp/, use: 'babel-loader' },
                { test: /\.(png|jpg|jpeg|gif|svg)$/, use: 'url-loader?limit=25000' }
            ]
        },
        output: {
            path: path.join(__dirname, bundleOutputDir),
            filename: '[name].js',
            publicPath: '/dist/'
        },
        plugins: [
            new CheckerPlugin(),   
            new ExtractTextPlugin({
                filename: 'style.css',
                disable: isDevBuild
            }),         
            new webpack.DefinePlugin({
                'process.env': {
                    NODE_ENV: JSON.stringify(isDevBuild ? 'development' : 'production')
                }
            }),
            new webpack.DllReferencePlugin({
                context: __dirname,
                manifest: require('./wwwroot/dist/vendor-manifest.json')
            })
        ].concat(isDevBuild ? [
            // Plugins that apply in development builds only
            new webpack.SourceMapDevToolPlugin({
                filename: '[file].map', // Remove this line if you prefer inline source maps
                moduleFilenameTemplate: path.relative(bundleOutputDir, '[resourcePath]') // Point sourcemap entries to the original file locations on disk
            })
        ] : [
            // Plugins that apply in production builds only
            new webpack.optimize.UglifyJsPlugin()
        ])
    }];
};
