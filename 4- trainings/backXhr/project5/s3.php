<?php
print_r($_POST);
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
    <form method="post">
        <input type="text" name="نام +=" id="uiName">
        <input type="text" name="&json" id="uiJson">
    </form>
    <script src="./../jquery-3.6.3.js"></script>
    <script>
        var car1 = {
            carName: "c200-2014",
            explanation: "good car"
        };
    </script>
    <script>
        class UploadHandler
        {
            static fillInputs () {
                $('#uiName').val("کیا +=");
                $('#uiJson').val(JSON.stringify(car1));
            }
            static sendForm () {
                let formdata = new FormData($('form')[0]);
                let xhr = new XMLHttpRequest();
                let url1 = "http://localhost:12345";
                let url2 = "http://localhost/dashboard/1/project5/s3.php";
                xhr.open('post', url2);
                xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
                xhr.send(new URLSearchParams(formdata));
            }
        }
        (function addEventListeners () {
            UploadHandler.fillInputs();
            UploadHandler.sendForm();
        })()
    </script>
</body>
</html>