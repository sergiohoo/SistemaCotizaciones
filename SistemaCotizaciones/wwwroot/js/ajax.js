//FUNCIONES AJAX PARA AGREGAR ELEMENTOS MIENTRAS CREA LA COTIZACIÓN

function addMaterial() {
    const form = document.getElementById("formMaterial");

    const elements = new FormData(form);
    const object = Object.fromEntries(elements.entries());
    const data = JSON.stringify(object);
    console.log(data);

    $.ajax({
        url: "/Cotizaciones/AddMaterial",
        type: "GET",
        data: "json=" + data,
        success: function (resId) {
            console.log(resId);
            var selects = $(".mMaterial");
            for (i = 0; i < selects.length; i++) {
                selects.eq(i).find("select").append(`<option value="${resId}">${object.Sku + " | " + object.Descripcion}</option>`);
                selects.eq(i).selectpicker("refresh");
            }
        },
        error: function (error) {
        }
    });
}

function addCanal() {
    const form = document.getElementById("formCanal");

    const elements = new FormData(form);
    const object = Object.fromEntries(elements.entries());
    const data = JSON.stringify(object);
    console.log(data);

    $.ajax({
        url: "/Cotizaciones/AddCanal",
        type: "GET",
        data: "json=" + data,
        success: function (resId) {
            console.log(resId);
            var select = $("#Cotizacion_CanalId");
            select.find("select").append(`<option value="${resId}">${object.RazonSocial}</option>`);
            select.selectpicker("refresh");
        },
        error: function (error) {
        }
    });
}

function addContactoCanal() {
    const form = document.getElementById("formContactoCanal");

    const elements = new FormData(form);
    const object = Object.fromEntries(elements.entries());
    const data = JSON.stringify(object);
    console.log(data);

    $.ajax({
        url: "/Cotizaciones/AddContactoCanal",
        type: "GET",
        data: "json=" + data,
        success: function (resId) {
            console.log(resId);
            var select = $("#Cotizacion_ContactoCanalId");
            select.find("select").append(`<option value="${resId}">${object.Nombre} ${object.Apellido}</option>`);
            select.selectpicker("refresh");
        },
        error: function (error) {
        }
    });
}

function addClienteFinal() {
    const form = document.getElementById("formClienteFinal");

    const elements = new FormData(form);
    const object = Object.fromEntries(elements.entries());
    const data = JSON.stringify(object);
    console.log(data);

    $.ajax({
        url: "/Cotizaciones/AddClienteFinal",
        type: "GET",
        data: "json=" + data,
        success: function (resId) {
            console.log(resId);
            var select = $("#Cotizacion_ClienteFinalId");
            select.find("select").append(`<option value="${resId}">${object.RazonSocial}</option>`);
            select.selectpicker("refresh");
        },
        error: function (error) {
        }
    });
}

function addContactoClienteFinal() {
    const form = document.getElementById("formContactoClienteFinal");

    const elements = new FormData(form);
    const object = Object.fromEntries(elements.entries());
    const data = JSON.stringify(object);
    console.log(data);

    $.ajax({
        url: "/Cotizaciones/AddContactoClienteFinal",
        type: "GET",
        data: "json=" + data,
        success: function (resId) {
            console.log(resId);
            var select = $("#Cotizacion_ContactoClienteFinalId");
            select.find("select").append(`<option value="${resId}">${object.Nombre} ${object.Apellido}</option>`);
            select.selectpicker("refresh");
        },
        error: function (error) {
        }
    });
}