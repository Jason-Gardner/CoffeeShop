var password = document.getElementByName("password")
    , cpassword = document.getElementByName("cpassword");

function validatePassword() {
    if (password.value != cpassword.value) {
        cpassword.setCustomValidity("Passwords Don't Match");
    } else {
        cpassword.setCustomValidity('');
    }
}

password.onchange = validatePassword;
cpassword.onkeyup = validatePassword;

