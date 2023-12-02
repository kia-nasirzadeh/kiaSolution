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
        // make xhr, it has no args:
        let xhr = new XMLHttpRequest();
        // initialize it:
        let url = new URL('https://raw.githubusercontent.com/kia-nasirzadeh/jsonTest/main/json.json');
        xhr.open('get', url);
        xhr.responseType = 'json';
        xhr.send();
        xhr.onloadend = function () {
            if (xhr.status == 200) {
                let data = xhr.response;
                console.log(data);
                console.log(data.profile);
                console.log(data.profile.name);
            } else alert('not 200 status');
        };
    </script>
</body>
</html>