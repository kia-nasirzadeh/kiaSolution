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
        let url1 = new URL('http://localhost/dashboard/1/project2/index-async.php');
        let url2 = new URL('http://localhost:12345/?name=hos');
        [url1, url2].forEach(url => url.searchParams.set('name', 'uchi'));
        xhr.open('get', url1);
        // xhr.open('get', url2);
        // send it:
        xhr.send();
        // handle response:
        // xhr.timeout = 500; 500 is in milliseconds
        xhr.onload = function () {
            if (xhr.status == 200) {
                alert(`status is: ${xhr.status}\nresponse is: ${xhr.response}`);
            } else {
                alert(`we have a problem, status code = ${xhr.status}, error=${xhr.statusText}`);
            }
        };
        xhr.onprogress = function (ev) {
            if (ev.lengthComputable)
                alert(`progressed: ${ev.loaded} bytes, total: ${ev.total} bytes`);
            else
                alert('chunked data received, so we can not get progressed amount');
        }
        xhr.onerror = function () {
            alert('we have error in sending, no data have been sent at all');
        }
        xhr.onloadend = function () {
            alert('load ended');
        }
        xhr.onreadystatechange = function () {
            alert(`xhr ready state changed, readyState=${xhr.readyState}`);
            if (xhr.readyState == 3) { // NOTE: it can be on any ready state but not readystate == 1;
                let a = xhr.getAllResponseHeaders();
                let b = a.split('\r\n');
                console.log(b);
            }
        }
        // xhr.ontimeout = function () {
        //     alert('timed out');
        // }
        alert('2');
    </script>
</body>
</html>