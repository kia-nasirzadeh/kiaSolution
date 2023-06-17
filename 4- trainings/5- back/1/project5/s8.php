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
    <script src="./../jquery-3.6.3.js"></script>
    <script>
        var car1 = {
            carName: "c200-2014",
            explanation: "good car"
        };
    </script>
    <script>
        let userChoosenFiles;
        (function handleGetImgs () {
            let imgInput = $(`<input type="file" multiple>`)
            .appendTo('body');
            $(imgInput).change(function () {
                let files = this.files;
                for (let file of files) {
                    console.log(file.name);
                }
                userChoosenFiles = files;
                sendFormData();
            })
        })()

        function sendFormData () {
            let formdata = new FormData();
            formdata.append('نام +=', 'کیا +=');
            formdata.append('&json', JSON.stringify(car1));
            for (let file of userChoosenFiles) {
                formdata.append('imgs[]', file);
            }
            let xhr = new XMLHttpRequest();
            let url1 = new URL('http://localhost/dashboard/1/project5/s8.php');
            xhr.open('post', url1);
            xhr.send(formdata);
        }
    </script>
</body>
</html>