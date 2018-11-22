var gulp = require('gulp');
var $ = require('gulp-load-plugins')();
var autoprefixer = require('autoprefixer');


function file_saver() {
    return gulp.src('node_modules/file-saver/dist/*')
        .pipe(gulp.dest('Blazor.App/wwwroot/lib/file-saver/'));
}

function font_awesome_css() {
    return gulp.src('node_modules/font-awesome/css/*')
      .pipe(gulp.dest('Blazor.App/wwwroot/lib/font-awesome/css'));
}
  
function font_awesome_fonts() {
  return gulp.src('node_modules/font-awesome/fonts/*')
    .pipe(gulp.dest('Blazor.App/wwwroot/lib/font-awesome/fonts'));
}

function jquery() {
  return gulp.src('node_modules/jquery/dist/**/*')
    .pipe(gulp.dest('Blazor.App/wwwroot/lib/jquery/'));
}

function plotly() {
    return gulp.src('node_modules/plotly.js/dist/**/*')
        .pipe(gulp.dest('Blazor.App/wwwroot/lib/plotly.js/'));
}

function spinkit() {
    return gulp.src('node_modules/spinkit/css/spinkit.css')
        .pipe(gulp.dest('Blazor.App/wwwroot/lib/spinkit/'))
}


// foundation-sites

var sassPaths = [
  'node_modules/foundation-sites/scss',
  'node_modules/motion-ui/src'
];

function foundation_js() {
    return gulp.src('node_modules/foundation-sites/dist/js/**/*')
        .pipe(gulp.dest('Blazor.App/wwwroot/lib/foundation-sites/js'));
}

function foundation_css() {
  return gulp.src('Blazor.App/wwwroot/scss/app.scss')
    .pipe($.sass({
      includePaths: sassPaths,
      outputStyle: 'compressed' // if css compressed **file size**
    })
      .on('error', $.sass.logError))
    .pipe($.postcss([
      autoprefixer({ browsers: ['last 2 versions', 'ie >= 9'] })
    ]))
    .pipe(gulp.dest('Blazor.App/wwwroot/lib/foundation-sites/css'))
}


gulp.task('sass', foundation_css);
gulp.task('default', gulp.series(foundation_css, foundation_js, 
    font_awesome_css, font_awesome_fonts, plotly, jquery, spinkit, file_saver));