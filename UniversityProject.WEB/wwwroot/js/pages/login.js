(function (document) {
    // Cache DOM
    const $goLogin = document.querySelector('#go-login'),
        $goRegister = document.querySelector('#go-register'),
        $container = document.querySelector('.container-login'),
        $overlayContainer = document.querySelector('.overlay-container');

    _toggleForm = () => {
        if ($container.classList.contains('go-register')) {
            $container.classList.remove('go-register');
            $container.classList.add('go-login');
            $overlayContainer.classList.add('animateWidth');
            $overlayContainer.addEventListener('webkitTransitionEnd', () => $overlayContainer.classList.remove('animateWidth'));
        } else {
            $container.classList.remove('go-login');
            $container.classList.add('go-register');
            $overlayContainer.classList.add('animateWidth');
            $overlayContainer.addEventListener('webkitTransitionEnd', () => $overlayContainer.classList.remove('animateWidth'));
        }
    };


    $goLogin.addEventListener('click', _toggleForm);
    $goRegister.addEventListener('click', _toggleForm);
})(document);

let emailField = "#email";
let emailErrorMessage = "#registerErrorMessage";
$(emailField).focusout(function () {
    validateEmailField();
});
function validateEmailField() {
    let fieldValue = $(emailField).val();
    let regex = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    if (fieldValue === "") {
        $(emailErrorMessage).text("The field can't be empty.");
        $(emailErrorMessage).removeClass("d-none");
        emailValidation = false;
        return;
    }

    if (!regex.test(fieldValue)) {
        $(emailErrorMessage).text("The field does not fit the requirements. Please, try again.");
        $(emailErrorMessage).removeClass("d-none");
        emailValidation = false;
        return;
    }

    $(emailErrorMessage).addClass("d-none");
    emailValidation = true;
}