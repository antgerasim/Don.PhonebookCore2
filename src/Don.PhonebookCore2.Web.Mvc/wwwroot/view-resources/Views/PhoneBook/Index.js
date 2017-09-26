(function($) {

    var personService = abp.services.app.person;
    var $modal = $("#PersonCreateModal");
    var $form = $modal.find("form");

    $form.validate({
    });

/*    $form.validate({
        rules: {
            Name: "required",
            Surname: "required",
            EmailAddress: "required"
        }n
    });*/

    //Handle createPerson button
    $("#CreateNewPersonButton").click(function(e) {
        e.preventDefault();
        abp.ajax({
                url: abp.appPath + "PhoneBook/CreatePersonModal",
                type: "POST",
                //contentType: "application/html",
                dataType: "html",
                contentType: "application/x-www-form-urlencoded",
                /*    data: {
                        personId: personId
                    }*/
            })
            .done(function(result) {
                $("#PersonCreateModal div.modal-content").html(result);
                $(".personCreateModal").modal("show");
            });

        console.log("Handle createPerson button ficken");
    });



    //handle remove button click
    $("#AllPeopleList button.delete-person").click(function(e) {
        e.preventDefault();
        e.stopPropagation(); //prevents boostrap collapse from collapsing on click

        var $listItem =
            $(this)
                .closest(
                    ".list-group-item"); //closest - travels up the DOM tree and returns the first ancestor that matches the passed expression.
        var personId = $listItem.attr("data-person-id");

        abp.message.confirm(
            abp.localization
            .localize("AreYouSureToDeleteThePerson", "PhonebookCore2"),
            function(isConfirmed) {
                if (isConfirmed) {
                    personService.deletePerson({
                            id: personId
                        })
                        .done(function() {
                            abp.notify.info(abp.localization
                                .localize("SuccessfullyDeleted", "PhonebookCore2"));
                            $listItem.remove();
                        });
                }
            }
        );
    });

    $modal.on("shown.bs.modal",
        function() {
            $modal.find("input:not([type=hidden]):first").focus();

        });

    $("#RefreshButton").click(function() {
        refreshUserList();
    });

    function refreshUserList() {
        location.reload(true); //reload page to see new user!
    }



    //Save phone button
    $("#AllPeopleList .button-save-phone").click(function(e) {
        e.preventDefault();

        var $phoneEditorRow = $(this).closest("tr");
        var personId = parseInt($phoneEditorRow.closest(".list-group-item").attr("data-person-id"), 10);
        var type = parseInt($phoneEditorRow.find("select[name=Type]").val(), 10);
        var number = $phoneEditorRow.find("input[name=Number]").val();

        abp.ajax({
                url: abp.appPath + "PhoneBook/AddPhone",
                type: "POST",
                dataType: "html", //type of data expecting back from server 
                contentType: "application/x-www-form-urlencoded", //since request to controller (not web proxy service)
                //contentType: 'application/json', 
/*                    data: JSON.stringify({
                        personId: personId,
                        Type: type,
                        Number: number
                    })*/
                data: {
                    personId: personId,
                    Type: type,
                    Number: number
                }
            })
            .done(function(result) {
                $(result).insertBefore($phoneEditorRow);
            });
    });

    //Delete phone button
    $("#AllPeopleList").on("click",
        ".button-delete-phone",
        function(e) {
            e.preventDefault();

            var $phoneRow = $(this).closest("tr");
            var phoneId = $phoneRow.attr("data-phone-id");

            personService.deletePhone({
                    id: phoneId
                })
                .done(function() {
                    abp.notify.success(abp.localization.localize("SuccessfullyDeleted", "PhonebookCore2"));
                    $phoneRow.remove();
                });
        });

    //Edit person button modal
    $("#AllPeopleList button.edit-person").click(function(e) {
        e.preventDefault();
        e.stopPropagation(); //prevents boostrap collapse from collapsing on click
        var $listItem = $(this).closest(".list-group-item");
        //$listItem.toggleClass("person-editing").siblings().removeClass("person-editing");
        $listItem.addClass("person-editing").siblings().removeClass("person-editing");


        var personId = $listItem.attr("data-person-id");
        abp.ajax({
                url: abp.appPath + "PhoneBook/EditPersonModal",
                type: "POST",
                //contentType: "application/html",
                dataType: "html",
                contentType: "application/x-www-form-urlencoded",
                data: {
                    personId: personId
                }
            })
            .done(function(result) {
                $("#PersonEditModal div.modal-content").html(result);
                $(".personEditModal").modal("show");
            }).always(function() {
                //debugger;
                //$listItem.removeClass("person-editing");
            });
    });
})(jQuery);