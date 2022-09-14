$(document).ready(function () {
    $("#sendButton").click(function(e){
        e.preventDefault();
        sendEmail();
        alert("Mesaj uğurla göndərildi!");
    });
    function sendEmail() {
        const params = {
            message: $("#text-message").val(),
            firstName: $("#first-name").val(),
            lastName: $("#last-name").val(),
            emailAddress: $("#email-address").val(),
            phoneNumber: $("#phone-number").val(),
        }
        emailjs.send('DynamexHotmail', 'DynamexContactForm', params)
    }
});