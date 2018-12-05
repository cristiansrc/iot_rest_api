#include <ArduinoJson.h>

#include <BearSSLHelpers.h>
#include <CertStoreBearSSL.h>
#include <ESP8266WiFi.h>
#include <ESP8266WiFiAP.h>
#include <ESP8266WiFiGeneric.h>
#include <ESP8266WiFiMulti.h>
#include <ESP8266WiFiScan.h>
#include <ESP8266WiFiSTA.h>
#include <ESP8266WiFiType.h>
#include <WiFiClient.h>
#include <WiFiClientSecure.h>
#include <WiFiClientSecureAxTLS.h>
#include <WiFiClientSecureBearSSL.h>
#include <WiFiServer.h>
#include <WiFiServerSecure.h>
#include <WiFiServerSecureAxTLS.h>
#include <WiFiServerSecureBearSSL.h>
#include <WiFiUdp.h>

#include <ESP8266HTTPClient.h>




/* Connection Pins
Arduino    Microphone
 GND          GND
 +5V          +5V
 D3           OUT (or D0) depends on Microphone
*/

#define ADC 0  // analog 0

//const int ADC; // define D0 Sensor Interface
float val;// define numeric variables val
int cont = 1;
float valSend = 0.0;
const String domainRestApi = "http://iotrest.azurewebsites.net/"; //Domain restApi
String restNoise = domainRestApi + "api/Noise"; //Endpoint noise
String restNoiseConfig = domainRestApi + "api/NoiseConfig"; //Endpoint noiseConfig
HTTPClient http; //Client http
DynamicJsonBuffer jsonBuffer; //Buffer string to json

void setup ()
{ 
  Serial.begin(9600);

  //WiFi.begin("Cristiansrc", "12345678");
  WiFi.begin("LOCAL", "crisAws85");

  while (WiFi.status() != WL_CONNECTED) {  //Wait for the WiFI connection completion
    delay(500);
    Serial.println("Waiting for connection");
    Serial.println();
  }
}

void loop ()
{
  delay(1);
  cont = cont - 1;
  val = analogRead(ADC);// digital interface will be assigned a value of pin 3 to read val

  if(val > 0){
    val = 10*log(val);
  }

  if(valSend < val){
    valSend = val;
  }

  if(cont == 0){
    cont = 1;
    Serial.println(valSend);
    Serial.println();
    String strDecibeles = (String) valSend;
    if(WiFi.status()== WL_CONNECTED){
      http.begin(restNoiseConfig);
      http.addHeader("Content-Type", "application/json"); 
      int httpCodeConfig = http.GET();
      String strHttpCodeConfig = (String) httpCodeConfig;

      if(httpCodeConfig == 200){
        String payload = http.getString();
        Serial.println("Se consumio config");
        Serial.println("Imprimo PayLoad");
        Serial.println(payload);
        JsonObject& jsonConfig = jsonBuffer.parseObject(payload);

        String onNoiseConfig = jsonConfig["OnNoiseConfig"].as<String>();
        cont = jsonConfig["TimeSendInfoNoiseConfig"].as<int>();
        Serial.println(cont);
        
        if(onNoiseConfig == "S"){
          http.begin(restNoise);  
          http.addHeader("Content-Type", "application/json"); 
          int httpCode = http.POST("{\"levelNoise\":" + strDecibeles + "}");
          String strHttpCode = (String) httpCode;
          valSend = 0;
          Serial.println("Respuesta del web service: " + strHttpCode);
          Serial.println();
          Serial.println();
          Serial.println();
          Serial.println();
          Serial.println();
          
        } 
      }
    } else {
      Serial.println("No se pudo enviar");
    }
    
    
  }
}
