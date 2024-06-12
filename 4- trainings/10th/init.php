<?php
namespace Bot\Init;
require_once __DIR__ . "/vendor/autoload.php";

use Exception;
use \KiaNasirzadeh\x10th\Errorhandlers\{Logger, ErrorHandler};

enum Environment {
    case Development;
    case Testing;
    case Staging;
    case Production;
}
class Bot {
    public $api;
    public $botId;
    public $proxyIp;
    public $environment;
    public $logger;
    function __construct ($token, $webhook, Environment $environment, $proxyIp=false)
    {
        $this->logger = new Logger();
        $this->api = "https://api.telegram.org/bot$token";
        $this->botId = substr($token, 0, strpos($token, ':'));
        if($proxyIp) $this->proxyIp = $proxyIp;
        $this->environment = $environment;
        if (!$this->getWebhook()) $this->setWebhook ($webhook);
    }
    function curl ($url, $data) {
        // if (!$curlid = curl_init()) new ErrorHandler(new Exception('curlid is false', 0), $this->logger);

    }
    function setWebhook ($webhook) {

    }
    function getWebhook () {
        new Logger("xxx");
    }
    function test ($x) {
        $this->curl($x, 'b');
    }
}
$bot = new Bot('a', 'b', Environment::Testing, "127.0.0.1:10809");
// $bot->test("ali");