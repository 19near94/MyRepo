$(document).ready(function () {

    $("#exampleModalCenter").modal({ backdrop: false })


})


function login()
{

    var usr = $('#usr').val();
    var pwd = $('#pwd').val();

    $.ajax({
        type: 'POST',
        url: globalBaseURL+'Login/Login',
        data: JSON.stringify({usr : usr,pwd:pwd }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            alert(data);
        },
        error: function (err) {
            console.log(err);
            alert(err);
        }

    })



}