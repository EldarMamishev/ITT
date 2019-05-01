'use strict';

var gulp = require('gulp');
var sass = require('gulp-sass');
var mainBowerFiles = require('main-bower-files');
var uglify = require('gulp-uglify');
var rename = require('gulp-rename');
var del = require('del');
var runSequence = require('run-sequence');

gulp.paths = {
    dist: ''
};

var paths = gulp.paths;

// Static Server + watching scss/html files
gulp.task('serve', ['sass'], function () {
    gulp.watch('Sass/**/*.scss', ['sass']);
});

// Static Server without watching scss files
gulp.task('sass', function () {
    return gulp.src([
        './Sass/style.scss',
        './Sass/layouts/adminLayout.scss'
    ]).pipe(sass())
        .pipe(gulp.dest('./wwwroot/css'));
});

gulp.task('sass:watch', function () {
    gulp.watch('./Sass/**/*.scss');
});

gulp.task('clean:dist', function () {
    return del(paths.dist);
});

gulp.task('copy:bower', function () {
    return gulp.src(mainBowerFiles(['**/*.js', '!**/*.min.js']))
        .pipe(gulp.dest(paths.dist + '/js/libs'))
        .pipe(uglify())
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest(paths.dist + '/js/libs'));
});

gulp.task('copy:js', function () {
    return gulp.src('./js/**/*')
        .pipe(gulp.dest(paths.dist + '/js'));
});

gulp.task('build:dist', function (callback) {
    runSequence('clean:dist', 'copy:bower', 'copy:css', 'copy:img', 'copy:fonts', 'copy:js', 'copy:views', 'copy:html', 'replace:bower', callback);
});

gulp.task('default', ['serve']);