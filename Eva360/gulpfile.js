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

const vueViews = [
    process.env.INIT_CWD + '\\ViewModels\\Login',
    // process.env.INIT_CWD + '\\ViewModels\\home\\components',
    // process.env.INIT_CWD + '\\ViewModels\\common\\components'
];

function getFolders(dir) {
    return fs.readdirSync(dir)
    .filter(function (file) {
        return fs.statSync(path.join(dir, file)).isDirectory();
    });
}

const bundlePath = 'ViewModels';

function watchFolder(input, output) {
    var b = browserify({
        entries: [input],
        plugin: [watchify],
        basedir: process.env.INIT_CWD,
        paths: vueViews
    });

    function bundle() {
        b.transform(aliasify, aliasifyConfig)
        .transform(vueify)
        .bundle()
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

function buildBundle(folder) {
    let entry = bundlePath + "//" + folder + "//main.js";
    let output = "Scripts//app//" + folder;

    console.log(`Building ${entry}`);

    browserify({
        entries: [entry],
        debug: false
    })
    .transform(vueify)
    .bundle()
    .pipe(source('app.js'))
    .pipe(buffer())
    //.pipe(uglify())
    .pipe(gulp.dest(output));
    
    console.log(`${entry} bundled to ${output}`);
}

gulp.task('go', ['build', 'serve', 'build-bundles'], function() {
    browserSync.init({
        proxy: 'http://localhost:' + PORT,
        notify: false,
        ui: false
    });
    gulp.watch(sources, ['build']);
    gulp.watch(bundles).on('change', function(e) {
        buildBundle(path.dirname(e.path).split(path.sep).pop());
    });
    gulp.watch(content, ['reload']);
});

gulp.task('watch-bundles', function () {
    let folders = getFolders(bundlePath);
    gutil.log(folders);
    folders.map(function (folder) {
        watchFolder(bundlePath + "//" + folder + "//main.js");
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

gulp.task('build-bundles', function() {
    let folders = getFolders(bundlePath);
    
    folders.map(function (folder) {
        if (fileExists.sync(bundlePath + "//" + folder + "//main.js")) {
            buildBundle(folder);
        }
    });
});

gulp.task('serve', function() {
    let configPath = path.join(__dirname, '..\\.vs\\config\\applicationhost.config');
    iisexpress({
        siteNames: ['Eva360'],
        configFile: configPath,
        port: PORT
    });
});

gulp.task('default', ['go']);