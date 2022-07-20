namespace TheElseKeyword.Example;

public class Bartender
{
    private readonly Func<string> _inputProvider; //поле для чтения присвоим занчение только при их объявлении,либо в конструкторе, что мы и сделаем в методе ниже. делегат func  возвращает результат действий
    private readonly Action<string> _outputProvider;//делегат Action действие которое ничего не возвращает, просто вызывает фразы в ответ на произошедшее действие
    private readonly RecipeBook _recipeBook;
    public Bartender(Func<string> inputProvider, Action<string> outputProvider, RecipeBook recipeBook)//что подаётся в конструктор для присвоения полям чтения
    {
        _inputProvider = inputProvider;
        _outputProvider = outputProvider;
        _recipeBook = recipeBook;
    }

    public void AskForDrink() //ничего не возвращающий метод, он просто совершает действия (диалог)
    {
        _outputProvider($"What drink do you want? ({string.Join(",",_recipeBook.GetAvailableDrinkNames())})");

        var drink = _inputProvider() ?? string.Empty;//получаем введённое значение  (что означает (?? string.Empty)?)

        if (!_recipeBook.GetAvailableDrinkNames().Contains(drink))
        {
            _outputProvider("Sorry I don't know how to make this jne");
            return;
        }

        _recipeBook.GetRecipe(drink);
    }
}