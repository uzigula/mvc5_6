var app = (function () {

    function llenarFormulario() {
        var formNuevo = '';
        var parametroBusqueda = $("input[name='Busqueda']").val();

        //formNuevo = '<input type="hidden" name="BusquedaAnterior" value="' + parametroBusqueda + '"/>';
        //$("#hidden-export").html("");
        //$("#hidden-export").append(formNuevo);
        $("input[name='BusquedaAnterior']").val(parametroBusqueda);
    }

    function exportaExcel() {
        //llenarFormulario();
        $("#frm-Excel").submit();
    };

    //publicar la interface de modulo
    return {
        exportar: exportaExcel,
        actualizarBusqueda: llenarFormulario,
        iniciar : function() {
            return null;
        }
    };
})();

$(function () {
    app.iniciar();
});