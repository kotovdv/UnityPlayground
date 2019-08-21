using System.Collections.Generic;

public interface IState
{
    string Description { get; }

    IDictionary<int, IAction> PossibleOptions { get; }
}