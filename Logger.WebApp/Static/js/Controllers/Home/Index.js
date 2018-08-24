$(document).ready(function () {
    
    $("#btnSave").on("click", function () {

        if ($.trim($("#txtMensaje").val()) == "")
        {
            alert("Error or Warning or Message must be specified");
        }
        else Login();

        return false;
    });

    function Login() {

        $("#TypeMessage").val($.trim($("#ddlTipoMensaje").val()));
        $("#Configuration").val($.trim($("#ddlConfiguracion").val()));
        $("#Message").val($.trim($("#txtMensaje").val()));

        request_ns.post_json(Home_ns.url.Index, $("#frmLogin").serialize(),
           function (data) {
               try {
                   $("#txtRespuesta").val(data.msg);
                   switch($.trim($("#ddlTipoMensaje").val()))
                   {
                       case "1": $("#txtRespuesta").css('background-color', 'red'); break;
                       case "2": $("#txtRespuesta").css('background-color', 'yellow'); break;
                       case "3": $("#txtRespuesta").css('background-color', 'green'); break;
                   }

               } catch (e) {
                   console.log(e);
               }
           }
       );
    }
});