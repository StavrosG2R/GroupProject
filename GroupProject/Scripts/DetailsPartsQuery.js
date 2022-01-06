

$(document).ready(function () {
    $("#CaseId").on('change', function () {
        var value = parseInt($(this).val());
        $.ajax({
            url: "/api/Cases/" + value,
            method: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $('#CasesLabel').empty();
                console.log(data);
                $('#CasesLabel').append('<p>' + '<strong>Case Model: </strong>' + data.company.name + ' ' + data.model + '<br/>' + '<strong>Case Size: </strong>' + data.size + '<br />' +
                    '<strong>Number of Fans: </strong>' + data.numberOfFans + '<br />' + '<strong>Case Price: </strong>' + data.price +  "€" + '</p>')
            }
        })
    })
    $("#CpuId").on('change', function () {
        var value = parseInt($(this).val());
        $.ajax({
            url: "/api/CPUs/" + value,
            method: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $('#CPULabel').empty();
                console.log(data);
                $('#CPULabel').append('<p>' + '<strong>CPU Model: </strong>' + data.company.name + ' ' + data.model + '<br/>' + '<strong>Frequency: </strong>' + data.frequency + '<br />' +
                    '<strong>Cores: </strong>' + data.cores + '<br />' + '<strong>Case Price: </strong>' + data.price + " €" + '</p>')
            }
        })
    })
    $("#MotherboardId").on('change', function () {
        var value = parseInt($(this).val());
        $.ajax({
            url: "/api/MotherboardsDetails/" + value,
            method: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $('#MotherboardLabel').empty();
                console.log(data);
                $('#MotherboardLabel').append('<p>' + '<strong>Motherboard Model: </strong>' + data.company.name + ' ' + data.model + '<br/>' + '<strong>Chipset: </strong>' + data.chipset + '<br />' +
                    '<strong>Size: </strong>' + data.size + '<br />' + '<strong>Motherboard Price: </strong>' + data.price + " €" + '</p>')
            }
        })
    })
    $("#RamId").on('change', function () {
        var value = parseInt($(this).val());
        $.ajax({
            url: "/api/RAMs/" + value,
            method: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $('#RamLabel').empty();
                console.log(data);
                $('#RamLabel').append('<p>' + '<strong>RAM Model: </strong>' + data.company.name + ' ' + data.model + '<br/>' + '<strong>Frequency: </strong>' + data.frequency + '<br />' +
                    '<strong>Storage Size: </strong>' + data.storage + ' GB' + '<br />' + '<strong>RAM Price: </strong>' + data.price + " €" + '</p>')
            }
        })
    })
    $("#GpuId").on('change', function () {
        var value = parseInt($(this).val());
        $.ajax({
            url: "/api/GPUs/" + value,
            method: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $('#GpuLabel').empty();
                console.log(data);
                $('#GpuLabel').append('<p>' + '<strong>GPU Model: </strong>' + data.company.name + ' ' + data.model + '<br/>' + '<strong>Memory: </strong>' + data.vram + ' GB' + '<br />' +
                    '<strong>Power Consumption: </strong>' + data.watt + ' Watt' + '<br />' + '<strong>GPU Price: </strong>' + data.price + " €" + '</p>')
            }
        })
    })
    $("#PsuId").on('change', function () {
        var value = parseInt($(this).val());
        $.ajax({
            url: "/api/PSUs/" + value,
            method: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $('#PsuLabel').empty();
                console.log(data);
                $('#PsuLabel').append('<p>' + '<strong>PSU Model: </strong>' + data.company.name + ' ' + data.model + '<br/>' + '<strong>Wattage: </strong>' + data.watt + ' Watt' + '<br />' +
                    '<strong>Modularity: </strong>' + data.modularity + '<br />' + '<strong>PSU Price: </strong>' + data.price + " €" + '</p>')
            }
        })
    })
    $("#StorageId").on('change', function () {
        var value = parseInt($(this).val());
        $.ajax({
            url: "/api/Storages/" + value,
            method: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $('#StorageLabel').empty();
                console.log(data);
                $('#StorageLabel').append('<p>' + '<strong>Storage Model: </strong>' + data.company.name + ' ' + data.model + '<br/>' + '<strong>Capacity: </strong>' + data.capacity + ' GB' + '<br />' +
                    '<strong>Read Speed: </strong>' + data.readSpeed + ' Mb/s' + '<br />' + '<strong>Write Speed: </strong>' + data.writeSpeed + ' Mb/s' + '<br />' +
                    '<strong>PSU Price: </strong>' + data.price + " €" + '</p>')
            }
        })
    })
})

