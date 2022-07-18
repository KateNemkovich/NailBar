namespace TheElseKeyword.Example;

public class Bartender
{
    private readonly Func<string> _inputProvider; //поле для чтения присвоим занчение только при их объявлении,либо в конструкторе, что мы и сделаем в методе ниже. делегат func  возвращает результат действий
    private readonly Action<string> _outputProvider;//делегат Action действие которое ничего не возвращает, просто вызывает фразы в ответ на произошедшее действие

    public Bartender(Func<string> inputProvider, Action<string> outputProvider)//что подаётся в конструктор для присвоения полям чтения
    {
        _inputProvider = inputProvider;
        _outputProvider = outputProvider;
    }

    public void AskForDrink() //ничего не возвращающий метод, он просто совершает действия (диалог)
    {
        _outputProvider("What drink do you want? (beer,juice,still water)");

        var drink = _inputProvider() ?? string.Empty;//получаем введённое значение  (что означает (?? string.Empty)?)
        if (drink.Equals("beer"))
        {
            _outputProvider("Not so fast cowboy.How old are you?");
            if (!int.TryParse(_inputProvider(), out var age))//out передача аргумента по ссылке??
            {
                _outputProvider("Could not parse the age provided");
            }
            else
            {
                if (age >= 18)
                {
                    _outputProvider("Here you go! Cold beer.");
                }
                else
                {
                    _outputProvider("Sorry but you're not old enough to drink (in the UK)");
                }
            }
        }
        else if (drink.Equals("juice"))
        {
            _outputProvider("Here you go!Fresh and nice juice.");
        }
        else if (drink.Equals("still water"))
        {
            _outputProvider("especially for you,Roma");
        }
        else
        {
            _outputProvider($"Sorry mate,but we don't do {drink}");
        }
    }
}