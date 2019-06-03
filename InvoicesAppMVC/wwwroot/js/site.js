// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.

function addRow() {

    var index = $("#tbItems").children("tr").length;

    var indexCell = "<td style='display:none'><input name='Item.Index' type='hidden' value='" + index + "'/></td > ";

    var itemIdCell = "<td><input id='Item_" + index + "__ItemId' name='Items[" + index + "].ItemId' type='text' value='' class='form-control'/></td > ";

    var nameCell = "<td><input id='Item_" + index + "__Name' name='Items[" + index + "].Name' type='text' value = '' class='form-control'/></td > ";

    var amountCell = "<td><input id='Item_" + index + "__Amount' name='Items[" + index + "].Amount' type='number' pattern='^[0-9]\d*$' step='1' min='1' value = '' class='form-control'/></td > ";

    var priceCell = "<td><input id='Item_" + index + "__Price' name='Items[" + index + "].Price' type='number' pattern='^[0-9]\d*$' step='1' min='0' value='' class='form-control'/></td > ";

    var removeCell = "<td><input class='btn btn-link' type='button' value='Remove' onclick='removeRow(" + index + ");' /></td>";

    var newRow = "<tr id='trItem" + index + "'>" + indexCell + itemIdCell + nameCell + amountCell + priceCell + removeCell + "</tr>";

    $("#tbItems").append(newRow);
}

function removeRow(id) {
    var controlToBeRemoved = "#trItem" + id;
    $(controlToBeRemoved).remove();
}
