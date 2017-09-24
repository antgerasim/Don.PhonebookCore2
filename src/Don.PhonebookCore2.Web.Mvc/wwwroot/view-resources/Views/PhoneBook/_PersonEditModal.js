(function ($) {
/*    debugger;*/

    var personService = abp.services.app.person;
    var $modal = $('#PersonEditModal');
    var $form = $modal.find('form');

    $form.validate({
    });

    //Handle save button click
    $form.closest("div.modal-content")
        .find(".save-button")
        .click(function (e) {
            debugger;
            e.preventDefault();
            save();
        });

    

    function save() {

        if (!$form.valid()) {
            return;
        }

        var person = $form.serializeFormToObject(); //serializeFormToObject is defined in main.js
  
        abp.ui.setBusy($form);
        personService.update(person).done(function () {
            debugger;
            $modal.modal('hide');
            location.reload(true); //reload page to see edited role!
        }).always(function () {
            abp.ui.clearBusy($modal);
        });
    }

    $.AdminBSB.input.activate($form);

    $modal.on('shown.bs.modal', function () {
        $form.find('input[type=text]:first').focus();
    });

})(jQuery);