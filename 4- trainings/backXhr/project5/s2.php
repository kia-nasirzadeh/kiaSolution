<?php
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
    <script>
        let xhr = new XMLHttpRequest();
        let url1 = "http://localhost:12345"; // we don't need it any way since we are making what we want!
        let url2 = "http://localhost/dashboard/1/project5/s2.php";
        xhr.open('post', url2);
        xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
        // building payload
        // it should be sth like a=b&c=d
        // lets write json as a minified string to send:
        // {"carName":"c200-2014","explanation":"good car"}
        // use online encoder to encode کیا , ...
        // %D9%86%D8%A7%D9%85%20%2B%3D=%DA%A9%DB%8C%D8%A7%20%2B%3D&%26json=%7B%22carName%22%3A%22c200-2014%22%2C%22explanation%22%3A%22good%20car%22%7D
        // now, for backward-compatibility we need to have spaces as + not %20 so
        // %D9%86%D8%A7%D9%85+%2B%3D=%DA%A9%DB%8C%D8%A7+%2B%3D&%26json=%7B%22carName%22%3A%22c200-2014%22%2C%22explanation%22%3A%22good+car%22%7D
        let payload = "%D9%86%D8%A7%D9%85+%2B%3D=%DA%A9%DB%8C%D8%A7+%2B%3D&%26json=%7B%22carName%22%3A%22c200-2014%22%2C%22explanation%22%3A%22good+car%22%7D";
        xhr.send(payload);
    </script>
</body>
</html>