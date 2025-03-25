// See https://aka.ms/new-console-template for more information
using ProbabilityAndStatistics;

DataReceiver receiver = new DataReceiver();

bool dataLoaded = false;

while (!dataLoaded)
{
    receiver.SetData();
    dataLoaded = receiver.can;  
    if (dataLoaded)
    {
        Console.WriteLine("Veri başarıyla yüklendi!");
    }
    else
    {
        Console.WriteLine("Veri yükleme başarısız, lütfen tekrar deneyin.");
    }
}
bool continueProcess = true;

while (continueProcess)
{
    Console.WriteLine("\nLütfen aşağıdaki işlemlerden birini seçin:");
    
    Console.WriteLine("1: Sistematik Örnekleme");
    Console.WriteLine("2: Frekans Serisi");
    Console.WriteLine("3: Merkezî Eğilim Ölçüleri");
    Console.WriteLine("4: Değişkenlik Ölçüleri");
    Console.WriteLine("5: Basit Seri");
    Console.WriteLine("6: Frekans Tablosu");
    Console.WriteLine("7: Basit Rastgele Örnekleme");
    Console.WriteLine("8: Permütasyon ve Kombinasyon");
    Console.WriteLine("q: Çıkış");

    string choice = Console.ReadLine().ToLower();

    switch (choice)
    {
        case "6":
            receiver.FrequencyTable();
            break;
        case "1":
            receiver.SystematicRandomSampling();
            break;
        case "2":
            receiver.FrequencySeries();
            break;
        case "3":
            receiver.MeasuresOfCentralTendencedy();
            break;
        case "4":
            receiver.MeasuresOfVariability();
            break;
        case "5":
            receiver.SimpleSerialize();
            break;
        case "7":
            receiver.SetSimpleRandomSampling();
            break;
        case "8":
            receiver.PermutationAndCombination();
            break;
        case "q":
            continueProcess = false; // Çıkış
            Console.WriteLine("Uygulama kapatılıyor.");
            break;
        default:
            Console.WriteLine("Geçersiz seçim. Lütfen geçerli bir seçenek girin.");
            break;
    }
}
