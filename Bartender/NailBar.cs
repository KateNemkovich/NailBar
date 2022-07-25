namespace NailBar;

public class NailBar
{
    private readonly Func<string>
        _inputProvider; //поле для чтения присвоим занчение только при их объявлении,либо в конструкторе, что мы и сделаем в методе ниже. делегат func  возвращает результат действий

    private readonly Action<string>
        _outputProvider; //делегат Action действие которое ничего не возвращает, просто вызывает фразы в ответ на произошедшее действие

    private readonly RecipeBook _recipeBook;

    public NailBar(Func<string> inputProvider, Action<string> outputProvider,
        RecipeBook recipeBook) //что подаётся в конструктор для присвоения полям чтения
    {
        _inputProvider = inputProvider;
        _outputProvider = outputProvider;
        _recipeBook = recipeBook;
    }

    /// <summary>
    ///     ничего не возвращающий метод, он просто совершает действия (диалог)
    /// </summary>
    public void AskForNailsDesign()
    {
        _outputProvider($"What design do you want? ({string.Join(",", _recipeBook.GetAvailableDesigns())})");

        var design = _inputProvider() ?? string.Empty; //получаем введённое значение  (что означает (?? string.Empty)?)

        if (!_recipeBook.GetAvailableDesigns().Contains(design))
        {
            _outputProvider($"Sorry babe,but we don't do {design}");
            return;
        }

        _recipeBook.GetRecipe(design);
    }
}