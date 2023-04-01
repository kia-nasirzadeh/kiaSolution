jQuery(document).ready(function ($) {
    $("#upload").click(function () { $("#uploadInput").trigger("click"); })
    $("#uploadInput").change(function (ev) {
        let file = ev.target.files[0];
        let imgSrc = URL.createObjectURL(file);
        $("#imgsRow").append(`
            <div class="col-4 col-lg-2 p-1">
                <div class="p-2 border rounded">
                    <img src="${imgSrc}" class="w-100" alt="" srcset="">
                    <div class="btn btn-danger w-100 my-2">delete</div>
                </div>
            </div>
        `);
    });
    $("#summernote").summernote({
        height: 200,
        lang: 'fa-IR',
        toolbar: [
            ['para', ['ul', 'ol', 'paragraph']],
            ['color', ['color']],
            ['fontsize', ['fontsize']],
            ['style', ['bold', 'italic', 'underline']]
        ]
    });
    $("#summernote").summernote('justifyRight');
    $("#sendText").click(function () {
        let text = $("#summernote").summernote('code');
        console.log(text);
    });
});