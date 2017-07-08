const path = require('path');
const gulp = require('gulp');
const plumber = require('gulp-plumber');
const msbuild = require("gulp-msbuild");
const iisexpress = require('gulp-serve-iis-express');
var vueify = require('vueify');
const gutil = require('gulp-util');
const babel = require('gulp-babel');
const sourcemaps = require('gulp-sourcemaps');
const fs = require('fs');
const browserify = require('browserify');
const watchify = require('watchify');
const fsPath = require('fs-path');
const fileExists = require('file-exists');

const source = require('vinyl-source-stream');
const buffer = require('vinyl-buffer');
const es2015 = require('babel-preset-es2015');

const browserSync = require('browser-sync').create();

const aliasify = require('aliasify');

const aliasifyConfig = {
    aliases: {
        'vue$': 'vue/dist/vue.js'
    },
    verbose: true
};

const PORT = '2935';
const sources = [
    'Controllers/*.cs',
    'Helpers/*.cs',
    'ViewModels/**/*.cs'
];
const content = [
    'Views/**/*.cshtml',
    'Scripts/app/**/*.js',
];

const bundles = ['ViewModels/**/*.{vue,js}'];

function getFolders(dir) {
    return fs.readdirSync(dir)
    .filter(function (file) {
        return fs.statSync(path.join(dir, file)).isDirectory();
    });
}

function getFiles(dir) {
    return fs.readdirSync(dir)
    .filter(function (file) {
        return fs.statSync(path.join(dir, file)).isFile();
    });
}

const bundlePath = 'ViewModels';

function buildBundle(folder, file) {
    let entry = bundlePath + "//" + folder + "//" + file;
    let output = "Scripts//app//" + folder;

    console.log(`Building ${entry}`);

    browserify({
        entries: [entry],
        debug: false
    })
    .transform(vueify)
    .bundle()
    .pipe(source(file))
    .pipe(buffer())
    //.pipe(uglify())
    .pipe(gulp.dest(output));

    console.log(`${entry} bundled to ${output}`);
}

gulp.task('go', ['build', 'serve', 'build-bundles'], function () {
    browserSync.init({
        proxy: 'http://localhost:' + PORT,
        notify: false,
        ui: false
    });
    gulp.watch(sources, ['build']);
    gulp.watch(bundles).on('change', function (e) {
        buildBundle(path.dirname(e.path).split(path.sep).pop());
    });
    gulp.watch(content, ['reload']);
});

gulp.task('reload', function () {
    browserSync.reload();
});

gulp.task('build', function () {
    return gulp.src("../Eva360.sln")
        .pipe(plumber())
        .pipe(msbuild({
            toolsVersion: 'auto',
            logCommand: true
        }));
});

gulp.task('build-bundles', function () {
    let folders = getFolders(bundlePath);

    folders.map(function (folder) {
        var folder_path = bundlePath + "//" + folder;
        let files = getFiles(folder_path);

        files.map(function(file) {
            if (file.split('.').pop() == "js") {
                buildBundle(folder, file);
            }
        });
    });
});

gulp.task('serve', function () {
    let configPath = path.join(__dirname, '..\\.vs\\config\\applicationhost.config');
    iisexpress({
        siteNames: ['Eva360'],
        configFile: configPath,
        port: PORT
    });
});

gulp.task('default', ['go']);