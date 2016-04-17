var moduloUsuario = (function () {

    function configuraDropDownEnCascada($seccion) {

        if ($seccion.length <= 0) return;

        $seccion.cascadingDropdown({
            selectBoxes: [
                {
                    selector: 'select.departamento',
                    source: function (request, response) {
                        $.getJSON('/Ubigeo/Departamentos',
                            function (dptosLista) {
                                var dpto = $seccion.find('input[type=hidden].departamento').val();
                                var dptos = $.map(dptosLista, function (item, index) {
                                    return {
                                        label: item,
                                        value: item,
                                        selected: item===dpto
                                    }
                                });
                                response(dptos);
                            });
                    }
                },
                {
                    selector: 'select.provincia',
                    requires: ['select.departamento'],
                    source: function (request, response) {
                        $.getJSON('/Ubigeo/Provincias', request,
                            function (provinciasLista) {
                                var provincia = $seccion.find('input[type=hidden].provincia').val();
                                var provincias = $.map(provinciasLista, function (item, index) {
                                    return {
                                        label: item,
                                        value: item,
                                        selected: item === provincia
                                    }
                                });
                                response(provincias);
                            });
                    }
                },
                {
                    selector: 'select.distrito',
                    requires: ['select.departamento','select.provincia'],
                    source: function (request, response) {
                        $.getJSON('/Ubigeo/Distritos', request,
                            function (distritoLista) {
                                var dist = $seccion.find('input[type=hidden].distrito').val();
                                var distritos = $.map(distritoLista, function (item, index) {
                                    return {
                                        label: item,
                                        value: item,
                                        selected: item === dist
                                    }
                                });
                                response(distritos);
                            });
                    },
                    onChange: function (event, value, requiredValues) {
                        if (value) {
                            $seccion.find('input[type=hidden].departamento').val(requiredValues['departamento']);
                            $seccion.find('input[type=hidden].provincia').val(requiredValues['provincia']);
                            $seccion.find('input[type=hidden].distrito').val(value);
                        }
                    }

                }
            ]
        });

    }

    return {
        vincularControles : function (){
            configuraDropDownEnCascada($('#usuario-ubigeo-dropdown'))
        }
    }
})();

$(function () {
    moduloUsuario.vincularControles();
})