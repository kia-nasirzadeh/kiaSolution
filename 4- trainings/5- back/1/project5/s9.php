<?php
echo '<pre>';print_r($_FILES);echo '</pre>';
if (isset($_POST['&json'])) echo json_decode($_POST['&json'], true)['carName'];
if (isset($_POST['نام_+='])) echo $_POST['نام_+='];
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <script>
        var car1 = {
            carName: "c200-2014",
            explanation: "good car"
        };
    </script>
    <script src="./../jquery-3.6.3.js"></script>
    <script>
        let selectedImg;
        (function getUserImages () {
            let imageInput = $(`<input type="file"/>`)
            .appendTo('body');
            $(imageInput).change(function () {
                selectedImg = this.files[0];
                console.log(selectedImg.name);
                startUploadProgress();
            });
        })()
        function startUploadProgress () {
            let formdata = new FormData();
            formdata.append('نام +=', 'کیا +=');
            formdata.append('&json', JSON.stringify(car1));
            formdata.append('img', selectedImg);
            $.ajax({
                method: 'post',
                url: new URL('http://localhost/dashboard/1/project5/s9.php'),
                processData: false, //important
                contentType: false, //important
                data: formdata,
                success: res => console.log(res),
                error: (xhr, status, error) => console.log('we have error')
            })
        }
    </script>
</body>
</html>