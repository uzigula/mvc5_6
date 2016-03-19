var clientModule = (function () {
    var setDropDownData = function ($dropDownArea) {
        if ($dropDownArea.length > 0) {
            $dropDownArea.cascadingDropdown({
                selectBoxes: [
                    {
                        selector: 'select.department',
                        source: function (request, response) {
                            $.getJSON('/Ubigeo/Departamentos', function (departmentData) {
                                var department = $dropDownArea.find('input[type=hidden].department').val();
                                var departments = $.map(departmentData, function (item, index) {
                                    return {
                                        label: item,
                                        value: item,
                                        selected: item === department
                                    };
                                });
                                response(departments);
                            });
                        }
                    },
                    {
                        selector: 'select.province',
                        requires: ['select.department'],
                        source: function (request, response) {
                            var province = $dropDownArea.find('input[type=hidden].province').val();
                            $.getJSON('/Ubigeo/Provincias', request, function (provinceData) {
                                var provinces = $.map(provinceData, function (item, index) {
                                    return {
                                        label: item,
                                        value: item,
                                        selected: item === province // booleano
                                    };
                                });
                                response(provinces);
                            });
                        }
                    },
                    {
                        selector: 'select.district',
                        requires: ['select.department', 'select.province'],
                        source: function (request, response) {
                            var district = $dropDownArea.find('input[type=hidden].district').val();
                            $.getJSON('/Ubigeo/Distritos', request, function (districtData) {
                                var districts = $.map(districtData, function (item, index) {
                                    return {
                                        label: item,
                                        value: item,
                                        selected: item === district
                                    };
                                });
                                response(districts);
                            });
                        },
                        onChange: function (event, value, requiredValues) {
                            if (value) {
                                $dropDownArea.find('input[type=hidden].department').val(requiredValues["department"]);
                                $dropDownArea.find('input[type=hidden].province').val(requiredValues["province"]);
                                $dropDownArea.find('input[type=hidden].district').val(value);
                            }
                        }
                    }
                ]
            });
        }
    };

    var bindUbigeoDropDowns = function () {
        setDropDownData($('#cliente-ubigeo-dropdown-area'));
    };

    return {
        bindControls: function () {
            bindUbigeoDropDowns();
        }
    };
})();


$(function () {
    clientModule.bindControls();
})