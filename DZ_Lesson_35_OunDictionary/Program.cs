using DZ_Lesson_35_OunDictionary;

Console.WriteLine("Реализация своего собственного словаря!");
Console.WriteLine("Заполним словарь.");
Console.WriteLine("Задайте размер словаря. Например 32 элемента");
try
{
    var size = int.Parse(Console.ReadLine());
    var dictionary = new OtusDictionary();
    dictionary.SetSizeOfArray(size);

    string? common = null;

    do
    {
        Console.WriteLine("Для добавления значений введите /Add, для просмотра - /Get, для выхода - /Exit");
        common = Console.ReadLine();

        switch (common)
        {
            case "/Add":
                Console.WriteLine("Введите пару key value через пробел. Для прекращения ввода - пустую строку");

                string? keyValue = null;
                do
                {
                    keyValue = Console.ReadLine();
                    if (string.IsNullOrEmpty(keyValue?.Trim()))
                        break;

                    string[] keyValueSplit = keyValue.Split(' ');
                    if (keyValueSplit.Length != 2)
                    {
                        throw new ArgumentNullException(nameof(keyValue));
                    }

                    int key;
                    bool resultParse = int.TryParse(keyValueSplit[0], out key);

                    dictionary[key] = keyValueSplit[1];
                }
                while (!string.IsNullOrEmpty(keyValue));

                break;
            case "/Get":
                Console.WriteLine("Введите key. Для прекращения ввода - пустую строку");

                string? input = null;
                do
                {
                    input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input?.Trim()))
                        break;

                    int key;
                    bool resultParse = int.TryParse(input, out key);

                    string? value = dictionary[key];
                    Console.WriteLine($"Значение справочника {key} - {value}");
                }
                while (!string.IsNullOrEmpty(input));

                break;
        }
    }
    while (common != "/Exit");
}
catch (FormatException)
{
    Console.WriteLine("Введите число");
}
catch (ArgumentNullException)
{
    Console.WriteLine("Вы не ввели значение");
}
catch (IndexOutOfRangeException)
{
    Console.WriteLine("Index was outside the bounds of the array");
    throw;
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.ParamName);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine("Программа завершена");