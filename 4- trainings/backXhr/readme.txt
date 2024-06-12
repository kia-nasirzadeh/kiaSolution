do below projects in all 5 ways below 
    1- do step 5 just in first project, in the rest of them you should just see the files and json in php side
    2- for first project do that for just one picture, for the second do that do that for multiple input, for the rest do as you like
project-1: [submit form using jquery] => make a hidden form and submit that form with jquery
project-2: [submit with xhr + loader] => asynchronous xhr
project-2: [ajax data using jquery] => send it with jquery ajax
project- : using swap, fetch
____________________________________________________________________________________________________________________________________
1- with sqlTest.sql file build "carsTest" table in "kpriceTest" db
2- build a webpage with two buttons: 1- "select a pic" 2- "submit"
3- by clicking on "submit" you should:
3-1- show carName from php
3-2- send the picture to your host
3-3- send below json with the link of those pics in car1.pics and arbitrary group and subgroup

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

5- finally you should insert a row to your database, it should has one column for json and one column for the path of pictures