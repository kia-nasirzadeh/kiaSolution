$('#summ').summernote({
    height: 200,
    lang: 'fa-IR',
    toolbar: [
        ['para', ['ul', 'li', 'paragraph']],
        ['color', ['color']],
        ['fontsize', ['fontsize']],
        ['style', ['bold','italic','underline']]
    ]
});
$('#summ').summernote('justifyRight');
$('#set').on('click', () => { 
    $('#summ').summernote('code', 'loremipsum');    
})
$('#get').on('click', () => {
    alert($('#summ').summernote('code'));
})