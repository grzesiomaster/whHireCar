$().ready(function () {
    $.getJSON('LoadBrands', function (data) {
        let items = '';
        $("#BrandId").empty();
        items += "<option value='" + 0 + "'> ---all--- </option>";
        $.each(data, function (i, row) {
            items += "<option value='" + row.value + "'>" + row.text + "</option>";
        });
        $("#BrandId").html(items);
    });
});

$("#BrandId").change(function () {
    $.getJSON('ChangeBrand', { id: $("#BrandId").val() }, function (data) {
        let items = '';
        $("#CarModelId").empty();
        $.each(data, function (i, row) {
            items += "<option value='" + row.value + "'>" + row.text + "</option>";
        });
        $("#CarModelId").html(items);
    });
});
