var moduloUsuario = (function () {

    function configurarDropdownEnCascada($seccion) {

        if ($seccion.length <= 0) return;

        $seccion.cascadingDropdown({
            selectBoxes: [
                { // combo departamentos
                    selector: 'select.departamento',
                    source: function (request, response) {
                        $.getJSON('/Ubigeo/Departamentos',
                                function (dptosLista) {
                                    var dpto = $seccion.find('input[type=hidden].departamento').val();
                                    var dptos = $.map(dptosLista, function (item, index) {
                                        return {
                                            label: item,
                                            value: item,
                                            selected: item === dpto
                                        };
                                    });
                                    response(dptos);
                                });
                    }
                },
                { // combo provincias
                    selector: 'select.provincia',
                    requires: ['select.departamento'],
                    source: function (request, response) {
                        $.getJSON('/Ubigeo/Provincias', request,
                            function (provsLista) {
                                var provincia = $seccion.find('input[type=hidden].provincia').val();
                                var provincias = $.map(provsLista, function (item, index) {
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

                { // combo distritos
                    selector: 'select.distrito',
                    requires: ['select.departamento','select.provincia'],
                    source: function (request, response) {
                        $.getJSON('/Ubigeo/Distritos', request,
                            function (distLista) {
                                var distrito = $seccion.find('input[type=hidden].distrito').val();
                                var distritos = $.map(distLista, function (item, index) {
                                    return {
                                        label: item,
                                        value: item,
                                        selected: item === distrito
                                    }
                                });
                                response(distritos);
                            });

                    },
                    onChange: function (event, value, requiredValues) {
                        if (value) {
                            $seccion.find('input[type=hidden].departamento').val(requiredValues["departamento"]);
                            $seccion.find('input[type=hidden].provincia').val(requiredValues["provincia"]);
                            $seccion.find('input[type=hidden].distrito').val(value);
                        }
                    }
                }


            ]
        });
    }

    return {
        vincularControles: function () {
            configurarDropdownEnCascada($('#usuario-ubigeo'));
        }
    }

})();


$(function () {
    // codigo de inicializacion
    moduloUsuario.vincularControles();
})