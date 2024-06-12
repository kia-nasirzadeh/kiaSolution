<?php
namespace KiaNasirzadeh\x10th\Errorhandlers;
require_once __DIR__ . "/../../vendor/autoload.php";

use Monolog\Level;
use Monolog\Logger as MonoLogger;
use Monolog\Handler\StreamHandler;
use Monolog\Formatter\LineFormatter;

Class Logger {
    public $logger;
    public $string;
    function __construct ($justALog = false, $channelName = "noChannel") {
        // make line format to use:
        $now_persian = $this->getPersianDateTime();
        $dateFormat = "Y_m_d_H:i:s $now_persian";
        $output = "━━━━━━━━━━━━━━━━━━━━━━━━ %datetime% ━━━━━━━━━━━━━━━━━━━━━━━━ %channel%.%level_name% \r\n%message%\r\n";
        ///////TODO: WE NEED TO INSTALL TMUX TO ANALYZE LOG FILE IN ONE SESSION
        $formatter = new LineFormatter($output, $dateFormat, true);
        // make write stream handler and put your line format in it:
        $handle = new StreamHandler(__DIR__.'/../../app.log', Level::Warning);
        $handle->setFormatter($formatter);
        // make logger:
        // put your stream in your logger:
        $this->logger = new MonoLogger($channelName);
        $this->logger->pushHandler($handle);
        if ($justALog) {
            $this->addErr($justALog);
            $this->execErr();
        }
    }
    public function getLogger () {
        return $this->logger;
    }
    public function addErr ($string) {
        $this->string .= $string . "\r\n";
    }
    public function execErr () {
        $this->logger->error($this->string);
        $this->string = "";
    }
    public function getPersianDateTime () {
        $intlFormatter = new \IntlDateFormatter(
            "en_US@calendar=persian",
            \IntlDateFormatter::FULL,
            \IntlDateFormatter::FULL,
            'Asia/Tehran',
            \IntlDateFormatter::TRADITIONAL,
            "YYYY_MM_dd_HH:mm:ss"
        );
        $nowPersianFormatted = $intlFormatter->format(new \DateTime());
        return $nowPersianFormatted;
    }
}