namespace TheElseKeyword.Example;

public class RecipeBook
{
  private readonly Dictionary<string, Action> _recipes;
  private readonly Func<string> _inputProvider; //поле для чтения присвоим занчение только при их объявлении,либо в конструкторе, что мы и сделаем в методе ниже. делегат func  возвращает результат действий
  private readonly Action<string> _outputProvider;//делегат Action действие которое ничего не возвращает, просто вызывает фразы в ответ на произошедшее действие
  
  public RecipeBook(Func<string> inputProvider, Action<string> outputProvider)
  {
    _inputProvider = inputProvider;
    _outputProvider = outputProvider;
    _recipes = new Dictionary<string, Action>
    {
      {"beer",ServeBeer},
      {"juice",ServeJuice},
      {"stillwater",SpecialDrink},
      {"oldfashioned",ServerOldFashioned},
    };
  }
  public void GetRecipe(string drinkName)
  {
    _recipes[drinkName]();
  }
  public IEnumerable<string> GetAvailableDrinkNames()
  {
    return _recipes.Keys;
  }
  private void DrinkIsNotAvailable(string drink)
  {
    _outputProvider($"Sorry mate,but we don't do {drink}");
  }

  private void ServerOldFashioned()
  {
    _outputProvider("Not so fast cowboy.How old are you?");
    if (!int.TryParse(_inputProvider(), out var age)) //out передача аргумента по ссылке??
    {
      HandleInvalidAge();
      return;
    }
        
    HandleCoctailAgeCheck(age);
  }
  private void SpecialDrink()
  {
    _outputProvider("especially for you,Roma");
  }

  private void ServeJuice()
  {
    _outputProvider("Here you go!Fresh and nice juice.");
  }

  private void ServeBeer()
  {
    _outputProvider("Not so fast cowboy.How old are you?");
    if (!int.TryParse(_inputProvider(), out var age)) //out передача аргумента по ссылке??
    {
      HandleInvalidAge();
      return;
    }
        
    HandleBeerAgeCheck(age);
  }
  private void HandleCoctailAgeCheck(int age)
  {
    if (age >= 18)
    {
      _outputProvider("Here you go! Quite old school");
      return;
    }
    _outputProvider("Sorry but you're not old enough to drink (in the UK)");
  }
  private void HandleBeerAgeCheck(int age)
  {
    if (age >= 18)
    {
      _outputProvider("Here you go! Cold beer.");
      return;
    }
    _outputProvider("Sorry but you're not old enough to drink (in the UK)");
  }

  private void HandleInvalidAge()
  {
    _outputProvider("Could not parse the age provided");
  }
}