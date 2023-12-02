<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <input type="button" value="download image">
    <img src="./../uploads/ww.jpg" alt="" style="border: 1px solid red;padding:2px; max-width: 30%">
    <script src="./../jquery-3.6.3.js"></script>
    <script>
        class DownloadHandler 
        {
            static confirm () {
                let xhr = new XMLHttpRequest();
                xhr.open('head', "https://raw.githubusercontent.com/kia-nasirzadeh/sjcm---a-CMS-for-github-pages/main/assets/about.png", false);
                xhr.send();
                let conLength = xhr.getResponseHeader('content-length');
                return confirm(`size of downloading asset is ${conLength} bytes`);
            }
            static downloadPic () {
                let xhr = new XMLHttpRequest();
                xhr.open("get", "https://raw.githubusercontent.com/kia-nasirzadeh/sjcm---a-CMS-for-github-pages/main/assets/about.png");
                xhr.responseType = 'blob';
                xhr.send();
                xhr.onloadend = () => {
                    if (xhr.status != 200) return console.log('xhr response status is not 200');
                    let img = xhr.response;
                    let imgHref = URL.createObjectURL(img);
                    $('img').attr('src', imgHref);
                    if (confirm('download?')) DownloadHandler.downloadOnDisk(imgHref);
                }
                xhr.onprogress = (ev) => {
                    if (!ev.lengthComputable) return console.log('length is not computable');
                    console.log(ev.loaded + '/' + ev.total);
                }
            }
            static downloadOnDisk (imgHref) {
                let anchor = $(`<a href="${imgHref}" style="display:none" download>df</a>`);
                $('body').append(anchor);
                console.log(anchor);
                $(anchor)[0].click();
            }
        }
        (function addEventListeners () {
            $('input[type="button"]').click(() => {
                let confirm = DownloadHandler.confirm();
                if (confirm) DownloadHandler.downloadPic();
                else console.log('user does not confirm download');
            })
        })()
        $('input[type="button"]').trigger('click');
    </script>
</body>
</html>