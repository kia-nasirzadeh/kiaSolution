let filec = $('.filec').clone();
$('.filec').remove();
$('#droppable').on('dragover', (ev) => {
    ev.preventDefault();
})
$('#droppable').on('drop', (ev) => {
    ev.preventDefault();
    let files = ev.originalEvent.dataTransfer.files;
    for (file of files) {
        let filec_x = filec.clone().html(file.name);
        $('#mainc').append(filec_x);
    }
})
$('#fileinp').on('change', (ev) => {
    let file = ev.target.files[0];
    let filec_x = filec.clone().html(file.name);
    $('#mainc').append(filec_x);
})