$(document).ready(function(){
    $('p.click').click(function(){
        $(this).css('color','red');
    })
});
$(document).ready(function(){
    $('p.hide').click(function(){
        $(this).hide();
    });
});
$(document).ready(function(){
    $('p.show').click(function(){
        $('p.hide').show();
    });
});
$(document).ready(function(){
    $('h1.toggle').click(function(){
        $('p.toggle').toggle();
    });
});
$(document).ready(function(){
    $('h1.slideDown').click(function(){
        if ( $('p.slideDown').is(':hidden')){
            $('p.slideDown').slideDown("slow");
        } else {
            $('p.slideDown').hide();
        }             
    });
});
$(document).ready(function(){
    $('h1.slideUp').click(function(){
        if ( $('p.slideUp').is(':hidden')){
            $('p.slideUp').slideUp("slow");
        } else {
            $('p.slideUp').hide();
        }             
    });
});
$(document).ready(function(){
    $('h1.slideToggle').click(function(){
        if ( $('p.slideToggle').is(':hidden')){
            $('p.slideToggle').slideToggle("slow");
        } else {
            $('p.slideToggle').hide();
        }             
    });
});
$(document).ready(function(){
    $('h1.fadeIn').click(function(){
        if ( $('p.fadeIn').is(':hidden')){
            $('p.fadeIn').fadeIn("slow");
        } else {
            $('p.fadeIn').hide();
        }             
    });
});
$(document).ready(function(){
    $('h1.fadeOut').click(function(){
        if ( $('p.fadeOut').is(':visible')){
            $('p.fadeOut').fadeOut("slow");
        } else {
            $('p.fadeOut').show();
        }             
    });
});
$(document).ready(function(){
    $('p.addClass').click(function(){
        $(this).addClass('btn');
    });
});
$(document).ready(function(){
    $('p.before').click(function(){
        $('p.before').before("<h2>Before jQuery function</h2>");
    });
});
$(document).ready(function(){
    $('p.after').click(function(){
        $('p.after').after("<h2>After jQuery function</h2>");
    });
});
$(document).ready(function(){
    $('p.append').click(function(){
        $('p.append').append("<h1 style='margin-left:-50px;'>jQuery appended another heading!</h1>");
    });
});
$(document).ready(function(){
    $('p.html').click(function(){
        var htmlString = $(this).html();
        $(this).text(htmlString);
    });
});
$(document).ready(function(){
    $( "img" ).attr({
    src: "jQuery-logo.png",
    title: "jQuery",
    alt: "jQuery Logo",
    height: "150px",
    width: "150px"
    });
    $( "div" ).text( $( "img" ).attr( "alt" ) );
});
$(document).ready(function(){
    $( "input" )
    .keyup(function() {
        var value = $( this ).val();
        $( "p.val" ).text( value );
    })
    .keyup();
});