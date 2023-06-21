# Arduino_Xbee_Project


![Screenshot_1](https://github.com/serkancan006/Arduino_Xbee_Project/assets/109299838/5199dd91-ed99-4d85-b9b9-6419fcb728f7)
![Screenshot_2](https://github.com/serkancan006/Arduino_Xbee_Project/assets/109299838/0c7b9640-2e83-43ce-b1b8-aee37b8430d6)

Bu kod, C# ve Arduino programlama dillerini içeren iki farklı uygulamanın birbirleriyle iletişimini sağlayan bir arayüz oluşturmak için kullanılmıştır. İki uygulama arasındaki iletişim, bir Arduino mikrodenetleyicisi üzerinden gerçekleştirilir.

## C# Uygulaması (Arduino_Arayuz1):
Bu C# kodu, bir Arduino arayüzü uygulamasını temsil ediyor. Bu uygulama, kullanıcı arayüzü üzerinden Arduino ile seri iletişim kurmayı sağlıyor ve bazı veritabanı işlemlerini gerçekleştiriyor. Aşağıda bu kod ile ilgili bir açıklama yazısı verilmiştir:

Bu C# uygulaması, Arduino ile etkileşimde bulunabilen bir kullanıcı arayüzü sunar. Uygulama, bir veritabanı kullanır ve Arduino ile seri iletişim için bir bağlantı oluşturur. Kullanıcı, arayüz üzerinden eşik değerini güncelleyebilir ve sensör verilerini görüntüleyebilir.

Anahtar özellikler:

portlistele metodu, mevcut seri portları tespit eder ve ComboBox'a ekler.
gettblesik metodu, tblesik tablosundaki verileri DataGridView kontrolünde görüntüler.
gettblsensör metodu, tblsensör tablosundaki verileri DataGridView kontrolünde görüntüler.
esikgonder metodu, eşik değerini Arduino'ya gönderir ve Arduino'dan gelen verileri işler.
Form1_Load olayı, form yüklendiğinde gerekli verileri yükler.
Form1_FormClosing olayı, form kapatıldığında seri port bağlantısını kapatır.
button1_Click olayı, eşik değerini günceller ve veritabanında kaydeder.
button4_Click olayı, seri portları yeniden listeler.
button5_Click olayı, seri port bağlantısını başlatır veya keser.
Bu uygulama, Arduino ile etkileşimde bulunmak ve veritabanı işlemlerini gerçekleştirmek için kullanılabilir. Kullanıcılar, eşik değerlerini güncelleyebilir, sensör verilerini izleyebilir ve Arduino'ya komutlar gönderebilir.

## C# Uygulaması (Arduino_Arayüz2):
Bu C# kodu, bir Arduino arayüzü uygulamasını temsil ediyor. Bu uygulama, kullanıcı arayüzü üzerinden Arduino ile seri iletişim kurmayı sağlıyor ve gelen verileri veritabanına kaydediyor. Aşağıda bu kod ile ilgili bir açıklama yazısı verilmiştir:

Bu C# uygulaması, Arduino ile etkileşimde bulunabilen bir kullanıcı arayüzü sunar. Uygulama, bir veritabanı kullanır ve Arduino ile seri iletişim için bir bağlantı oluşturur. Kullanıcının seçebileceği bir ComboBox aracılığıyla seri portları listeler ve bağlantıyı başlatır veya keser.

Anahtar özellikler:

portlistele metodu, mevcut seri portları tespit eder ve ComboBox'a ekler.
gettblsensör metodu, tblsensör tablosundaki verileri DataGridView kontrolünde görüntüler.
inserttblsensör metodu, Arduino'dan gelen verileri tblsensör tablosuna kaydeder.
Form1_Load olayı, form yüklendiğinde gerekli verileri yükler ve seri port üzerinden veri almayı dinlemek için serialPort1_DataReceived olayını ayarlar.
serialPort1_DataReceived olayı, seri porttan veri alındığında tetiklenir ve veriyi data değişkenine kaydeder.
button5_Click_1 olayı, seri port bağlantısını başlatır veya keser.
button4_Click_1 olayı, seri portları yeniden listeler.
Form1_FormClosing_1 olayı, form kapatıldığında seri port bağlantısını kapatır.
Bu uygulama, Arduino ile iletişim kurmak ve gelen verileri kaydetmek için kullanılabilir. Arduino'dan gelen sensör verileri otomatik olarak veritabanına kaydedilir ve kullanıcı bu verileri DataGridView üzerinden görüntüleyebilir.

## Arduino Buzzer
Bu kod, bir alıcı devreye aittir ve kablosuz olarak veri alışverişi yapmak için bir Xbee kablosuz modül kullanır. Alınan veriye göre belirlenen eşik değeri ile karşılaştırma yapar ve buna göre LED'leri ve bir buzzer'ı kontrol eder.

Kodun İşlevleri:

SoftwareSerial kütüphanesi dahil edilir ve Xbee modülünün RX ve TX pinleri belirlenir.
esik, buzzerpin, data, k_led, y_led, m_led gibi değişkenler tanımlanır.
setup() fonksiyonunda Xbee modülü başlatılır, seri haberleşme başlatılır ve pin modları ayarlanır.
loop() fonksiyonunda ana kod döngüsü yer alır.
delay(500) ile 500 milisaniye beklenir.
data değişkeni -1 olarak ayarlanır.
xbee.available() ile Xbee modülünden veri kontrol edilir. Eğer veri varsa, data değişkenine veri atanır.
Serial.available() ile seri haberleşme üzerinden gelen veri kontrol edilir. Eşik değeri güncellendiğinde bu bloğa girilir.
Gelen eşik değeri (esik) ile data değeri karşılaştırılır. Eğer data eşik değerinden büyükse, buzzer ve LED'ler belirli bir duruma getirilir.
Eşik değeri farklı olasılıklara göre kontrol edilir ve buna göre LED'ler açılıp kapatılır.
Eğer seri haberleşmeden veri gelmediyse veya eşik değerine göre kontrol yapılmadıysa, LED'ler ve buzzer kapatılır.
Eğer data değişkeni -1 ise, bir uyarı sinyali verilir ve kırmızı LED yanar.
Son olarak, eşik değeri ve data değeri seri port üzerinden bilgisayara gönderilir.
Bu kod, Xbee modülü üzerinden kablosuz olarak veri alıp, belirlenen eşik değeriyle karşılaştırarak LED'leri ve buzzer'ı kontrol eder.

## Arduino Mq2
Bu kod, bir gaz sensörü olan MQ-2 sensöründen alınan analog veriyi ölçeklendirerek kablosuz olarak bir Xbee modülü aracılığıyla iletişim sağlar.

Kodun İşlevleri:

SoftwareSerial kütüphanesi dahil edilir ve Xbee modülünün RX ve TX pinleri belirlenir.
mq2 adında bir değişken tanımlanır.
setup() fonksiyonunda Xbee modülü başlatılır ve seri haberleşme başlatılır.
loop() fonksiyonunda ana kod döngüsü yer alır.
delay(500) ile 500 milisaniye beklenir.
analogRead(A0) ile A0 pininden analog veri okunur ve mq2 değişkenine atanır.
Serial.println(mq2) ile mq2 değeri seri port üzerinden bilgisayara gönderilir.
xbee.print(mq2/100) ile mq2 değeri 100'e bölünerek ölçeklendirilir ve Xbee modülü üzerinden kablosuz olarak gönderilir.
Bu kod, MQ-2 gaz sensöründen alınan değeri ölçeklendirerek Xbee modülü ile kablosuz olarak iletişim sağlar ve bu değeri seri port üzerinden bilgisayara da gönderir.
