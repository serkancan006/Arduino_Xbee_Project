#include <SoftwareSerial.h>
SoftwareSerial xbee(2, 3);  // RX, TX
int esik = '4';
int buzzerpin = 13;
int data;
//led
int k_led = 11;
int y_led = 10;
int m_led = 9;


void setup() {
  // put your setup code here, to run once:
  xbee.begin(57600);
  Serial.begin(9600);
  pinMode(buzzerpin, OUTPUT);
  //led pin mode
  pinMode(k_led, OUTPUT);
  pinMode(y_led, OUTPUT);
  pinMode(m_led, OUTPUT);
}

//Alıcı Devre Buzzerlı olan
void loop() {
  // put your main code here, to run repeatedly:
  delay(500);
  data = -1;

  if (xbee.available()) {
    data = xbee.read() - 48;  // 0 degeri ascii de 48 e eşit
    if (Serial.available()) {
      esik = Serial.read();
      if (data > esik - 48) {
        digitalWrite(buzzerpin, HIGH);
        digitalWrite(k_led, HIGH);
        digitalWrite(y_led, LOW);
        digitalWrite(m_led, LOW);
      } else {
        if (esik == 48) {  //mavi 0
          digitalWrite(m_led, HIGH);
          digitalWrite(y_led, LOW);
          digitalWrite(k_led, LOW);
        }
        else if (esik == 49) {  //yeşil 1
          digitalWrite(y_led, HIGH);
          digitalWrite(m_led, LOW);
          digitalWrite(k_led, LOW);
        }
        else if (esik == 50) {  //sönük 2 default 400-600 arası
          digitalWrite(y_led, LOW);
          digitalWrite(m_led, LOW);
          digitalWrite(k_led, LOW);
        }
        else if (esik == 51) {  //mor 3
          digitalWrite(y_led, LOW);
          digitalWrite(m_led, HIGH);
          digitalWrite(k_led, HIGH);
        }
        else if (esik == 52) {  //sarı 4
          digitalWrite(y_led, HIGH);
          digitalWrite(m_led, LOW);
          digitalWrite(k_led, HIGH);
        }
        else {                  //Beyaz 5
          digitalWrite(y_led, HIGH);
          digitalWrite(m_led, HIGH);
          digitalWrite(k_led, HIGH);
        }
      }
    } else {
      if (data > esik - 48) {
        digitalWrite(buzzerpin, HIGH);
        digitalWrite(k_led, HIGH);
        digitalWrite(y_led, LOW);
        digitalWrite(m_led, LOW);
      } else {
        digitalWrite(buzzerpin, LOW);
        digitalWrite(y_led, LOW);
        digitalWrite(m_led, LOW);
        digitalWrite(k_led, LOW);
      }
    }
  } else if (data = -1) {
    digitalWrite(buzzerpin, HIGH);
    delay(50);
    digitalWrite(buzzerpin, LOW);
    digitalWrite(k_led, HIGH);
    digitalWrite(y_led, LOW);
    digitalWrite(m_led, LOW);
    delay(50);
    digitalWrite(k_led, LOW);
  }
  Serial.println(esik);
  //Serial.println(data);
}
