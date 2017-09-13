(function() {
    $(function() {

        var personService = abp.services.app.person;
        var $modal = $("#PersonCreateModal");
        var $form = $modal.find("form");

        //Handle save button click
        $form.closest("div.modal-content")
            .find(".save-button")
            .click(function(e) {
                e.preventDefault();
                save();
            });


        $modal.on("shown.bs.modal",
            function() {
                $modal.find("input:not([type=hidden]):first").focus();
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
                    $modal.modal("hide");
                    location.reload(true); //reload page to see new person!
                })
                .always(function() {
                    abp.ui.clearBusy($modal);
                });
        }


    });
})();