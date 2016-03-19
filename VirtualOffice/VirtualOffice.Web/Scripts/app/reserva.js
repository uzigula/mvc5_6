var reservaModule = (function () {
    var setAutocompletar = function (selector) {
        var autocompleteControl = $(selector);
        if (autocompleteControl.length === 0) {
            return;
        }

        ////configura el autocomple usando array local
        //var cargarClientes = function (clientesArreglo) {
        //    autocompleteControl.autocomplete({
        //        lookup: clientesArreglo,
        //        onSelect: function (suggestion) {
        //            //asignando id del cliente seleccionado
        //            $(".autocompleteid").val(suggestion.data);
        //        }
        //    });
        //};

        ////traer los datos
        //$.ajax({
        //    url: '/administrativa/clientes/listabusqueda',
        //    dataType: 'json'
        //}).done(function (source) {
        //    var listaClientes = $.map(source,
        //        function (cliente) {
        //            return {
        //                value: cliente.Nombre,
        //                data : cliente.Id
        //            };
        //        });
        //    cargarClientes(listaClientes);
        //});

        //autocomplete con consultar al servidor
        autocompleteControl.autocomplete({
            //lookup: clientesArreglo,
            serviceUrl: '/administrativa/clientes/listabusqueda',
            transformResult: function (response) {
                return {
                    suggestions: $.map(JSON.parse(response), function (cliente) {
                        return {
                            value: cliente.Nombre,
                            data: cliente.Id
                        };
                    })
                };
            },
            onSelect: function (suggestion) {
                //asignando id del cliente seleccionado
                $(".autocompleteid").val(suggestion.data);
            }
        });
    };

    var setDropDown = function (selector) {
        var dropdownControl = $(selector);
        if (dropdownControl.length === 0) {
            return;
        }

        dropdownControl.cascadingDropdown({
            selectBoxes: [
                {
                    selector : 'select.sucursal', //selector para dropdown
                    source: function (request, response) {
                        $.getJSON('/listas/sucursales',
                            function (sucursalesData) {
                                var sucursalActual = dropdownControl.find('input[type=hidden].sucursal').val(); // el valor del input con el Id
                                var sucursales = $.map(sucursalesData, function (item) {
                                    return {
                                        label: item.Nombre,
                                        value: item.Id,
                                        selected: item.Id === sucursalActual
                                    };
                                });
                                response(sucursales);

                        });
                    }
                },
                {
                    selector : 'select.sala',
                    requires: ['select.sucursal'],
                    source: function (request, response) {
                        var sala = dropdownControl.find('input[type=hidden].sala').val();
                        $.getJSON('/listas/salas', request,
                            function (salasData) {
                                var salas = $.map(salasData, function (item) {
                                    return {
                                        label: item.Nombre,
                                        value: item.Id,
                                        selected : item.Id === sala
                                    }
                                });
                                response(salas);
                        });
                    },
                    onChange: function (event, value, requiredValues) {
                        if (value) {
                            dropdownControl.find('input[type=hidden].sucursal').val(requiredValues['sucursal']);
                            dropdownControl.find('input[type=hidden].sala').val(value);
                        }
                    }
                }
            ]
        });

    };

    return {
        //los metodo publicos
        bind: function () {
            setAutocompletar('.autocompletetext');
            setDropDown("#reserva-salas-dropdown-area")
        }
    };
})();

$(function () {
    reservaModule.bind();
});

