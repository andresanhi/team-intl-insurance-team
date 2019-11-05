// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

$(document).ready(function () {
    $('.sidenav').sidenav();
    $('.datepicker').datepicker();
    $('select').formSelect();
});

$("#elementID").pickadate("picker").set("select", "21/05/2017", { format: "dd/mm/yyyy" }).trigger("change");