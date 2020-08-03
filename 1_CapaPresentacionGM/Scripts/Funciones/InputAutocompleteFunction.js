
function autocompleteSimple(input,url,minimo) {
    $(input).autocomplete({
        source: function (request, response) {
            $.ajax({
                url:  url,
                dataType: "json",
                data: {
                    term: request.term
                },
                success: function (data) {
                    var lista = []
                    $(data.list).each(function (i) {
                        var json = { "id": this.codigo, "value": this.descripcion ,"codigo":this.id}
                        lista.push(json)
                    });
                    response(lista);
                }
            });
        },
        minLength: minimo,
        select: function (event, ui) {
            $(input).attr("data-id",ui.item.codigo)
        }

    })
}

function addFile(tabla, columnas){
        $("#" +tabla)
               .append("<tr>"+columnas+
               "<td  class=\"text-right\">" +
               "<button type=\"button\" class=\"remove-row btn btn-link\"><i class=\"fas fa-trash\"></i></button></td>"+
               "</tr>");
        $(".remove-row").click(function () {
            $(this).parent().parent().remove();
        });
}

function listarInputs(nameInputs) {
    var lista = $("input[class='" + nameInputs + "']");
    var indice = 0;
        lista.each(function () {
        $(this).attr("name", nameInputs + "[" + indice + "]")
        indice++;
    })

}

function listaInputColumnas(tabla, modelo, clase) {
    var index = 0;
    $("#"+tabla+" tr").each(function () {
        var tr = $(this);
        var inputs = tr.find("." + clase)
        inputs.each(function () {
            var inp = $(this)
            inp.attr("name",modelo+ "[" + index + "]." + inp.attr("data-name"))
        })
        if(inputs.length!=0){

            index++;
        }
    })
}