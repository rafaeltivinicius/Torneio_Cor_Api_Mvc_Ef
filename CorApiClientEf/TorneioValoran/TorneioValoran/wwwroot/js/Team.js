var max_fields = 0;
var teams = [];
var wrapper = $(".input_fields_wrap");
var add_button = $(".add_field_button");
var x = 1;

$(document).ready(function () {

    $("input:text").change(function () {

        AddTextBoxEAddNovoTeam();
    });

    $(add_button).click(function (e) {

        AddTextBoxEAddNovoTeam();
    });

    $(wrapper).on("click", ".remove_field", function (e) {
        e.preventDefault();
        $(this).parent('div').remove();
        x--;
    })
});


function AddTextBoxEAddNovoTeam() {

    if (x < max_fields) {
        x++;
        $(wrapper).append('<div><input type="text"  name=""  class="form-control" /><a href="#" class="remove_field">Remover</a></div>');
    }

    wrapper.find("input:text").each(function () {

        var name = wrapper.find(this).val();

        var findTeam = teams.filter(obj => { return obj.Name === name })

        if (name != "" && findTeam.length == 0) {
            var team = {};
            team["Name"] = name;
            teams.push(team);

        } else if (findTeam > 0) {

            alert("Favor informe um nome único");

        }
    });
}

function getGroup() {

    max_fields = parseInt($("#cmbQtdGroup").val());
}

function SubmitDados() {

    AddTextBoxEAddNovoTeam();
    debugger

    $.ajax({
        url: '/Team/Create',
        type: "POST",
        data: JSON.stringify(teams),
        dataType: "json",
        traditional: true,
        contentType: "application/json; charset=utf-8",
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