
        $("form").submit(function (event) {
            event.preventDefault();
            $form = $(this);
            $button = $(this).find("button[type=submit]");

            $.ajax({
                url: $form.attr("action"),
                data: $form.serialize(),
                beforeSend: function () {
                    $button.attr("disabled", "disabled");

                },
                beforeSend: function () {
                    $button.removeAttr("disabled");
                },
                success: function (response) { 
                    if (response.status == 200) {
                        Swal.fire({
                            title: "Success",
                            type: "success",
                            text: response.message,
                            confirmButtonText: 'Cool'
                        });
                        setTimeout(function() {
                                //if (returnUrl != "") {
                                //    location.href = returnUrl;
                                //} else {
                                location.reload();
                                //}

                            },
                            5000);
                    } else {
                        Swal.fire({
                            title: "Error",
                            type: "error",
                            text: response.message,
                            confirmButtonText: 'Try Again'
                        });
                    }
                  
                }
            })
        });
  
