namespace NailBar;

internal class Program
{
    private static void Main(string[] args)
    {
        //создаём объект класса NailBar (с применением конструктора)
        var recipeBook = new RecipeBook(Console.ReadLine, Console.WriteLine);
        var manicurist = new NailBar(Console.ReadLine, Console.WriteLine, recipeBook);
        while (true) manicurist.AskForNailsDesign();
    }
}