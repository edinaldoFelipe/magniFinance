/**
 * Alert Success Model
 * @param {string} message
 */
function alertSuccess(message = 'Data was saved') {
    document.body.insertAdjacentHTML('beforeend', `
        <div class="position-fixed bottom-0 right-0 p-3 pr-5 alert alert-success alert-dismissible fade show"
        style="z-index: 5; right: 10px; bottom: 5px;"
         role="alert"><b>Success.</b> ${message}!
          <button type="button" class="close" data-dismiss="alert" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>`)
}

/**
 * Alert Error Model
 * @param {string} message
 */
function alertError(message = 'Data was not saved') {
    document.body.insertAdjacentHTML('beforeend', `
        <div class="position-fixed bottom-0 right-0 p-3 pr-5 alert alert-danger alert-dismissible fade show"
        style="z-index: 5; right: 10px; bottom: 5px;"
         role="alert"><b>Error.</b> ${message}!
          <button type="button" class="close" data-dismiss="alert" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>`)
}

/**
 *  Triggered when modal is shown
 *  Modal Model
 */
$('#myModal').on('show.bs.modal', function (event) {
    const id = $(event.relatedTarget).data('id'),
        $modal = $(event.currentTarget);

    $modal.find('#myModalLabel').html("<i class='feather icon-alert-triangle'></i> Are you Sure?");
    $modal.find('#myModalBody').html("Do you really want to delete this course?");
    $modal.find('#confirmModel')[0].dataset.id = id;
})