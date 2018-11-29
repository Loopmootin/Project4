$(document).ready(function () {
        $('#search').hover(
            function () {
                $(this).animate({ width: '150px' }, 500);
            },
            function () {
                    $(this).animate({ width: '100px' }, 300);             
            }
        );
});