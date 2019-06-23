(function($) {
    "use strict";

    $(".swtching-icon").click(function() {
        $(".swtching").toggleClass("active-all");
    });

    $(".dodgerblue").click(function() {
        $(".change-color").attr("href", "switcher/css/colors/dodgerblue.css");
        $(".dg-logo-ch, .footer-logo").attr("src", "switcher/logo/dodgerblue-logo.png");
    });

    $(".chocolate").click(function() {
        $(".change-color").attr("href", "switcher/css/colors/chocolate.css");
        $(".dg-logo-ch, .footer-logo").attr("src", "switcher/logo/chocolate-logo.png");
    });

    $(".darkviolet").click(function() {
        $(".change-color").attr("href", "switcher/css/colors/darkviolet.css");
        $(".dg-logo-ch, .footer-logo").attr("src", "switcher/logo/darkviolet-logo.png");
    });

    $(".orange").click(function() {
        $(".change-color").attr("href", "switcher/css/colors/orange.css");
        $(".dg-logo-ch, .footer-logo").attr("src", "switcher/logo/orange-logo.png");
    });

    $(".limegreen").click(function() {
        $(".change-color").attr("href", "switcher/css/colors/limegreen.css");
        $(".dg-logo-ch, .footer-logo").attr("src", "switcher/logo/limegreen-logo.png");
    });

    $(".orangered").click(function() {
        $(".change-color").attr("href", "switcher/css/colors/orangered.css");
        $(".dg-logo-ch, .footer-logo").attr("src", "switcher/logo/orangered-logo.png");
    });

})(jQuery);