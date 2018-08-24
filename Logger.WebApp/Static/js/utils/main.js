
var timerTemClassId = 0;
var main_ns = {};
main_ns.SELECTOR = null;

///////////////// utils methods

main_ns.msgGeneral = function (message, classname, selector) {
    clearInterval(timerTemClassId);
    main_ns.msgHide();    

    if (typeof selector === "undefined") {
        if (main_ns.SELECTOR === null) {
            $.notify(message, classname);
        }
        else {
            $(main_ns.SELECTOR).notify(message, classname);
        }        
    }
    else {
        $(selector).notify(message, classname);
    }
    
    if (selector === main_ns.SELECTOR) {
        $("body").addTempClass("margin-notifications-main", 10000);
    }    
};

main_ns.msgError = function (message, selector) {    
    main_ns.msgGeneral(message,"error", selector);
};

main_ns.msgWarn = function (message, selector) {
    main_ns.msgGeneral(message, "warn", selector);    
};

main_ns.msgInfo = function (message, selector) {
    main_ns.msgGeneral(message, "info", selector);    
};

main_ns.msgSuccess = function (message, selector) {
    main_ns.msgGeneral(message, "success", selector);    
};

main_ns.msgHide = function () {
    $(".notifyjs-wrapper").trigger('notify-hide');
    $("#main_container").removeClass("margin-notifications-main");
};

main_ns.getParameterByName = function (name) {
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\?&]" + name + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(document.location.href);
    if (results == null)
        return "";
    else
        return decodeURIComponent(results[1].replace(/\+/g, " "));
};

main_ns.removeURLParameter = function (parameter) {
    var url = document.location.href;
    var urlparts = url.split('?');
    if (urlparts.length >= 2) {

        var prefix = encodeURIComponent(parameter) + '=';
        var pars = urlparts[1].split(/[&;]/g);

        for (var i = pars.length; i-- > 0;) {
            if (pars[i].lastIndexOf(prefix, 0) !== -1) {
                pars.splice(i, 1);
            }
        }

        url = urlparts[0] + '?' + pars.join('&');
        return url;
    } else {
        return url;
    }
};

main_ns.VerifyBrowserSupportInputByType = function (value) {
    var i = document.createElement("input");
    i.setAttribute("type", value);
    return i.type !== "text";
};

main_ns.getInternetExplorerVersion = function () {
    var rv = -1; // Return value assumes failure.
    if (navigator.appName == 'Microsoft Internet Explorer') {
        var ua = navigator.userAgent;
        var re = new RegExp("MSIE ([0-9]{1,}[\.0-9]{0,})");
        if (re.exec(ua) != null)
            rv = parseFloat(RegExp.$1);
    }
    return rv;
};

main_ns.checkVersion = function () {
    var msg = "You're not using Internet Explorer.";
    var ver = main_ns.getInternetExplorerVersion();

    if (ver > -1) {
        if (ver >= 6.0)
            msg = "You're using a recent copy of Internet Explorer."
        else
            msg = "You should upgrade your copy of Internet Explorer.";
    }
    alert(msg);
};

main_ns.endsWith = function (str, suffix) {
    return str.indexOf(suffix, str.length - suffix.length) !== -1;
};

main_ns.countProperties = function (obj) {
    if (main_ns.getInternetExplorerVersion() == -1) {
        return Object.keys(obj).length;
    }
    else {
        var count = 0;
        for (var k in obj) {
            if (obj.hasOwnProperty(k)) {
                ++count;
            }
        }
        return count;
    }
};

main_ns.getFileName = function (path_file) {
    var reg = new RegExp(/([^\/\\]+)$/);
    var result = reg.exec(path_file);
    return result != null ? result[0] : result;
};

main_ns.getFileSizeMB = function (id) {
    try {
        var fileSize = 0;
        var scale = 1048576; // 1024*1024
        if (main_ns.getInternetExplorerVersion() > -1 && main_ns.getInternetExplorerVersion() <= 9) {
            fileSize = 2;
        }
        else
            if (main_ns.getInternetExplorerVersion() > 9) {
                var objFSO = new ActiveXObject("Scripting.FileSystemObject");
                var filePath = $("#" + id)[0].value;
                var objFile = objFSO.getFile(filePath);
                if (typeof (objFile) !== "undefined") fileSize = objFile.size / scale;
                //fileSize = 1000;
            }
            else {
            if (typeof ($("#" + id)[0].files[0]) !== "undefined") fileSize = $("#" + id)[0].files[0].size / scale;
        }

        return fileSize;
    }
    catch (e) {
        console.log("Error en obtener el tamaño del archivo :" + e);
        return 0;
    }
};

main_ns.getCookie = function (name) {
    var r = document.cookie.match("\\b" + name + "=([^;]*)\\b");
    //return r ? r[1] : undefined;
    return r ? r[1] : "";
};

main_ns.createCookie = function (name, value, days) {
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        var expires = "; expires=" + date.toGMTString();
    }
    else var expires = "";
    document.cookie = name + "=" + value + expires + "; path=/";
};

main_ns.readCookie = function (name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
};

main_ns.deleteCookie = function (name) {
    main_ns.createCookie(name, "", -1);
};

main_ns.getPeriod = function (date) {
    try {
        return date.getFullYear() + "" + (("" + (date.getMonth() + 1)).length == 1 ? "0" + (date.getMonth() + 1) : "" + (date.getMonth() + 1));
    } catch (e) {
        console.log(e);
        return "";
    }
};

main_ns.getCurrentPeriod = function () {
    var date = new Date();
    return main_ns.getPeriod(date);
};

main_ns.renderTemplate = function (_selector, _template, data) {
    $(_selector).html("");
    var templatehtml = $(_template).html();
    var sourcehtml = Handlebars.compile(templatehtml);
    $(_selector).html(sourcehtml({ ListData: data }));
};

main_ns.validateEmail = function (_email, _re) {
    return _re.test(_email);
};

// dates utils
Date.prototype.formatDDMMYYYY = function () {
    return (("" + this.getDate()).length == 1 ? "0" + (this.getDate()) : (this.getDate())) +
            "/" + (("" + (this.getMonth() + 1)).length == 1 ? "0" + (this.getMonth() + 1) : (this.getMonth() + 1)) +
            "/" + this.getFullYear();
}

Date.prototype.formatDDMMYYYY2 = function () {
    return (("" + this.getDate()).length == 1 ? "0" + (this.getDate()) : (this.getDate())) +
            "-" + (("" + (this.getMonth() + 1)).length == 1 ? "0" + (this.getMonth() + 1) : (this.getMonth() + 1)) +
            "-" + this.getFullYear();
}

Date.prototype.formatDDMMYYYY3 = function () {
    return (("" + this.getDate()).length == 1 ? "0" + (this.getDate()) : (this.getDate())) +
            "-" + (("" + (this.getMonth() + 1)).length == 1 ? "0" + (this.getMonth() + 1) : (this.getMonth() + 1)) +
            "-" + (this.getFullYear() + "").substr(2, 2);
}

Date.prototype.formatYYYYMMDD = function () {
    return this.getFullYear() +
        "-" + (("" + (this.getMonth() + 1)).length == 1 ? "0" + (this.getMonth() + 1) : (this.getMonth() + 1)) +
        "-" + (("" + this.getDate()).length == 1 ? "0" + (this.getDate()) : (this.getDate()));
}

if (!String.prototype.format) {
    String.prototype.format = function () {
        var args = arguments;
        return this.replace(/\{(\d+)\}/g, function (match, number) {
            return typeof args[number] != 'undefined' ? args[number] : match;
        });
    };
}

if (typeof String.prototype.trim !== 'function') {
    String.prototype.trim = function () {
        return this.replace(/^\s+|\s+$/g, '');
    }
}

(function ($) {

    $.fn.extend({

        addTempClass: function (className, duration) {
            var elements = this;
            timerTemClassId = setTimeout(function () {
                elements.removeClass(className);
            }, duration);

            return this.each(function () {
                $(this).addClass(className);
            });
        }
    });

})(jQuery);

////////////////

$(document).on("click", ".notifyjs-container", function () {
    $("#main_container").removeClass("margin-notifications-main");
});

$("#imgLogo").on("click", function () {
    $('.navbar-perutourism-collapse').collapse('hide');
});

$(document).on("click", "#btnLanguage", function () {
    var lang = $(this).attr("data-lang") == "es" ? "en" : "es";
    i18n_ns.setLang(lang, true);
    location.reload();
});

$(document).ready(function () {
    $.notify.defaults({
        // whether to hide the notification on click
        clickToHide: true,
        // whether to auto-hide the notification
        autoHide: true,
        // if autoHide, hide after milliseconds
        autoHideDelay: 10000,
        // show the arrow pointing at the element
        arrowShow: true,
        // arrow size in pixels
        arrowSize: 5,
        // default positions
        elementPosition: 'bottom center',
        globalPosition: 'top center', // top rigth, bottom rigth  *** 'bottom left'
        // default style
        style: 'bootstrap',
        // default class (string or [string])
        className: 'info', // success, info, warn, error
        // show animation
        showAnimation: 'slideDown',
        // show animation duration
        showDuration: 400,
        // hide animation
        hideAnimation: 'slideUp',
        // hide animation duration
        hideDuration: 200,
        // padding between element and notification
        gap: 0
    });

    // sample to this project
    // $("#menuHeader").notify("Texto de ejemplo de notificacion ........","info");
    // $("#menuHeader").notify("Texto de ejemplo de notificacion ........","success");
    // $("#menuHeader").notify("Texto de ejemplo de notificacion ........","warn");
    // $("#menuHeader").notify("Texto de ejemplo de notificacion ........","error");

    var letras_latinas = /^[0-9a-zA-ZáéíóúàèìòùÀÈÌÒÙÁÉÍÓÚñÑüÜ_-\s]+$/;

    $("#linkChangePasswd").on("click", function(){
        $("#pnlChangePasswd_body input[type='password']").val("");
        $("#pnlChangePasswd").modal("show");
    });

    $("#btnChangePasswd").on("click", function () {
        var currentpasswd = $("#txtCurrentPasswd").val();
        var newpasswd = $("#txtNewPasswd").val();
        var renewpasswd = $("#txtRepeatNewPasswd").val();

        if (currentpasswd.trim() !== "" && newpasswd.trim() !== "" && renewpasswd.trim() !== "") {

            if (newpasswd !== renewpasswd) {
                alert("Claves no coinciden.");
                return false;
            }

            if (!$.trim(newpasswd).match(letras_latinas)) {
                alert('El campo Nueva Contraseña contiene caracteres invalidos.'); $('#txtNewPasswd').focus(); return;
            }
            else if ($.trim($("#txtNewPasswd").val()).length < 8) { alert('El campo Nueva Contraseña debe ser mayor igual a 8 caracteres.'); $('#txtNewPasswd').focus(); return false; }
            else {
                var banderaMayuscula = false;
                var banderaMinuscula = false;
                for (var t = 0; t < $.trim($("#txtNewPasswd").val()).length; t++) {
                    var letra = $.trim($("#txtNewPasswd").val()).substr(t, 1);
                    if (letra >= 'A' && letra <= 'Z')
                        banderaMayuscula = true;
                    else if (letra >= 'a' && letra <= 'z')
                        banderaMinuscula = true;
                }

                if (!banderaMayuscula) { alert('El campo Nueva Contraseña debe contener un caracter en mayúscula.'); $('#txtNewPasswd').focus(); return false; }
                if (!banderaMinuscula) { alert('El campo Nueva Contraseña debe contener un caracter en minúscula.'); $('#txtNewPasswd').focus(); return false; }
            }

            var input = {};
            input.passwd = currentpasswd;
            input.newpasswd = newpasswd;
            input.renewpasswd = renewpasswd;
            
            request_ns.post_json(main_ns.url.ChangePasswd, input,
                function (data) {
                    try {

                        if (data.error === 0) {
                            $("#pnlChangePasswd").modal("hide");
                            alert("Se actualizo la clave satisfactoriamente.");
                        }
                        else {
                            alert(data.msg);
                        }

                    } catch (e) {
                        console.log(e);
                        alert("Sucedió un error inesperado.");
                    }
                }
            );
        }
        else {
            alert("Ingrese datos.");
        }
    });

}); // end document ready

