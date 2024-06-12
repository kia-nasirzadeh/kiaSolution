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
    <form action="http://localhost/dashboard/1/project5/s6.php" enctype="multipart/form-data" method="post">
        <input type="text" name="&json">
        <input type="text" name="نام +=">
        <input id="ali" type="file" name="imgs[]" multiple>
        <input type="submit" value="sub this">
    </form>
    <script src="./../jquery-3.6.3.js"></script>
    <script>
        var car1 = {
            carName: "c200-2014",
            explanation: "good car"
        };
    </script>
    <script>
        function addEventListeners () {
            $('input[type="file"]').change(function () { UploadHandler.updateFilesArray(this); });
        }
        class UploadHandler {
            static filesArray = [];
            static fillForm () {
                $('form > input:nth-child(1)').val(JSON.stringify(car1));
                $('form > input:nth-child(2)').val("کیا +=");
            }
            static updateFilesArray (fileInput) {
                let files = fileInput.files;
                for (let file of files) {
                    UploadHandler.filesArray.push(file);
                    $('body').append(`<p>${file.name}</p>`);
                }
            }
        }
        (() => { 
            UploadHandler.fillForm();
            addEventListeners();
        })()
    </script>
</body>
</html>