"use strict";
var path = require('path')
var webpack = require('webpack')

var entry = require('./build/webpack.config.entry');

module.exports = {
    entry: entry,
    output: {
        path: path.resolve(__dirname, './dist'),
        publicPath: '/dist/',
        filename: '[name].bundle.js'
    },
    module: {
        rules: [
            { test: /\.vue$/, loader: 'vue-loader', options: { loaders: {} } },
            { test: /\.js$/, loader: 'babel-loader', exclude: /node_modules/ },
            { test: /\.(png|jpg|gif|svg)$/, loader: 'file-loader', options: { name: '[name].[ext]?[hash]'} }
        ]
    },
    resolve: { extensions: ['.js', '.vue'], alias: { 'vue$': 'vue/dist/vue.esm.js' } },
    performance: { hints: false }    
};