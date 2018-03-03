$(function () {

    function validateEmail(email) {
        var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(String(email).toLowerCase());
    }

    $("#sign-up-btn").on("click", function() {

        var email = $("#email").val();
        if (email.length <= 0) {
            alert("Email can not be empty!");
            return;
        }

        if (!validateEmail(email)) {
            alert("Email is not valid!");
            return;
        }

        var options = {
            enableHighAccuracy: true,
            timeout: 5000,
            maximumAge: 0
        };

        function success(pos) {
            var crd = pos.coords;

            console.log('Your current position is:');
            console.log(`Latitude : ${crd.latitude}`);
            console.log(`Longitude: ${crd.longitude}`);

            var request = $.ajax({
                url: "/api/sitecore/Registration/register",
                type: "post",
                data: {
                    email: email,
                    lat: crd.latitude,
                    lon: crd.longitude
                }
            });

            request.done(function (response, textStatus, jqXHR) {
                alert("Contact with email: " + email + " signed up successfully");
                $("#email").val("");
            });

            request.fail(function (jqXHR, textStatus, errorThrown) {
                alert("The following error occurred: " + textStatus);
                console.log(errorThrown);
            });


            //$.ajax({
            //    type: "POST",
            //    url: "/api/sitecore/registration/register",
            //    data: {
            //        email: email,
            //        lat: crd.latitude,
            //        lon:crd.longitude
            //    },
            //    success: function() {
            //        alert("Contact signed up successfully");
            //    },
            //});
        };

        function error(err) {
            alert(`ERROR(${err.code}): ${err.message}`);
        };

        navigator.geolocation.getCurrentPosition(success, error, options);
        return false;
    });
});