﻿//import { Alert } from "../lib/bootstrap/dist/js/bootstrap.bundle";

// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

$(document).ready(function () {
    var anio = new Date().getFullYear();
    $('.sidenav').sidenav();
    $('.datepicker').datepicker({
        yearRange: [anio-100,anio],
        format: 'dd/mm/yyyy'
    });
    $('select').formSelect();
});

function anios(endyear) {
    var arr = new Array();
    for (var i = 0; i < 100; i++) {
        arr.push(endyear - i);
    }
    return arr;
}

$("#txtsearch").on("keyup", function () {
    alert("Prueba ok");
    /*var txtenter = $(this).val();
    $("table tr").each(function (results) {
        if (results !== 0) {
            var id = $(this).find("td:nth-child(2)").text();
            if (id.indexOf(txtenter) == 0 && id.toLowerCase().indexOf(txtenter.toLowerCase()) < 0) {
                $(this).hide();
            }
            else {
                $(this).show();
            }
        });*/
});
//$("#elementID").pickadate("picker").set("select", "21/05/2017", { format: "dd/mm/yyyy" }).trigger("change");

