var max_fields = 0;
var teams = [];

$(document).ready(function () {

    var wrapper = $(".input_fields_wrap");
    var add_button = $(".add_field_button");

    var x = 1;
    $(add_button).click(function (e) {
        e.preventDefault();

        var length = wrapper.find("input:text").length;

        if (x < max_fields) {
            x++;
            $(wrapper).append('<div><input type="text"  name=""  class="form-control" /><a href="#" class="remove_field">Remover</a></div>');
        }

        wrapper.find("input:text").each(function () {
            debugger
            var name = wrapper.find(this).val();

            var findTeam = teams.filter(obj => { return obj.Name === name })

            if (name != "" && findTeam.length == 0) {
                var team = {};
                team["Name"]= name;

                teams.push(team);

            } else if (findTeam > 0) {

                alert("Favor informe um nome único");

            }

        });
    });

    $(wrapper).on("click", ".remove_field", function (e) {
        e.preventDefault();
        $(this).parent('div').remove();
        x--;
    })

});

function getGroup() {

    max_fields = parseInt($("#cmbQtdGroup").val());
}

function SubmitDados() {
    debugger

    $.ajax({
        url: '/Team/Create',
        type: "POST",
        data: teams,
        dataType: "json",
        traditional: true,
        contentType: "application/json",
        success: function (data) {
            $("#dvIinputfields").html(data);
            if (data.status == "Success") {
                alert("Autor cadastrado com Sucesso");
            } else {
                alert("Erro ao cadastrar Autor");
            }
        },
        error: function () {
            alert("Erro na comunicação");
        }
    });
}