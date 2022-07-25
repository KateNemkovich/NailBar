using System;

namespace TheElseKeyword.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var recipeBook = new RecipeBook(Console.ReadLine, Console.WriteLine);
            var manicurist = new NailBar(Console.ReadLine, Console.WriteLine,recipeBook);//создаём объект класса NailBar (с применением конструктора?)
            while (true)
            {
                manicurist.AskForNailsDesign();
            }
        }
    }
}