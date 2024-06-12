$('#fileinp').on('change', (ev) => {
    let imgBlob = ev.target.files[0];
    let imgSrc = URL.createObjectURL(imgBlob);
    let imgName = imgBlob.name;
    $('#img').attr('src', imgSrc);
    $('#fileTitle').html(imgName);
})