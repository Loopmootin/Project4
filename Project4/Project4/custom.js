$(document).ready(function () {


    $('#search').hover(
        function () {
            $(this).animate({ width: '200px' }, 500);
        },
        function () {
            $(this).animate({ width: '150px' }, 300);
        }
    );

});