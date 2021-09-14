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
                    $("#form-modal").modal('hide');
                    $("#form-modal .modal-body").html('');
                    $("#form-modal .modal-title").html('');
                    location.reload();
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

bidding = (form) => {
    try {
        $.ajax({
            type: "POST",
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    location.reload();
                } else {
                    $.notify(res.status, { globalPosition: "top center", className: "error" });
                }
            },
            error: function (err) {
                window.location.href = form.action;
            }
        })
    } catch (e) {
        console.log(e);
    }

    return false;
}

jQueryAjaxFavorites = (url) => {
    try {
        $.ajax({
            type: "POST",
            url: url,
            data: null,
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.id != 0) {
                    if (res.like) {
                        $("#like-feature-" + res.id).html("<i class='fas fa-star'></i>");
                        $("#like-" + res.id).html("<i class='fas fa-star'></i>");
                        $("#like-detail-" + res.id).html("<span  class='font-weight-bolder'>You have liked this <i class='fas fa-star'></i></span>");
                        $.notify(res.status, { globalPosition: "top center", className: "success" });
                    } else {
                        $("#like-feature-" + res.id).html("<i class='far fa-star'></i>")
                        $("#like-" + res.id).html("<i class='far fa-star'></i>")
                        $("#like-detail-" + res.id).html("<span  class='font-weight-bolder'>Add to your favorites <i class='far fa-star'></i></span>");
                        $.notify(res.status, { globalPosition: "top center", className: "error" });
                    }
                } else {
                    $.notify(res.status, { globalPosition: "top center", className: "error" });
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
                    location.reload();
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

lockoutUser = form => {
    if (confirm("Are you sure to do this action?")) {
        try {
            $.ajax({
                type: "POST",
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    location.reload();
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

addToCart = (url) => {
    try {
        $.ajax({
            type: "POST",
            url: url,
            data: null,
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.id != 0) {
                    if (res.add) {
                        //$("#like-feature-" + res.id).html("<i class='fas fa-star'></i>");
                        //$("#like-" + res.id).html("<i class='fas fa-star'></i>");
                        //$("#like-detail-" + res.id).html("<span><i class='fas fa-star'></i>&nbsp;You have liked this</span>");
                        $.notify(res.status, { globalPosition: "top center", className: "success" });
                    } else {
                        //$("#like-feature-" + res.id).html("<i class='far fa-star'></i>")
                        //$("#like-" + res.id).html("<i class='far fa-star'></i>")
                        //$("#like-detail-" + res.id).html("<span><i class='far fa-star'></i>&nbsp;Add to your favorites</span>");
                        $.notify(res.status, { globalPosition: "top center", className: "error" });
                    }
                } else {
                    $.notify(res.status, { globalPosition: "top center", className: "error" });
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

removeFromCart = (url) => {
    try {
        $.ajax({
            type: "POST",
            url: url,
            data: null,
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.remove) {
                    $.notify(res.status, { globalPosition: "top center", className: "success" });
                }
                else {
                    $.notify(res.status, { globalPosition: "top center", className: "error" });
                }
                var $cartbody = $("#cart-body").html().replace(/\s/g, '');
                if ($cartbody == "") {
                    $("#cart-body").html("<tr><td colspan='4' class='align-middle text-center'>No data available in table</td></tr>");
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

sendMail = (form) => {
    try {
        $.ajax({
            type: "POST",
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $.notify(res.status, { globalPosition: "top center", className: "success" });
                } else {
                    $.notify(res.status, { globalPosition: "top center", className: "error" });
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