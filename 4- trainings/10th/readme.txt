1- make and configure a new bot in telegram => name: kiahello username: kiahellobot
2- make a robot that can send hello to yourself with all developement envs
3- upload your bot on x.article-world.ir/test1.php and send hello to yourself
3- delete kiahellobot

==========> your index.php output should be like this:

bot is okay
webhook is okay
array(5) {
  ["message_id"]=>
  int(3)
  ["from"]=>
  array(4) {
    ["id"]=>
    int(6781783866)
    ["is_bot"]=>
    bool(true)
    ["first_name"]=>
    string(8) "kiahello"
    ["username"]=>
    string(11) "kiahellobot"
  }
  ["chat"]=>
  array(4) {
    ["id"]=>
    int(5739963315)
    ["first_name"]=>
    string(7) "carocar"
    ["username"]=>
    string(12) "carocarocarr"
    ["type"]=>
    string(7) "private"
  }
  ["date"]=>
  int(1698134030)
  ["text"]=>
  string(5) "hello"
}

==========> your telegram should be like this:
carocar, [02/08/1402 10:33 ق.ظ]
/start

kiahello, [02/08/1402 11:18 ق.ظ]
hello


🆗 composer init
* composer require imonroe/ana
* minimum stability can be: dev
* composer require x --dev => add package to dev-dependency
* you want to run a code in your project bin folder
"script": {
    "xcode": "your code goes here..."
}
composer xcode
composer require components/jquery