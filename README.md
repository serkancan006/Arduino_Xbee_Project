![Screenshot_4](https://github.com/serkancan006/Arduino_Xbee_Project/assets/109299838/aa2b9a5b-13aa-4378-8fe1-13cbbb25cfd6)
![Screenshot_4](https://github.com/serkancan006/Arduino_Xbee_Project/assets/109299838/6ecb307b-7276-4506-9007-c249ab014231)
# Arduino_Xbee_Project




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

![arayüz1](https://github.com/serkancan006/Arduino_Xbee_Project/assets/109299838/6a238a84-b9ff-4598-a9f4-fd80d98453b6)


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
Bu uygulama, Arduino ile iletişim kurmak ve gelen verileri kaydetmek için kullanılabilir. Arduino'dan gelen sensör verileri otomatik olarak 
veritabanına kaydedilir ve kullanıcı bu verileri DataGridView üzerinden görüntüleyebilir.

![arayüz2](https://github.com/serkancan006/Arduino_Xbee_Project/assets/109299838/12bbc3f2-2558-470c-a4bf-d5b509bf5476)


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

## Xbee Configürasyon Router 1
![Screenshot_1](https://github.com/serkancan006/Arduino_Xbee_Project/assets/109299838/f8cdcf6a-d665-489f-a783-6b829ca90123)
![Screenshot_2](https://github.com/serkancan006/Arduino_Xbee_Project/assets/109299838/82696e4e-b817-472b-8a38-256809432e9d)
![Screenshot_4](https://github.com/serkancan006/Arduino_Xbee_Project/assets/109299838/cc5771f7-3ec3-46c7-b616-92b97d437de1)


## Xbee Configürasyon Router 1
![Screenshot_1](https://github.com/serkancan006/Arduino_Xbee_Project/assets/109299838/6bf2d7db-1402-4c9e-ac6b-123d7bed8389)
![Screenshot_2](https://github.com/serkancan006/Arduino_Xbee_Project/assets/109299838/90bf82bc-09cc-40fc-aa56-7f0f68edfcad)
![Screenshot_3](https://github.com/serkancan006/Arduino_Xbee_Project/assets/109299838/285768ee-4c49-4aa1-9fca-199c07a047f6)

## Sql server Database
![Screenshot_2](https://github.com/serkancan006/Arduino_Xbee_Project/assets/109299838/97f87fe3-8bfa-4f28-8726-eac71d13a513)
![Screenshot_3](https://github.com/serkancan006/Arduino_Xbee_Project/assets/109299838/5a8abec5-cbfd-4216-b306-a257157a9a4b)
![Screenshot_4](https://github.com/serkancan006/Arduino_Xbee_Project/assets/109299838/1bd1a654-9024-4636-a1df-1ef6285cdd43)



