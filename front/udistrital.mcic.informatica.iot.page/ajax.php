<?php
date_default_timezone_set('America/Bogota');

$date = new DateTime();

$url = 'http://iotrest.azurewebsites.net/api/Noise?startDate=<%startDate%>&startHour=<%startHour%>&endDate=<%endDate%>&endHour=<%endHour%>';

$url = str_replace( "<%endDate%>" , $date->format('Y-m-d') , $url );
$url = str_replace( "<%endHour%>" , $date->format('H:i') , $url );

$date->modify('-60 minute');

$url = str_replace( "<%startDate%>" , $date->format('Y-m-d') , $url );
$url = str_replace( "<%startHour%>" , $date->format('H:i') , $url );


$ch = curl_init($url);
curl_setopt($ch, CURLOPT_CUSTOMREQUEST, "GET");                                                                                                                                    
curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);                                                                      
curl_setopt($ch, CURLOPT_HTTPHEADER, array(                                                                          
    'Content-Type: application/json'                                                                             
    )                                                                       
);                                                                                                                   
                                                                                                                     
echo curl_exec($ch);