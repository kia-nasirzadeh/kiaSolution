<?php
$data = "aaaaaaaaaabbbbbbbbbbaaaaaaaaaabbbbbbbbbbaaaaaaaaaabbbbbbbbbbaaaaaaaaaabbbbbbbbbbaaaaaaaaaabbbbbbbbbb"; //100 octets
$data .= $data;
$data .= $data;
$data .= $data;
$data .= $data;
$data .= $data; //3200 octets
$data .= $data; //6400 octets
// $data .= $data; //12800 octets
