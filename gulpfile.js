'use strict';
const path = require('path');
const gulp = require('gulp');
const plumber = require('gulp-plumber');
const msbuild = require("gulp-msbuild");
const iisexpress = require('gulp-serve-iis-express');
const browserSync = require('browser-sync').create();

const PORT = '2935';
const sources = [
    'Eva360/Controllers/*.cs',
    'Eva360/Helpers/*.cs',
    'Eva360/ViewModel/**/*.cs'
];
const views = [
    'Eva360/Views/**/*.cshtml',
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
    return gulp.src("./Eva360.sln")
        .pipe(plumber())
        .pipe(msbuild({
            toolsVersion: 'auto',
            logCommand: true
        }));
});

gulp.task('server', function() {
    let configPath = path.join(__dirname, '.vs\\config\\applicationhost.config');
    iisexpress({
        siteNames: ['Eva360'],
        configFile: configPath,
        port: PORT
    });
});