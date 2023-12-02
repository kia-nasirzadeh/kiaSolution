<?php
$BOT_TOKEN = "6002859887:AAGUTnmypJY5s4dHPSeYcbCOOhlPf6KWZ_I";
$whatTelegramSendsToMe = file_get_contents('php://input');
$tgReq = json_decode($whatTelegramSendsToMe, 1);
$userId = $tgReq['message']['from']['id'];
$userMessage = $tgReq['message']['text'];
if ($userMessage == "/start") {
    $answerToUser = "hi, whats your name?";
} else {
    if (strtolower($userMessage) == "ava") $userMessage = "oh you ava! i love ava and we need";
    else $userMessage = "به که $userMessage هستی";
    $answerToUser = "$userMessage\ntell me what is your name again?";
}
$datax = [
    "chat_id" => $userId,
    "text" => $answerToUser
];

function send ($method, $data) {
    global $BOT_TOKEN;
    $url = "https://api.telegram.org/bot$BOT_TOKEN/$method";
    $proxy = '127.0.0.1:10809';
    if (!$curid = curl_init()) {
        echo "no no";
        exit;
    }
    curl_setopt($curid, CURLOPT_POST, true);
    curl_setopt($curid, CURLOPT_POSTFIELDS, $data);
    curl_setopt($curid, CURLOPT_URL, $url);
    curl_setopt($curid, CURLOPT_PROXY, $proxy);
    curl_setopt($curid, CURLOPT_RETURNTRANSFER, true);
    $output = curl_exec($curid);
    curl_close($curid);
    if ($output == false) {
        echo 'we have error in sending curl';
        var_dump(curl_errno($curid));
        var_dump(curl_error($curid));
    }
    return $output;
}

function send2 () {
    $url = "ifconfig.co/ip";
    $proxy = '127.0.0.1:10809';
    if (!$curid = curl_init()) {
        echo "no no";
        exit;
    }
    curl_setopt($curid, CURLOPT_POST, false);
    curl_setopt($curid, CURLOPT_URL, $url);
    curl_setopt($curid, CURLOPT_PROXY, $proxy);
    curl_setopt($curid, CURLOPT_RETURNTRANSFER, true);
    $output = curl_exec($curid);
    curl_close($curid);
    if ($output == false) {
        echo 'we have error in sending curl';
        var_dump(curl_errno($curid));
        var_dump(curl_error($curid));
    }
    return $output;
}

var_dump(send("sendMessage", $datax));
// var_dump(send("sendMessage", $datax));
// echo "a=>i";