<?php
$BOT_TOKEN = "6706730878:AAGjlqzP3N_6kl2oHYJTdqPQeaGioQnCO6Q";

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
send('sendMessage', [
    "chat_id" => "84880827",
    "text" => "fuck you"
]);