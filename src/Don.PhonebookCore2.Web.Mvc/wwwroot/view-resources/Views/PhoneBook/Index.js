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
        }
    });*/

    //Handle save button click
    $form.closest("div.modal-content")
        .find(".save-button")
        .click(function(e) {
            e.preventDefault();
            save();
        });

    //handle remove button click
    $('#AllPeopleList button.delete-person')
        .click(function(e) {
            e.preventDefault();

            var $listItem = $(this).closest('.list-group-item'); //closest - travels up the DOM tree and returns the first ancestor that matches the passed expression.
            var personId = $listItem.attr('data-person-id');

/*        abp.localization
            .localize("AreYouSureToDeleteThePerson", "PhonebookCore2");*/

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
        });

    $("#RefreshButton")
        .click(function() {
            refreshUserList();
        });

    function refreshUserList() {
        location.reload(true); //reload page to see new user!
    }

    function save() {
        if (!$form.valid()) {
            return;
        }

        var person = $form.serializeFormToObject();
        abp.ui.setBusy($modal);

        personService.createPerson(person)
            .done(function() {
                // $modal.modal.hide("hide");
                $modal.modal('hide');
                location.reload(true); //reload page to see new person!
            })
            .always(function() {
                abp.ui.clearBusy($modal);
            });
    }


    //Edit person button
    $('#AllPeopleList button.edit-person')
        .click(function(e) {
            //e.preventDefault();

            var $listItem = $(this).closest('.list-group-item');
            $listItem.toggleClass('person-editing').siblings().removeClass('person-editing');
            // $listItem.find('div').removeClass('table-phones-hidden').addClass('table-phones-shown');


        });

    //Save phone button
    $('#AllPeopleList .button-save-phone')
        .click(function(e) {
            e.preventDefault();

            var $phoneEditorRow = $(this).closest('tr');
            $.ajax({
                    url: abp.appPath + 'PhoneBook/AddPhone',
                    dataType: 'html',
                    data: JSON.stringify({
                        personId: $phoneEditorRow.closest('.list-group-item').attr('data-person-id'),
                        Type: $phoneEditorRow.find('select[name=Type]').val(),
                        Number: $phoneEditorRow.find('input[name=Number]').val()
                    })
                })
                .done(function(result) {
                    $(result).insertBefore($phoneEditorRow);
                });
        });

/*    $('.edit-role')
        .click(function(e) {
            var roleId = $(this).attr("data-role-id");

            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'Roles/EditRoleModal?roleId=' + roleId,
                type: 'POST',
                contentType: 'application/html',
                success: function(content) {
                    $('#RoleEditModal div.modal-content').html(content);
                },
                error: function(e) {}
            });
        });*/


    /*    function deleteUser(userId, userName) {
        abp.message.confirm(
            "Delete user '" + userName + "'?",
            function (isConfirmed) {
                if (isConfirmed) {
                    _userService.delete({
                        id: userId
                    }).done(function () {
                        refreshUserList();
                    });
                }
            }
        );
    }*/
})(jQuery);