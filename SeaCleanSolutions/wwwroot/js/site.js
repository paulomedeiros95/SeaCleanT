
// Write your Javascript code.
var expanded = false;

function showCheckboxes() {
    var checkboxes = document.getElementById("checkboxes");
    if (!expanded) {
        checkboxes.style.display = "block";
        expanded = true;
    } else {
        checkboxes.style.display = "none";
        expanded = false;
    }
}

$(document).ready(function () {
    $('#btnUpload').on('click', function () {
        var files = $('#fUpload').prop("files");
        var fdata = new FormData();
        for (var i = 0; i < files.length; i++) {
            fdata.append("files", files[i]);
        }
        if (files.length > 0) {
            $.ajax({
                type: "POST",
                url: "/ConfigureCourse?handler=Upload",
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("XSRF-TOKEN",
                        $('input:hidden[name="__RequestVerificationToken"]').val());
                },
                data: fdata,
                contentType: false,
                processData: false,
                success: function (response) {
                    alert('File Uploaded Successfully.')
                    location.reload();
                }

            });
        }
        else {
            alert('Please select a file.')
        }
    })
});