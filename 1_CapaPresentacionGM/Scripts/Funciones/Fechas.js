
$('.dateTime').datetimepicker({
    format: 'DD/MM/YYYY',
    locale: 'es',
    icons: {
        next: 'fas fa-angle-right',
        previous: 'fas fa-angle-left'
    }
});
$('.dateTimePicker').datetimepicker({
    locale: 'es',
    format: 'DD/MM/YYYY HH:mm A',
    icons: {
        up: "fas fa-angle-up",
        down: "fas fa-angle-down",
        time: "fas fa-clock",
        next: 'fas fa-angle-right',
        previous: 'fas fa-angle-left'
    }
});
$('.hourTimePicker').datetimepicker({
    format: 'HH:mm A',
    locale: 'LT',
    icons: {
        up: "fas fa-angle-up",
        down: "fas fa-angle-down",
        time: "fas fa-clock"
    }
});

$(".btn-date").click(function () {
    var input = $(this).attr("data-input");
    $('#' + input).data("DateTimePicker").show('')
})


$('#fec-fin').datetimepicker({
    useCurrent: false //Important! See issue #1075
});
$(".dateTime#fec-inicio").on("dp.change", function (e) {
    $('#fec-fin').data("DateTimePicker").minDate(e.date);
});
$(".dateTime#fec-fin").on("dp.change", function (e) {
    $('#fec-inicio').data("DateTimePicker").maxDate(e.date);
});

