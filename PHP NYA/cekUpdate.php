<?php
header("Access-Control-Allow-Origin: *");
header("Content-Type: Application/Json");

$data['update_version'] = 	"1.0.0.2";
$data['update_link'] 	= 	"http://bayuu.net/app_update.rar";
$data['deskripsi'] 		= 	"Ini merupakan versi terbaru".PHP_EOL.PHP_EOL.
							"* Penambahan fitur Update".PHP_EOL.
							"* Perbaikan minor bug";

echo json_encode($data, JSON_PRETTY_PRINT);

?>