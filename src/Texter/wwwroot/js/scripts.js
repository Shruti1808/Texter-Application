$(document).ready(function () {
    $('.display-contact').click(function () {
        $.ajax({
            type: 'GET',
            //dataType: "json",
            //contentType: "application/json",
            url: 'Home/DisplayContact',
            success: function (result) {
                var resultString = 'Name: ' + result.name + '. Phone: ' + result.phoneNumber;
                $('#result').html(resultString);
            }
        });
    });
    $('.add-contact').submit(function (e) {
        e.preventDefault();
        $.ajax({
            type: "POST",
            dataType: "json",
            data: $(this).serialize(),
            url: 'Home/AddContact',
            success: function (result) {
                console.log(result)
                var resultMessage = 'Name: ' + result.name + 'Phone: ' + result.phoneNumber;
                $('#new-contact').html(resultMessage);
            },
            error: function(result){
            console.log(result);
        }
        });
    })

});