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
    <script>
            var car1 = {
                carName: "c200-2014",
                explanation: "good car"
            };
    </script>
    <script>
        let formdata = new FormData();
        formdata.append('نام +=', 'کیا +=');
        formdata.append('&json', JSON.stringify(car1));
        let xhr = new XMLHttpRequest();
        let url1 = "http://localhost/dashboard/1/project5/s4.php";
        let url2 = "http://localhost:12345";
        xhr.open('post', url1);
        xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
        xhr.send(new URLSearchParams(formdata));
    </script>
</body>
</html>