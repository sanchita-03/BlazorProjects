// wwwroot/js/recaptcha.js

window.loadCaptcha = function () {
    if (typeof grecaptcha !== "undefined") {
        grecaptcha.render("captcha-container", {
            sitekey: "6LffhZYrAAAAAKTUf6J7GJl9zfMLW8dhRptNOG6h"
        });
    } else {
        console.error("reCAPTCHA not loaded yet");
    }
};

window.getCaptchaToken = function () {
    return grecaptcha.getResponse();
};
