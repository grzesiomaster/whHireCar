﻿//$().ready(function () {
//    console.log("Hire car js");
//});

"use strict";

$("#BrandId").click(function () {
    console.log("clicked brand");
});

$().ready(function () {
    console.log("Hire car js zzz");
    //let url = '@Url.Content("~/")' + "HireCar/LoadBrands";
    var url = 'LoadBrands';
    $.getJSON(url, function (data) {
        var items = '';
        $("#BrandId").empty();
        items += "<option value='" + 0 + "'> ---all--- </option>";
        $.each(data, function (i, row) {
            items += "<option value='" + row.value + "'>" + row.text + "</option>";
        });
        $("#BrandId").html(items);
    });
});

//$("#BrandId").change(function () {
//    console.log("changed brand");
//});

//$("#BrandId").change(function () {
//    console.log("change brand");
//    //let url = '@Url.Content("~/")' + "HireCar/ChangeBrand";
//    let url = 'ChangeBrand';
//    let brandId = "#BrandId";
//    $.getJSON(url, { id: $(brandId).val() }, function (data) {
//        let items = '';
//        $("#CarModelId").empty();
//        $.each(data, function (i, row) {
//            items += "<option value='" + row.value + "'>" + row.text + "</option>";
//        });
//        $("#CarModelId").html(items);
//    });
//});

//$(function () {
//    $().ready(function () {
//        let url = '@Url.Content("~/")' + "HireCar/LoadBrands";
//        $.getJSON(url, function (data) {
//            let items = '';
//            $("#BrandId").empty();
//            items += "<option value='" + 0 + "'> ---all--- </option>";
//            $.each(data, function (i, row) {
//                items += "<option value='" + row.value + "'>" + row.text + "</option>";
//            });
//            $("#BrandId").html(items);
//        });
//    });

//    $("#BrandId").change(function () {
//        let url = '@Url.Content("~/")' + "HireCar/ChangeBrand";
//        let brandId = "#BrandId";
//        $.getJSON(url, { id: $(brandId).val() }, function (data) {
//            let items = '';
//            $("#CarModelId").empty();
//            $.each(data, function (i, row) {
//                items += "<option value='" + row.value + "'>" + row.text + "</option>";
//            });
//            $("#CarModelId").html(items);
//        });
//    });
//});

