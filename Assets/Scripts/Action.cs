using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
    public string Keyword;

    public abstract void RespondToInput(GameController controller, string noun);
    //Any child from base class from action must implement this function
}
