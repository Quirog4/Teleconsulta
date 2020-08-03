
function verificarInputs() {
    var rpta = false;
    var inputs = "";
    $("input[required='required']").each(function () {
        var inp = $(this)
        if (inp.val() == "") {
            rpta = true;
            inputs += inp.attr("data-label") + ", ";
            inp.css("border", "1px solid red")
        }
    })

    if (rpta) {
        // $("#closeModal").click();
        mostrarModal("#modal-error", "Faltan alguno campos", "Los campos " + inputs + " son necesarios para poder realizar la solicitud.", "")
    }
    return rpta;
}

function verificarSelects() {
    var rpta = false;
    var inputs = "";
    $("select[class='required']").each(function () {
        var inp = $(this)

        if (inp.val() == "") {
            rpta = true;
            inputs += inp.attr("data-label") + ", ";
            inp.css("border", "1px solid red")
        }
    })
    if (rpta) {
        //  $("#closeModal").click();
        mostrarModal("#modal-error", "Debe completar el formulario", "Debe seleccionar los campos "+inputs+" para poder guardar la solicitud.", "")
    }
    return rpta;
}

function verificarGrillas(tabla, title, object) {
    var inputs = $(tabla).find("tr");
    if (inputs.length == 0) {
        mostrarModal("#modal-error",
            title,
  "Se debe ingresar por lo menos " + object +
  " para poder guardar los cambios.", "")
        return true;
    }
    return false;
}

$("input, select").on("keypress keyup change", function (e) {
    $(this).css("border", "1px solid #ced4da")
})

$('input').keypress(function (e) {
    if (e.which == 13) {
        return false;
    }
});

function addRow(table, columns) {

    $("#" + table)
           .append("<tr>" +
           columns +
             "<td  class=\"text-right\">" +
             "<button type=\"button\" class=\"remove-row btn btn-link\">" +
             "<i class=\"fas fa-trash\"></i></button></td></tr>"
           );
    $(".remove-row").click(function () {
        $(this).parent().parent().remove();
    });
}

function addAnexo(div,col) {

    var tamanio = $(div + " div.invoiceBox").length;
    //console.log(tamanio)
    var maxsize= $(div).attr("data-maxFiles")
    if (tamanio > maxsize-1) {
        mostrarModal("#modal-informativo", "Límite de archivos superados", "Solo se puede agregar un máximo de " + maxsize + " archivos para esta orden", "")
        return false;
    }
    var parent=$("<div>").addClass("inpFiles col-md-" + col);
    var invoiceBox=$("<div>").addClass("invoiceBox Files");
    var box=$("<div>").addClass("boxFile").text("Seleccione archivo");
    var file=$("<input>").attr("type","file").addClass("newFile");
    var btnremove = $("<div>").addClass("removeFile").append("<i class=\"fas fa-times\"</i>")
    box.click(function () { file.click(); })
    file.change(function () {
        var input = $(this)
        var name = input.val().split("\\");
        var nombre = name[name.length - 1]
        box.addClass("attached").attr("data-toggle", "tooltip").attr("data-placement", "top").attr("title", nombre)
        box.text(nombre)
    })
    btnremove.click(function () {
        var parent = $(this).parent();
        parent.remove();
    })
    invoiceBox.append(box).append(file)
    parent.append(invoiceBox)
    parent.append(btnremove).appendTo(div)
}

function deletefile(idanexo,div,thisDiv) {
    $.post('/OIQuirurgica/deleteArchivo', { id: idanexo }
, function () {
    var tamanio = $(div).attr("data-maxFiles");
    $(div).attr("data-maxfiles", parseInt(tamanio));
    $("#"+thisDiv).remove();
})
}

$("a[data-toggle='collapse']").click(function () {
    var i = $(this).find("i");
    var h5 = $(this).find("h6");
    i.remove()
    if ($(this).attr("class") == "collapsed") {
        h5.append("<i class='fas fa-caret-up'></i>");
    } else {
        h5.append("<i class='fas fa-caret-down'></i>");
    }
})
