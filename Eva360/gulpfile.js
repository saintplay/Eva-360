var path = require('path');
var gulp = require('gulp');
var plumber = require('gulp-plumber');
var msbuild = require("gulp-msbuild");
var iisexpress = require('gulp-serve-iis-express');
var gutil = require('gulp-util');
var babel = require('gulp-babel');
var sourcemaps = require('gulp-sourcemaps');
var fs = require('fs');
var browserify = require('browserify');
var watchify = require('watchify');
var fsPath = require('fs-path');

var source = require('vinyl-source-stream');
var buffer = require('vinyl-buffer');
var es2015 = require('babel-preset-es2015');

var browserSync = require('browser-sync').create();

var PORT = '2935';
var sources = [
    'Controllers/*.cs',
    'Helpers/*.cs',
    'ViewModels/**/*.cs'
];
var content = [
    'Views/**/*.cshtml',
    'Scripts/app/**/*.js',
];

function getFolders(dir) {
    return fs.readdirSync(dir)
    .filter(function (file) {
        return fs.statSync(path.join(dir, file)).isDirectory();
    });
}

var vueViews = [
    process.env.INIT_CWD + '\\ViewModels\\Login',
    // process.env.INIT_CWD + '\\ViewModels\\home\\components',
    // process.env.INIT_CWD + '\\ViewModels\\common\\components'
];

var bundlePath = 'ViewModels';

function watchFolder(input, output) {
    var b = browserify({
        entries: [input],
        cache: {},
        packageCache: {},
        plugin: [watchify],
        basedir: process.env.INIT_CWD,
        paths: vueViews
    });

    function bundle() {
        b.bundle()
        .pipe(plumber())
        .pipe(source('bundle.js'))
        .pipe(buffer())
        .pipe(sourcemaps.init({ loadMaps: true }))
        .pipe(babel({ compact: false, presets: ['es2015'] }))
        .pipe(sourcemaps.write('./'))
        .pipe(gulp.dest(output));

        gutil.log("Bundle rebuilt!");
    }
    b.on('update', bundle);
    bundle();
}

gulp.task('go', ['build', 'server', 'watch-bundles'], function() {
    browserSync.init({
        proxy: 'http://localhost:' + PORT,
        notify: false,
        ui: false
    });
    gulp.watch(sources, ['build']);
    return gulp.watch(razor_views, ['reload']);
});

gulp.task('watch-bundles', function () {
    var folders = getFolders(bundlePath);
    gutil.log(folders);
    folders.map(function (folder) {
        watchFolder(bundlePath + "//" + folder + "//main.js", "Scripts//app//" + folder);
    });

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

gulp.task('default', ['go']);