
$.fn.jQuerySimpleCounter = function (options) {
	var settings = $.extend({
		start: 0,
		end: 10000,
		easing: 'swing',
		duration: 10000,
		complete: ''
	}, options);

	var thisElement = $(this);

	$({ count: settings.start }).animate({ count: settings.end }, {
		duration: settings.duration,
		easing: settings.easing,
		step: function () {
			var mathCount = Math.ceil(this.count);
			thisElement.text(mathCount);
		},
		complete: settings.complete
	});
};


$('#number1').jQuerySimpleCounter({ end: 35, duration: 10000 });
$('#number2').jQuerySimpleCounter({ end: 520, duration: 10000 });
$('#number3').jQuerySimpleCounter({ end: 89, duration: 10000 });
$('#number4').jQuerySimpleCounter({ end: 1068, duration: 10000 });



/* AUTHOR LINK */
$('.about-me-img').hover(function () {
	$('.authorWindowWrapper').stop().fadeIn('fast').find('p').addClass('trans');
}, function () {
	$('.authorWindowWrapper').stop().fadeOut('fast').find('p').removeClass('trans');
});
