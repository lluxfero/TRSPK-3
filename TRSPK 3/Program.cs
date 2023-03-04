Man man = new();
try
{
    Console.WriteLine($"Данные, полученные из файла \"INPUT.txt\":\n{man.GetFromFile("INPUT.txt")}\n");
    if (man.WriteToFile("OUTPUT.txt")) Console.WriteLine("Данные успешно записаны в файл \"OUTPUT.txt\"!\n");
    else Console.WriteLine("Ошибка при записи данных в файл \"OUTPUT.txt\"!\n");
}
catch
{
    Console.WriteLine("Ошибка при получении данных из файла \"OUTPUT.txt\"!\n");
}

class Person
{
    public readonly string Name = "";
    private const int Age = 30;
    public Person(string name)
    {
        Name = name;
    }
    public string GetInfo() //внутри был Console.WriteLine()
    {
        return $"Имя: {Name}\nВозраст: {Age}";
    }
    public static int GetExample() //имя метода - глагол
    {
        return Age + 10;
    }
}
class Man
{
    private string Name = "";
    private int Age = 0;
    public string GetFromFile(string path) //был сложный метод, внутри был Console.WriteLine()
    {
        using var reader = new StreamReader(path, System.Text.Encoding.Default);
        string? line;
        string[] words;
        if ((line = reader.ReadLine()) != null)
        {
            words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Name = words[0];
            Age = Convert.ToInt32(words[1]);
            return ($"Имя: {Name}\nВозраст: {Age}");
        }
        else throw new Exception();
    }
    public bool WriteToFile(string path) //был сложный метод, внутри был Console.WriteLine()
    {
        using var writer = new StreamWriter(path, false, System.Text.Encoding.Default);
        writer.WriteLine($"Имя: {Name}\nВозраст: {Age}");
        return true;
    }
}
