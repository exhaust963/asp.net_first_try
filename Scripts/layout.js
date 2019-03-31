function openNav() {
    document.getElementById("kullanici").style.width = "250px";
}
function closeNav() {
    document.getElementById("kullanici").style.width = "0";
}
$(document).ready(function () {
    $('.sub-menu').click(function (e) {
        if ($(this).children('.sub-menu').hasClass('collapsed')) {
            $(".sub-menu").addClass('collapsed');
            $(this).children('.sub-menu').removeClass('collapsed');
        } else {
            $(".sub-menu").addClass('collapsed');
        }
    });
    $('.sidebar left .sub-menu collapsed').click(function (e) {
        e.stopPropagation();
    });
});