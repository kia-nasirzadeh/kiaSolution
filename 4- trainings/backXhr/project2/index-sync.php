<?php
if (isset($_GET['name'])) echo $_GET['name'];
echo "\n";

// require_once './bigdata.php';
// echo $data;
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
        alert('1');
        // make xhr, it has no args:
        let xhr = new XMLHttpRequest();
        // initialize it:
        let url = new URL('http://localhost/dashboard/1/project2/index-sync.php/');
        url.searchParams.set('name', 'hos');
        xhr.open('get', url, false);
        try {
            xhr.send();
            if (xhr.status == 200) {
                alert(`status is: ${xhr.status}\nresponse is: ${xhr.response}`);
            } else {
                alert(`we have a problem, status code = ${xhr.status}, error=${xhr.statusText}`);
            }
        } catch (err) {
            alert(err);
            console.log(err);
        }
        alert('2');
    </script>
</body>
</html>