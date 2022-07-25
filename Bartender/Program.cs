namespace NailBar;

internal class Program
{
    private static void Main(string[] args)
    {
        var recipeBook = new RecipeBook(Console.ReadLine, Console.WriteLine);
        var manicurist =
            new NailBar(Console.ReadLine, Console.WriteLine,
                recipeBook); //создаём объект класса NailBar (с применением конструктора?)
        while (true) manicurist.AskForNailsDesign();
    }
}