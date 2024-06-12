<?php
namespace KiaNasirzadeh\x10th\Errorhandlers;

use \Exception;
use KiaNasirzadeh\x10th\Errorhandlers\Logger;

class ErrorHandler {
    function __construct (Exception $ex, Logger $logger)
    {
        $exceptionMessage = $ex->getMessage();
        $logger->addErr($exceptionMessage);
        
        $exceptionTraceArr = $ex->getTrace();
        rsort($exceptionTraceArr);
        foreach ($exceptionTraceArr as $key => $item) {
            $file = substr($item['file'], strrpos($item['file'], "\\") + 1, strlen($item['file']));
            $line = $item['line'];
            $fileLine = $file . ":" . $line;
            $no = $key + 1; // stack number in order of execution
            $argsString = "(";
            foreach ($item['args'] as $key => $arg) {
                if ($key == array_key_last($item['args'])) $argsString .= "$arg";
                else $argsString .= "$arg, ";
            }
            $argsString .= ")";

            if ($key == 0)
            $logger->addErr("$no : first, interpreter was performing: " . $item['function'] . $argsString . ' -> ' . $fileLine);
            else
            $logger->addErr("$no : from there then it passed to     : " . $item['function'] . $argsString . ' -> ' . $fileLine);
        }

        $logger->execErr();
    }
}