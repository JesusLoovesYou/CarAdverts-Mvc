//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadData();
});

//Load Data function  
function loadData() {
    //if (filter === undefined) {
    //    filter = '';
    //}

    $.ajax({
        url: "/AjaxAdvert/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                
                html += '<tr>';
                html += '<td><strong>' + item.Title + '</strong></td>';
                html += '<td>' + item.VehicleModelId + '</td>';
                html += '<td>' + item.Year + '</td>';
                html += '<td>' + item.Price + '</td>';
                html += '<td>' + item.Power + '</td>';
                html += '<td>' + item.DistanceCoverage + '</td>';
                html += '<td>' + item.CityId + '</td>';
                html += '<td>' + item.Description + '</td>';
                html += '<td><a href="#" onclick="return getById(' + item.Id + ')">Edit</a> | <a href="#" onclick="Delele(' + item.Id + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Filter data
function Filter(filter) {

    $.ajax({
        url: "/AjaxAdvert/Filter/" + filter,
        //data: JSON.stringify(filter),
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Add Data Function   
function Add() {
    var res = validate();
    if (res === false) {
        return false;
    }

    var advertObj = {
        Title: $('#Title').val(),
        VehicleModelId: $('#VehicleModelId').val(),
        Year: $('#Year').val(),
        Price: $('#Price').val(),
        Power: $('#Power').val(),
        DistanceCoverage: $('#DistanceCoverage').val(),
        CityId: $('#CityId').val(),
        Description: $('#Description').val()
    };

    $.ajax({
        url: "/AjaxAdvert/Add",
        data: JSON.stringify(advertObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for getting the Data Based upon Employee ID  
function getById(advId) {
    $('#Title').css('border-color', 'lightgrey');
    $('#VehicleModelId').css('border-color', 'lightgrey');
    $('#Year').css('border-color', 'lightgrey');
    $('#Price').css('border-color', 'lightgrey');
    $('#Power').css('border-color', 'lightgrey');
    $('#DistanceCoverage').css('border-color', 'lightgrey');
    $('#CityId').css('border-color', 'lightgrey');
    $('#Description').css('border-color', 'lightgrey');

    $.ajax({
        url: "/AjaxAdvert/GetById/" + advId,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#Title').val(result.Title);
            $('#VehicleModelId').val(result.VehicleModelId);
            $('#Year').val(result.Year);
            $('#Price').val(result.Price);
            $('#Power').val(result.Power);
            $('#DistanceCoverage').val(result.DistanceCoverage);
            $('#CityId').val(result.CityId);
            $('#Description').val(result.Description);
            $('#Id').val(result.Id);
            $('#UserId').val(result.UserId);
            
            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

    return false;
}

//function for updating advert's record  
function Update() {
    //
    var res = validate();
    if (res === false) {
        return false;
    }
    var advertObj = {
        Title: $('#Title').val(),
        VehicleModelId: $('#VehicleModelId').val(),
        Year: $('#Year').val(),
        Price: $('#Price').val(),
        Power: $('#Power').val(),
        DistanceCoverage: $('#DistanceCoverage').val(),
        CityId: $('#CityId').val(),
        Description: $('#Description').val(),
        Id: $('#Id').val(),
        UserId: $('#UserId').val()
    };

    $.ajax({
        url: "/AjaxAdvert/Update",
        data: JSON.stringify(advertObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#Title').val("");
            $('#VehicleModelId').val("");
            $('#Year').val("");
            $('#Price').val("");
            $('#Power').val("");
            $('#DistanceCoverage').val("");
            $('#CityId').val("");
            $('#Description').val("");
            $('#Id').val("");
            $('#UserId').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for deleting employee's record  
function Delele(id) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/AjaxAdvert/Delete?id=" + id,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

//Function for clearing the textboxes  
function clearTextBox() {
    $('#Title').val("");
    $('#VehicleModelId').val("");
    $('#Year').val("");
    $('#Price').val("");
    $('#Power').val("");
    $('#DistanceCoverage').val("");
    $('#CityId').val("");
    $('#Description').val("");

    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#Title').css('border-color', 'lightgrey');
    $('#VehicleModelId').css('border-color', 'lightgrey');
    $('#Year').css('border-color', 'lightgrey');
    $('#Price').css('border-color', 'lightgrey');
    $('#Power').css('border-color', 'lightgrey');
    $('#DistanceCoverage').css('border-color', 'lightgrey');
    $('#CityId').css('border-color', 'lightgrey');
    $('#Description').css('border-color', 'lightgrey');
}

//Valdidation using jquery                                        ---------------------------------- validation -----------------
function validate() {
    var isValid = true;
    if ($('#Title').val().trim() == "") {
        $('#Title').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Title').css('border-color', 'lightgrey');
    }
    if ($('#VehicleModelId').val().trim() == "") {
        $('#VehicleModelId').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#VehicleModelId').css('border-color', 'lightgrey');
    }
    if ($('#Year').val().trim() == "") {
        $('#Year').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Year').css('border-color', 'lightgrey');
    }
    if ($('#Price').val().trim() == "") {
        $('#Price').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Price').css('border-color', 'lightgrey');
    }
    if ($('#Power').val().trim() == "") {
        $('#Power').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Power').css('border-color', 'lightgrey');
    }
    if ($('#DistanceCoverage').val().trim() == "") {
        $('#DistanceCoverage').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#DistanceCoverage').css('border-color', 'lightgrey');
    }
    if ($('#CityId').val().trim() == "") {
        $('#CityId').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CityId').css('border-color', 'lightgrey');
    }
    if ($('#Description').val().trim() == "") {
        $('#Description').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Description').css('border-color', 'lightgrey');
    }
    return isValid;
}
