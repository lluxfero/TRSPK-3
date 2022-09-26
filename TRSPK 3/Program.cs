using System.Text;

Man man = new Man();
man.GetFromFile();
man.WriteToFile();

class Building
class Man
{
    private string Name = "";
    private int Age = 0;
    public async void GetFromFile(string path = "INPUT.TXT")
    {
        using (FileStream fstream = File.OpenRead(path))
        {
            byte[] buffer = new byte[fstream.Length];
            await fstream.ReadAsync(buffer, 0, buffer.Length);
            string TextFromFile = Encoding.Default.GetString(buffer); //декодирование байтов в строку
            string[] str = TextFromFile.Split();
            Name = str[0];
            Age = Convert.ToInt32(str[1]);
            Console.WriteLine($"Имя: {Name}\r\nВозраст: {Age}");
        }
    }
    public async void WriteToFile(string path = "OUTPUT.TXT")
    {
        using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
        {
            string str = Name + " " + Age;
            byte[] buffer = Encoding.Default.GetBytes(str); //преобразование строки в байты
            await fstream.WriteAsync(buffer, 0, buffer.Length); //запись массива байтов в файл
            Console.WriteLine("Текст записан в файл");
        }
    }
}