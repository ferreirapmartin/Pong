const int pinJoyX = A0;
const int pinJoyY = A1;
const int pinJoyButton = 2;
 
void setup() {
   pinMode(pinJoyButton , INPUT_PULLUP);   //activar resistencia pull up 
   Serial.begin(9600);
}
 
void loop() {
   int x = 0;
   int y = 0;
   bool botonPresionado = false;
 
   x = analogRead(pinJoyX);
   y = analogRead(pinJoyY);
   botonPresionado = digitalRead(pinJoyButton);
 
   Serial.print(x);
   Serial.print(",");
   Serial.print(y);
   Serial.print(",");
   Serial.println(botonPresionado);
   delay(100);
}
