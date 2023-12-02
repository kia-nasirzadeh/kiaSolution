<?php
echo "<pre>";print_r($_POST);print_r($_FILES);echo "</pre>";
set_error_handler("warningHandler", E_WARNING);
function warningHandler ($errno, $errstr) {
    echo "$errno => $errstr" . "<br>";
}
class ErrHandler {
    public static $picOk = true;
    public static $errors = [];
    public static function addErr ($err) {
        array_push(ErrHandler::$errors, $err);
        ErrHandler::$picOk = false;
    }
}
class UploadHandler {
    private $pic;
    private $targetFile;
    private $format;
    private $picName;
    function __construct($pic, $targetDir)
    {
        $this->pic = $pic;
        $this->picName = basename($pic['name']);
        $this->targetFile = $targetDir . $this->picName;
        $this->format = strtolower(pathinfo($this->picName, PATHINFO_EXTENSION));
    }
    function checkImg () {
        $pic = $this->pic;
        if ($pic['size'] > 1000000) ErrHandler::addErr('file bigger than 1Mb');
        if ($pic['size'] <= 0) ErrHandler::addErr('file size <= 0');
        if (!getimagesize($pic['tmp_name'])) ErrHandler::addErr('image is fake');
        if (file_exists($this->targetFile)) ErrHandler::addErr('file already exists');
        if ($pic['error'] != 0) ErrHandler::addErr('$_FILES[pic][error] not ok');
        if (!in_array($this->format, ['jpg', 'jpeg', 'png'])) ErrHandler::addErr('file format not ok');
    }
    function upload () {
        $pic = $this->pic;
        $this->checkimg();
        if (!ErrHandler::$picOk) {
            foreach (ErrHandler::$errors as $err) {
                echo $err . "<br>";
            }
            return false;
        }
        if (move_uploaded_file($pic['tmp_name'], $this->targetFile)) return true;
        else {
            echo 'can not move uploaded file';
            return false;
        }
    }
    function removeUploadedFile () {
        if (unlink($this->targetFile)) return true;
        else return false;
    }
}
class DbHandlerr {
    private $server = "localhost";
    private $username = "root";
    private $password = "";
    private $dbname = "kpriceTest";
    function updateDb ($json, $picPath) {
        try {
            $dbh = new PDO("mysql:host=$this->server;dbname=$this->dbname", $this->username, $this->password);
            $stmt = $dbh->prepare("INSERT INTO carsTest (`json`, `picPath`) VALUES (:json, :picPath)");
            $stmt->bindParam(':json', $json);
            $stmt->bindParam(':picPath', $picPath);
            $stmt->execute();
            return true;
        } catch (Exception $e) {
            echo $e->getMessage();
            return false;
        }
    }
}
$neededParamsInPlace = isset($_FILES['pic']) && isset($_POST['json']);
if ($neededParamsInPlace) {
    $targetDir = './../uploads/';
    $uploadhndler = new UploadHandler($_FILES['pic'], $targetDir);
    if ($uploadhndler->upload()) {
        $dbhndler = new DbHandlerr();
        $json = $_POST['json'];
        $picPath = $_SERVER['REQUEST_SCHEME'].'://'.$_SERVER['SERVER_NAME'].'/dashboard/1/uploads/'.basename($_FILES['pic']['name']);
        if ($dbhndler->updateDb($json, $picPath)) {
            echo 'upload pic and update db is done';
        } else {
            $uploadhndler->removeUploadedFile();
            echo 'update db has problem, we also removed uploaded file';
        }
    } else {
        echo 'we have a problem in uploading image';
    }
}
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
    <input type="file" id="uiPic" style="display: none;">
    <label for="uiPic" style="border: 1px solid black; padding: 2px;border-radius: 3px">choose a pic</label>
    <input type="submit" value="sub this" style="padding:2.5px">
</body>
<script src="./../jquery-3.6.3.js"></script>
<script>
            var car1 = {
            carName: "c200-2014-2016",
            pics: [
                "file:///C:/Users/kia-nasirzadeh/Desktop/kia/4-%20kprice/assets/pics/2.jpg",
                "file:///C:/Users/kia-nasirzadeh/Desktop/kia/4-%20kprice/assets/pics/3.jpg"
            ],
            explanation: "این یک توضیح اختیاری برای ماشین است",
            kasebiItems: [
                "خرید در 10 دلار در 20 سنت",
                "خرید بی رنگش در 100 دلار یعنی 1.5میلیارد تومن"
            ],
            table: {
                columns: ["gheymat", "badane", "rang", "karkard"],
                deletedCols: ["rang"],
                rows: [
                    {"gheymat": "1.45", "badane": "biRang", "rang": "sefid", "karkard": "22000"},
                    {"gheymat": "1.7", "badane": "biRang", "rang": "meshki", "karkard": "32000"},
                    {"gheymat": "1.2", "badane": "gelgir-aghab-stock", "rang": "abi", "karkard": "12000"}
                ]
            }
        };
</script>
<script>
    class UiUploadHandler {
        static file;
        static uiPicChange () {
            UiUploadHandler.file = this.files[0];
        }
        static makeform () {
            let form = $(`<form enctype="multipart/form-data" method="post" style="display:none"></form>`)
            .append(`<input type="text" name="json"/>`)
            .append(`<input type="file" name="pic"/>`)
            .appendTo('body');
            let dt = new DataTransfer();
            dt.items.add(UiUploadHandler.file);
            $('input[name="pic"]')[0].files = dt.files;
            $('input[name="json"]').val(JSON.stringify(car1));
            return form;
        }
        static submitForm () {
            if (UiUploadHandler.file == undefined) return console.log('first choose pic');
            let form = UiUploadHandler.makeform();
            $(form).submit();
        }
    }
    (function addEventListeners () {
        $('#uiPic').change(UiUploadHandler.uiPicChange);
        $('input[type="submit"]').click(UiUploadHandler.submitForm)
    })();
</script>
</html>