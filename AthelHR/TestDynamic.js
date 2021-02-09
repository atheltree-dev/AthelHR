
$(document).ready(function () {
    //GetData();
});




function GetData() {
    debugger;
    var result;
    $.ajax({
        type: "POST",
        url: "/WebForm1.aspx/GetData",  //GeneralHelperAjaxUrl + 
        data: '',
        contentType: "application/json",
        dataType: "json",
        async: false,
        success: function (data) {
            debugger;
            result = data.d

        }

    });
    return result;
}

function GenerateTable() {
    //Build an array containing Customer records.
    //var customers = new Array();
    //// you could use ajax call webmethod, then return json array
    //var jsondata = [
    //    { "CustomerID": "1", "Name": "Mudassar Khan", "Country": "India" },
    //    { "CustomerID": "1", "Name": "Suzanne Mathews", "Country": "France" },
    //    { "CustomerID": "1", "Name": "Robert Schidner", "Country": "Russia" }
    //];
    //customers.push(["Customer Id", "Name", "Country"]);
    //for (var i = 0; i < jsondata.length; i++) {
    //    customers.push([jsondata[i].CustomerID, jsondata[i].Name, jsondata[i].Country]);
    //}

    debugger;
    var Data = GetData();
    debugger;
    $('#dvTable').append(Data);
    //Create a HTML Table element.
    //var table = document.createElement("TABLE");
    //table.border = "1";

    ////Get the count of columns.
    //var columnCount = customers.[0].length;

    ////Add the header row.
    //var row = table.insertRow(-1);
    //for (var i = 0; i < columnCount; i++) {
    //    var headerCell = document.createElement("TH");
    //    headerCell.innerHTML = customers[0][i];
    //    row.appendChild(headerCell);
    //}

    ////Add the data rows.
    //for (var i = 1; i < customers.length; i++) {
    //    row = table.insertRow(-1);
    //    for (var j = 0; j < columnCount; j++) {
    //        var cell = row.insertCell(-1);
    //        cell.innerHTML = customers[i][j];
    //    }
    //}

    //var dvTable = document.getElementById("dvTable");
    //dvTable.innerHTML = "";
    //dvTable.appendChild(table);
}




