//$("th").click(function () {
//    var i = $(this).find("i")
//    var sort = $(this).attr("class");
//    i.remove();
//    if (sort == "sorting_asc") {
//        $(this).append("<i class='fas fa-sort-amount-down'></i>")
//    } else if (sort == "sorting_desc" || sort == "sorting") {
//        $(this).append("<i class='fas fa-sort-amount-up'></i>")
//    }
//    console.log($(this))
//})

$(".delete-row").click(function () {
    var url = $(this).attr("data-url")
    $.post(url, { codigo: $(this).attr("data-codigo") }, function () {
         $(this).parent().parent().remove();
        })
});

function ordenaFechas(indice,hoy) {
$.fn.dataTable.ext.search.push(
function (settings, data, dataIndex) {
    var i, f;
    var min = "01/01/1900";
    if (min != "") {
        i = min.split("/")
    }
    var max = hoy;
    if (max != "") {
        f = max.split("/")
    }
    var s = data[indice].split("/")
    s = $.map(s, function (val, i) {
        return parseInt(val);
    });
    if (min == "" && max == "") return true;

    if (min == "")
        if (parseInt(s[2]) <= parseInt(f[2]))//EL MISMO AÑO
            if (parseInt(s[1]) <= parseInt(f[1]))//Menor o igual al MES
                if (parseInt(s[0]) <= parseInt(f[0])) {//menor o igual al dia
                    return true;
                }
    if (max == "")
        if (parseInt(s[2]) >= parseInt(i[2]))
            if (parseInt(s[1]) >= parseInt(i[1]))
                if (parseInt(s[0]) >= parseInt(i[0])) {
                    return true;
                }
    i = $.map(i, function (val, i) {
        return parseInt(val);
    });
    f = $.map(f, function (val, i) {
        return parseInt(val);
    });

    if (s[2] <= f[2] && s[2] >= i[2]) {
        if (s[1] == i[1] && i[1] == f[1])
            if (s[0] >= i[0] && s[0] <= f[0]) {
                return true
            }
        if (s[1] >= i[1] && s[1] <= f[1]) {
            if (s[1] == i[1]) {
                if (s[0] >= i[0])
                    return true
            } else if (s[1] > i[1])
                if (s[1] == f[1]) {
                    if (s[0] <= f[0])
                        return true
                } else if (s[1] < f[1])
                    return true
        }
        //if ((s[0] >= i[0] || s[1] >= i[1] ) && (s[1] <=f[1] ||s[0] <=f[0]))
        //  return true;

    }
    return false;
}


);}