$(function () {
    $.ajaxSetup({ cache: false });
    $(".compItem").click(function (e) {

        e.preventDefault();
        $.get(this.href, function (data) {
            $('#dialogContent').html(data);
            $('#editModal').modal('show');
        });
    });
});

$(function () {
    $('#modal-conten').submit(function () {
        $.ajax({
            url: '@Url.Action("EditCategory","Category")',
            type: "Post",
            data: $("#modal-conte").serialize(),
            success: function (result) {
                if (result.success) {
                    $("#dialog-alert").html("Data has been updated succeessfully");
                } else {

                }
            }
        });
        return false;
    });
});


(function () {
    'use strict';
    window.addEventListener('load', function () { //'turbolinks:load
        // Fetch all the forms we want to apply custom Bootstrap validation styles to
        var forms = document.getElementsByClassName('needs-validation');
        // Loop over them and prevent submission
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                form.classList.add('was-validated');
            }, false);
        });
    }, false);
})();