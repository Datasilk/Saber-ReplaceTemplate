var gulp = require('gulp');

var release = 'bin/Release/netcoreapp3.1/';
var publish = 'bin/Publish/ReplaceTemplate/'

gulp.task('publish', function () {
    p = gulp.src(['replacetemplate.html', 'replacetemplate.js', release + 'Saber.Vendor.ReplaceTemplate.dll'])
        .pipe(gulp.dest(publish, { overwrite: true }));
    return p;
});