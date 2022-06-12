namespace GaussElemeYontemi
{
    class Program
    {
        static void Main(string[] args)
        {

            int boyut = 3;

            double[,] matris = new double[boyut, boyut];
            double[] deger = new double[boyut];



            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j < boyut; j++)
                {
                    Console.Write((i + 1) + " satir " + (j + 1) + " .sutundaki elemani giriniz: ");
                    matris[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }


            for (int i = 0; i < boyut; i++)
            {
                Console.Write((i + 1) + ". degeri giriniz : ");
                deger[i] = Convert.ToDouble(Console.ReadLine());

            }

            GaussEleme(matris, deger, boyut);
            Console.ReadLine();
        }

        static void GaussEleme(double[,] matris, double[] deger, int boyut)
        {
            for (int i = 0; i < boyut; i++)
            {
                double geciciIlk = matris[i, i];
                for (int k = 0; k < boyut; k++)
                {
                    matris[i, k] /= geciciIlk;
                }
                deger[i] /= geciciIlk;


                for (int j = i + 1; j < boyut; j++)
                {
                    double carpim = matris[j, i] / matris[i, i];

                    for (int l = 0; l < boyut; l++)
                    {
                        matris[j, l] = matris[j, l] - (carpim * matris[i, l]);
                    }
                    deger[j] = deger[j] - (carpim * deger[i]);
                }
            }

            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j < boyut; j++)
                {
                    Console.Write(matris[i, j] + "\t");
                }

                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = 0; i < boyut; i++)
                Console.WriteLine(deger[i]);

            double[] sonuclar = new double[boyut];
            sonuclar[boyut - 1] = deger[boyut - 1];

            for (int i = boyut - 2; i >= 0; i--)
            {
                double toplam = 0;
                for (int j = i + 1; j < boyut; j++)
                {
                    toplam += matris[i, j] * sonuclar[j];
                }
                sonuclar[i] = deger[i] - toplam;
            }

            double hava = 0;
            double kahvalti = 0;
            double borsa = 0;
            for (int i = 0; i < boyut; i++)
            {

                if (i == 0)
                    hava = sonuclar[i];
                else if (i == 1)
                    kahvalti = sonuclar[i];
                else if (i == 2)
                    borsa = sonuclar[i];
            }
            Console.WriteLine("4. Gün Hava Durumu Giriniz");
            var sonHesapData1 = Console.ReadLine();
            Console.WriteLine("4. Gün Kahvaltı Giriniz");
            var sonHesapData2 = Console.ReadLine();
            Console.WriteLine("4. Gün Para Durumu Giriniz");
            var sonHesapData3 = Console.ReadLine();

            double hesapla = (Convert.ToDouble(sonHesapData1) * hava)+(Convert.ToDouble(sonHesapData2)*kahvalti)+(Convert.ToDouble(sonHesapData3)*borsa);

            Console.WriteLine("4.Gün Mutluluk Oranı : {0}",hesapla);

        }
    }
}