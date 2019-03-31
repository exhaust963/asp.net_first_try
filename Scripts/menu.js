$(function() {
    $('#list-sidebar bg-defoult > li').click(function(e) { // limit click to children of mainmenue
        var $el = $('ul',this); // element to toggle
        $('#list-sidebar bg-defoult > li > ul').not($el).slideUp(); // slide up other elements
        $el.stop(true, true).slideToggle(400); // toggle element
        return false;
    });
    $('#list-sidebar bg-defoult > li > ul > li').click(function(e) {
        e.stopPropagation();  // stop events from bubbling from sub menu clicks
    });
})