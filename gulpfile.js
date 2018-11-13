var gulp = require('gulp');

gulp.task('font-awesome-css', function() {
    return gulp.src('node_modules/font-awesome/css/*')
      .pipe(gulp.dest('Blazor.App/wwwroot/lib/font-awesome/css'));
  });
  
gulp.task('font-awesome-fonts', function() {
  return gulp.src('node_modules/font-awesome/fonts/*')
    .pipe(gulp.dest('Blazor.App/wwwroot/lib/font-awesome/fonts'));
});

gulp.task('foundation', function() {
  return gulp.src('node_modules/foundation-sites/dist/**/*')
    .pipe(gulp.dest('Blazor.App/wwwroot/lib/foundation-sites/'));
});

gulp.task('plotly', function() {
  return gulp.src('node_modules/plotly.js/dist/**/*')
    .pipe(gulp.dest('Blazor.App/wwwroot/lib/plotly.js/'));
});

gulp.task('jquery', function() {
  return gulp.src('node_modules/jquery/dist/**/*')
    .pipe(gulp.dest('Blazor.App/wwwroot/lib/jquery/'));
});
  
gulp.task('default', [
  'font-awesome-css',
  'font-awesome-fonts',
'foundation',
'plotly',
'jquery']);
  