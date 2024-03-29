<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="./../../../libs/bootstrap4.1/css/bootstrap.min.css">
    <link href="./../../../libs/bootstrap-3.3.5/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="./../../../libs/bootstrap-5.0.2-dist/css/bootstrap-grid.min.css" rel="stylesheet"/>
    <link href="./addcar.css" rel="stylesheet">
    <title>kprice-add car</title>
</head>
<body>
    <div class="container-fluid">
        <div class="row">
            <div class="col-12 px-3 py-3 bg-light">
                <a href="./../admin/admin.php" class="btn btn-primary w-100">go to admin panel</a>
            </div>
        </div>
        <div class="row">
            <div class="col-12 px-4">
                <div class="row bg-dark py-2">
                    <div class="col-12 col-lg-4 py-1 px-4 d-flex justify-content-center align-items-center">
                        <input class="w-100 p-1" type="text" name="" id="groupInput" placeholder="group">
                    </div>
                    <div class="col-12 col-lg-4 py-1 px-4 d-flex justify-content-center align-items-center">
                        <input class="w-100 p-1" type="text" name="" id="subGroupInput" placeholder="sub group">
                    </div>
                    <div class="col-12 col-lg-4 py-1 px-4 d-flex justify-content-center align-items-center">
                        <div class="btn btn-primary w-100" id="addNew" tabindex="-1">add new group</div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-12 my-1">
                <input type="text" class="w-100 form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm" id="searchInput">
            </div>
        </div>
        <div class="row">
            <div class="col-12 my-1">
                <div class="list-group list-group-root well">
                    <a href="#c200" class="list-group-item" data-toggle="collapse">
                        <i class="glyphicon glyphicon-chevron-right"></i>c200
                    </a>
                    <div data-group="c200" class="list-group collapse" id="c200">
                        <a href="#" class="list-group-item">c200-2011-2014</a>
                        <a href="#" class="list-group-item">c200-2011-2014</a>
                    </div>
                    <a href="#clk" class="list-group-item" data-toggle="collapse">
                        <i class="glyphicon glyphicon-chevron-right"></i>clk
                    </a>
                    <div data-group="clk" class="list-group collapse" id="clk">
                        <a href="#" class="list-group-item">clk-2008-2009</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="./../../../libs/jquery.js"></script>
    <script src="./../../../libs/bootstrap-3.3.5/dist/js/bootstrap.min.js"></script>
    <script src="./addcar.js"></script>
</body>
</html>