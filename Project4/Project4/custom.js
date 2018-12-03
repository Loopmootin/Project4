$(document).ready(function () {
    var random = Math.floor(Math.random() * jQuery('.commercial').length);
    jQuery('.commercial').eq(random).show();
});
