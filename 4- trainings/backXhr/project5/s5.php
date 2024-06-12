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
    <form>
        <input type="text" name="&json">
        <input type="text" name="نام +=">
    </form>
    <script>
        var car1 = {
            carName: "c200-2014",
            explanation: "good car"
        };
    </script>
    <script src="./../jquery-3.6.3.js"></script>
    <script>
        $('form > input:first-child').val(JSON.stringify(car1));
        $('form > input:last-child').val("کیا +=");
        let url1 = new URL("http://localhost/dashboard/1/project5/s5.php");
        $.ajax({
            method: 'post', // both "method" and "type" are acceptable
            url: url1,
            data: $('form').serialize(),
            success: res => console.log(res),
            error: (xhr, status, error) => console.log('we have error')
        })
    </script>
</body>
</html>