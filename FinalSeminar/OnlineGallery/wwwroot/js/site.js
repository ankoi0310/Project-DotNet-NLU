showInPopup = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $("#form-modal .modal-body").html(res);
            $("#form-modal .modal-title").html(title);
            $("#form-modal").modal("show");
        }
    })
}

jQueryAjaxPost = (form) => {
    try {
        $.ajax({
            type: "POST",
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $("#view-all").html(res.html);
                    setInterval('location.reload()', 100);
                    $("#form-modal").modal('hide');
                    $("#form-modal .modal-body").html('');
                    $("#form-modal .modal-title").html('');
                } else {
                    $("#form-modal .modal-body").html(res.html);
                }
            },
            error: function (err) {
                console.log(err);
            }
        })
    } catch (e) {
        console.log(e);
    }

    return false;
}

jQueryAjaxDelete = form => {
    if (confirm("Are you sure to delete this record?")) {
        try {
            $.ajax({
                type: "POST",
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    $("#view-all").html(res.html);
                    setInterval('location.reload()', 100);
                    //$.notify("Deleted successfully", { globalPosition: "top center", className: "success" });
                },
                error: function (err) {
                    console.log(err);
                }
            })
        } catch (e) {
            console.log(e);
        }
    }

    return false;
}

jQueryAjaxSoldConfirm = form => {
    if (confirm("Do you confirm the product has been sold?")) {
        try {
            $.ajax({
                type: "POST",
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    $("#view-all").html(res.html);
                    setInterval('location.reload()', 100);
                },
                error: function (err) {
                    console.log(err);
                }
            })
        } catch (e) {
            console.log(e);
        }
    }

    return false;
}