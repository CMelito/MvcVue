var gulp = require('gulp');
var file = require('gulp-file');
var fileList = require('gulp-filelist');
var _ = require('lodash');

var viewModelPath = 'app/viewModels/';

gulp.task('viewmodels', function () {
    var stream = gulp.src([viewModelPath + '**/*main.js'])
        .pipe(fileList('viewmodels.json', { relative: true }))
        .pipe(gulp.dest('build'));
    return stream;
});

gulp.task('default', ['viewmodels'], function () {
    var entry = {};
    var fl = require('./build/viewmodels.json');
    _.each(fl, function (item, index) {
        var name = item.replace('.main.js', '').replace('/', '.').toLowerCase();
        entry[name] = './' + viewModelPath + item;
    });
    var output = 'module.exports = ' + JSON.stringify(entry);
    file('webpack.config.entry.js', output).pipe(gulp.dest('./build'));
});