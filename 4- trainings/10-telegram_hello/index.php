<?php
enum Environment {
    case Development;
    case Testing;
    case Staging;
    case Production;
}
class Bot {
    public $api;
    public $apiID;
    public $proxy = "127.0.0.1:10809";
    public $environment = 'dev';
    public function __construct ($token, $webhook, Environment $environment)
    {
        $this->environment = $environment;
        $this->apiID = substr($token, 0, strpos($token, ':'));
        $this->api = "https://api.telegram.org/bot$token";
        if ($this->test()) echo 'bot is okay<br>';
        $webhookokay = $this->webhookSet();
        if (!$webhookokay) $webhookokay = $this->setWebhook($webhook);
        if (!$webhookokay) throw new Exception("webhook is not okay");
        if ($webhookokay) echo 'webhook is okay<br>';
    }
    function curl ($url, $data = false, $post = false, $proxy = false) {
        if ($this->environment != Environment::Development) $proxy = false;
        if (!$curlid = curl_init()) throw new Exception('curl can not initiated');
        if ($post) curl_setopt($curlid, CURLOPT_POST, true);
        if ($post && $data) curl_setopt($curlid, CURLOPT_POSTFIELDS, $data);
        curl_setopt($curlid, CURLOPT_URL, $url);
        if ($proxy) curl_setopt($curlid, CURLOPT_PROXY, $this->proxy);
        curl_setopt($curlid, CURLOPT_RETURNTRANSFER, true);
        $output = curl_exec($curlid);
        curl_close($curlid);
        if (!$output) throw new Exception('curl output is false');
        return $output;
    }
    function test () {
        $output = $this->curl($this->api . '/getMe', false, false, true);
        $output = json_decode($output, 1);
        if ($output['ok'] == true) return true;
        else return false;
    }
    function webhookSet () {
        $output = $this->curl($this->api . '/getWebhookinfo', false, false, true);
        $output = json_decode($output, 1);
        if (!$output['ok']) throw new Exception('getWebhook okay is false');
        if ($output['result']['url'] == "") return false;
        else return $output['result']['url'];
    }
    function setWebhook ($webhook) {
        $output = $this->curl($this->api . "/setWebhook?url=$webhook", false, false, true);
        $output = json_decode($output, 1);
        if (!$output['ok']) throw new Exception('setwebhook is not okay');
        if ($output['result']) return true;
        else return false;
    }
}
class kiaHellobot extends Bot {
    public function __construct($token, $webhook, Environment $environment) {
        parent::__construct($token, $webhook, $environment);
    }
    public function sendMessage ($message, $chatid) {
        $output = $this->curl(
            $this->api . "/sendMessage?chat_id=$chatid&text=$message", 
            [
                "chat_id" => $chatid,
                "text" => $message
            ],
            true,
            true
        );
        $output = json_decode($output, 1);
        if ($output['ok']) return $output['result'];
        else return false;
    }
}

$mybot = new kiaHellobot(
    '6781783866:AAEh_Fe5ZdtEyDpiEsL4DKPUbTipwZMzdjM',
    "https://71c1-46-164-115-226.ngrok-free.app" ,
    Environment::Development
    // Environment::Production
);
echo '<pre>';
var_dump($mybot->sendMessage('hello', "5739963315"));