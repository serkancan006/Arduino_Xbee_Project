#include <SoftwareSerial.h>
SoftwareSerial xbee(2, 3); // RX, TX
int mq2;

void setup() {
  xbee.begin(57600);
  Serial.begin(9600);
}

void loop() {
  delay(500);
  mq2 = analogRead(A0);
  Serial.println(mq2);

  xbee.print(mq2/100);
}



