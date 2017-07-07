var path = require('path');
var gulp = require('gulp');
var plumber = require('gulp-plumber');
var msbuild = require("gulp-msbuild");
var iisexpress = require('gulp-serve-iis-express');
var browserSync = require('browser-sync').create();

var PORT = '2935';
var sources = [
    'Controllers/*.cs',
    'Helpers/*.cs',
    'ViewModel/**/*.cs'
];
var views = [
    'Views/**/*.cshtml',
];

gulp.task('default', ['server', 'build'], function() {
    browserSync.init({
        proxy: 'http://localhost:' + PORT,
        notify: false,
        ui: false
    });
    gulp.watch(sources, ['build']);
    return gulp.watch(views, ['reload']);
});

gulp.task('reload', function() {
    browserSync.reload();
});

gulp.task('build', function() {
    return gulp.src("../Eva360.sln")
        .pipe(plumber())
        .pipe(msbuild({
            toolsVersion: 'auto',
            logCommand: true
        }));
});

gulp.task('server', function() {
    var configPath = path.join(__dirname, '..\\.vs\\config\\applicationhost.config');
    iisexpress({
        siteNames: ['Eva360'],
        configFile: configPath,
        port: PORT
    });
});