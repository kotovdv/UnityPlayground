using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Room")]
public class Room : ScriptableObject, IState
{
    public string roomName;
    [TextArea] public string description;
    public List<Exit> exits;

    public string Description => description;
    public IDictionary<int, IAction> PossibleOptions { get; private set; }

    private void Awake()
    {
        PossibleOptions = CalculatePossibleOptions();
    }

    private IDictionary<int, IAction> CalculatePossibleOptions()
    {
        var actions = new List<IAction>();
        actions.AddRange(exits);

        var index = 0;
        return actions.ToDictionary(action => index++);
    }
}