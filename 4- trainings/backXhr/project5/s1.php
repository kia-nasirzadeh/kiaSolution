<?php
// $urlToSend = "";
$urlToSend = "http://localhost:12345";
if (isset($_POST['&json'])) echo json_decode($_POST['&json'], true)['carName'];
if (isset($_POST['نام_+='])) echo $_POST['نام_+=']
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
    <form method="post" action="<?= $urlToSend ?>">
        <input type="text" name="نام +=" id="uiName">
        <input type="text" name="&json" id="uiJson">
        <input type="submit" value="sub" id="sub">
    </form>
</body>
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
    }
    (function addEventListeners () {
        UploadHandler.fillInputs();
    })()
    // excepted: %D9%86%D8%A7%D9%85+%2B%3D=%DA%A9%DB%8C%D8%A7+%2B%3D&%26json=%7B%22carName%22%3A%22c200-2014%22%2C%22explanation%22%3A%22good+car%22%7D
    // received: %D9%86%D8%A7%D9%85+%2B%3D=%DA%A9%DB%8C%D8%A7+%2B%3D&%26json=%7B%22carName%22%3A%22c200-2014%22%2C%22explanation%22%3A%22good+car%22%7D
</script>
</html>
