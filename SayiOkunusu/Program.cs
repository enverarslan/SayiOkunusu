using System;

namespace SayiOkunusu
{
    class Program
    {
        static void Main(string[] args)
        {
            // Birden çok sayı alabilmek için sonsuz döngü içerisinde çalış.
            while (true)
            {
                // Sayıyı Al
                int sayi = SayiAl();

                // Sayının okunuşunu al.
                string yazim = Okunus(sayi);

                // Okunuşu yazdır.
                Console.WriteLine("\n\"{0}\" sayısının okunuşu:\n\"{1}\"\n", sayi.ToString(), yazim.Trim().ToUpper());

            }

        }

        public static int SayiAl()
        {

            // Sayıyı bir değişkende tut.
            int sayi;

            while (true)
            {
                try
                {
                    // Kullanıcıdan sayıyı iste.
                    Console.Write("Lütfen en fazla 7 haneli bir sayı girin:");
                    // Sayıyı kullanıcıdan al ve integer tipine çevirerek değişkene ata. 
                    sayi = Convert.ToInt32(Console.ReadLine());

                    // Sayı belirtilen aralıkta değilse tekrar iste. 
                    if ((sayi > 9999999) || (sayi < 0))
                    {
                        continue;
                    }
                    // Sayı belirtilen aralıkta ise döngüyü kır.
                    break;
                }
                catch (OverflowException)
                {
                    // Sayı Int32'nin alabileceği değerden büyükse sayıyı tekrar iste.
                    continue;
                }
                catch (FormatException)
                {
                    // Sayı istenilen formatta değilse sayıyı tekrar iste.
                    continue;
                }

            }

            return sayi;


        }

        public static string Okunus(int sayi)
        {

            if (sayi == 0)
            {
                return "Sıfır";
            }

            // Basamak sayısını tut.
            int basamak = 0;

            // Basamak sayısını bulmak için sayıyı stringe çevirip string uzunluğunu al.
            basamak = sayi.ToString().Length;

            /* Sayının okunuşunu bir değişkende tut ve boş şekilde init et daha sonra buna eklemeler yap. */
            ;
            string okunus = "";

            // Kolaylık olsun diye birler ve onlar basamaklarındaki sayıların yazımını string dizisinde tut. Yazim stringine buradan ekle. 
            string[] birler = { "", "Bir", "İki", "Üç", "Dört", "Beş", "Altı", "Yedi", "Sekiz", "Dokuz" };
            string[] onlar = { "", "On", "Yirmi", "Otuz", "Kırk", "Elli", "Altmış", "Yetmiş", "Seksen", "Doksan" };


            while (basamak > 0) // Basamak bitmediği sürece dön.
            {

                int bolen = Convert.ToInt32(Math.Pow(10, basamak - 1)); // 10'luk sistemde basamaklar: 10^(n-1) => 10^6 | 10^5 | 10^4 | 10^3 | 10^2 | 10^1 | 10^0

                int bolum = (sayi / bolen) % 10; // Basamaktaki rakamı bul.
                // 10.000
                switch (basamak)
                {
                    case 7:
                        okunus += birler[bolum] + " Milyon ";
                        break;
                    case 6:
                        if (bolum == 0)
                        {
                            okunus += "";
                        }
                        else if (bolum == 1)
                        {
                            okunus += " Yüz ";
                        }
                        else
                        {
                            okunus += birler[bolum] + "Yüz ";
                        }
                        break;
                    case 5:
                        okunus += onlar[bolum] + " ";
                        break;
                    case 4:
                        // Binler basamağının okunuşu üst basamaklara göre değiştiği için onbinler ve yüzbinler basamağına ihtiyacımız var.
                        int yuzbinler = (sayi / 100000) % 10;
                        int onbinler = (sayi / 10000) % 10;

                        if (bolum == 0 && onbinler == 0 && yuzbinler == 0)
                        {
                            okunus += "";
                        }
                        else if (bolum == 1 && onbinler == 0)
                        {
                            okunus += " Bin ";
                        }
                        else
                        {
                            okunus += birler[bolum] + " Bin ";
                        }
                        break;
                    case 3:
                        if (bolum == 0)
                        {
                            okunus += "";
                        }
                        else if (bolum == 1)
                        {
                            okunus += " Yüz ";
                        }
                        else
                        {
                            okunus += birler[bolum] + "Yüz ";
                        }
                        break;
                    case 2:
                        okunus += onlar[bolum] + " ";
                        break;
                    case 1:
                        okunus += birler[bolum];
                        break;
                }

                basamak--; // Gezinmek için basamak değişkenini bir azalt.


            }

            // Sayının Okunuşunu döndür. 
            return okunus;
        }
    }
}