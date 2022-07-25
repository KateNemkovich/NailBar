namespace TheElseKeyword.Example;

public class RecipeBook
{
  private readonly Dictionary<string, Action> _nailArts;
  private readonly Func<string> _inputProvider; //поле для чтения присвоим занчение только при их объявлении,либо в конструкторе, что мы и сделаем в методе ниже. делегат func  возвращает результат действий
  private readonly Action<string> _outputProvider;//делегат Action действие которое ничего не возвращает, просто вызывает фразы в ответ на произошедшее действие
  
  public RecipeBook(Func<string> inputProvider, Action<string> outputProvider)
  {
    _inputProvider = inputProvider;
    _outputProvider = outputProvider;
    _nailArts = new Dictionary<string, Action>
    {
      {"moon",MakeMoon},
      {"matte",MakeMatte},
      {"french",SpecialFrench},
      {"aquarium",MakeAquarium},
    };
  }
  public void GetRecipe(string manicureName)
  {
    _nailArts[manicureName]();
  }
  public IEnumerable<string> GetAvailableDrinkNames()
  {
    return _nailArts.Keys;
  }
  private void ManicureIsNotAvailable(string manicure)
  {
    _outputProvider($"Sorry babe,but we don't do {manicure}");
  }

  private void MakeAquarium()
  {
    _outputProvider("How much time do you have?");
    if (!int.TryParse(_inputProvider(), out var time)) //out передача аргумента по ссылке??
    {
      HandleInvalidTime();
      return;
    }
        
    HandleNailsTimeCheck(time);
  }
  private void SpecialFrench()
  {
    _outputProvider("especially for you,Roma");
  }

  private void MakeMatte()
  {
    _outputProvider("Nice choice!Let's get started.");
  }

  private void MakeMoon()
  {
    _outputProvider("How much time do you have?");
    if (!int.TryParse(_inputProvider(), out var time)) //out передача аргумента по ссылке??
    {
      HandleInvalidTime();
      return;
    }
        
    HandleNailsTimeCheck(time);
  }
  private void HandleNailsTimeCheck(int time)
  {
    if (time >=2)
    {
      _outputProvider("Ok! I will make it!");
      return;
    }
    _outputProvider("Sorry but there's not enough time for this.");
  }
  private void HandleInvalidTime()
  {
    _outputProvider("Could not parse the time provided");
  }
}