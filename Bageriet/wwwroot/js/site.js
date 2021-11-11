
var $ctrl = "";
$("form").trigger("reset");

// Manage contacts form
function manageContacts(ev) {

    $("input.form-control").each(function () {
        if ($(this).attr("disabled") !== undefined)
            $(this).removeAttr("disabled");
        else
            $(this).attr("disabled", true);
    });

    var s = $("#save_contacts");
    var m = $("#manage_contacts");
    if (s.hasClass("hidden")) {
        s.removeClass("hidden");
        m.html("Avbryta");
    }
    else {
        s.addClass("hidden");
        m.html("Redigera");
    }
}

// New product
function saveProduct(data) {
    var save = {
        type: "POST",
        url: "/Products/SaveNewProduct",
        data: new FormData(data),
        success: function (res) {
            if (res.success) {
                $("#success").removeClass("none");
                setTimeout(function () {
                    $("form").trigger("reset");
                    $("#success").addClass("none");
                }, 3000);
            } else {
                $("#error").removeClass("none");
                setTimeout(function () {
                    $("#error").addClass("none");
                }, 3000);
            }
        }
    };

    if ($(data).attr('enctype') === "multipart/form-data") {
        save['contentType'] = false;
        save['processData'] = false;
    }

    $.ajax(save);
    return false;
}

//Edit contacts
$("#save_contacts").on("click", function () {
    var data = $("[name='contacts']").serialize();

    $.ajax({
        type: "POST",
        url: "/Home/EditContacts",
        data: data,
        success: function (res) {
            if (res.success) {
                $("#success").removeClass("none");
                setTimeout(function () {
                    location.reload();
                }, 2000);
            } else {
                $("#error").removeClass("none");
                setTimeout(function () {
                    $("#error").addClass("none");
                }, 3000);
            }
        }
    });
});

// Register and login
var $form;
var span = "span-link-active";
$("span#authorize").on("click", function () {
    if ($(this).hasClass(span))
        return false;
    $form = $("#dynamicForm").clone();
    $("#dynamicForm").fadeOut();
    $("#dynamicForm").attr("name", "Login");
    $(".heading").html("Logga in");
    setTimeout(function () {
        $("button#reset").hide();
        $("button#send").html("Logga in");
        $("#dynamicForm").css("margin-top", "100px");
        $("div#hide").each(function () {
            $(this).detach();
        });

        $("span#authorize").addClass(span);
        $("span#register").removeClass(span);
        $("#dynamicForm").fadeIn();
        $("div#remember").removeClass("none");
    }, 500)
});

$("span#register").on("click", function () {
    if ($(this).hasClass(span))
        return false;
    $("#dynamicForm").fadeOut().delay(1000).remove();
    $("#dynamicForm").attr("name", "Register");
    $(".heading").html("Registrering");
    setTimeout(function () {
        $("button#send").html("Skicka");
        $("button#reset").fadeIn();
        $("#dynamicForm").removeAttr("style");
        $($form).appendTo(".form-content");

        $("span#register").addClass(span);
        $("span#authorize").removeClass(span);
        $("div#remember").addClass("none");
    }, 500)
});

// Change of file input for bootsrap 4 class
$(".custom-file-input").on("change", function () {
    var fileName = $(this).val().split("\\").pop();
    $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
});

// Send register or login data to db
function sendAuthenticationsData(ev) {
    var _form = $("#dynamicForm");
    var _ctrl = _form.attr("name");
    var data = $(_form).serialize();
    $.ajax({
        type: "POST",
        url: "/Identity/Account/" + _ctrl,
        data: data,
        success: function (res) {
            if (res) {
                location.href = "/";
            } else if (res.error) {
                $("#error").removeClass("none");
                $("#error").html(res.msg);
                setTimeout(function () {
                    $("#error").addClass("none");
                }, 6000);
            }
        }
    });

    return false;
}

// Get grade or comments form
var $event;
$("span#comments, input#cancel").on("click", function () {
    $event = $(this).attr("id");
    if ($("#pam").is(":visible")) {
        $("#pam").fadeOut();
        setTimeout(function () {
            $("#comments_form_block").addClass("visible-block");
        }, 500);
    }
    else {
        $("#comments_form_block").removeClass("visible-block");
        setTimeout(function () {
            $("#pam").fadeIn();
        }, 500)
    }
});

// Add and save data
// Send register or login data to db
function addComments(ev) {
    var data = $(ev).serialize();
    $.ajax({
        type: "POST",
        url: '/Comments/AddComments',
        data: data,
        success: function (res) {
            if (res) {
                location.reload();
            }
        }
    });
    return false;
}

// Add rating
function addRating(id) {
    var productId = parseInt(location.pathname.slice(location.pathname.lastIndexOf("/") + 1));
    var data = ({
        Rating: id,
        ProductId: productId
    });

    $.ajax({
        type: "POST",
        url: '/Products/AddRatingToProduct',
        data: data,
        success: function (res) {
            if (res) {
                location.reload();
            }
        }
    });
}
