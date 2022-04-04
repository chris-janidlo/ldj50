using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LDJ50.CoreRules;

namespace LDJ50
{
    public delegate void DecisionCallback (GameState decision);

    public abstract class IDecider : ScriptableObject
    {
        public abstract void DecideMove (GameState currentState, DecisionCallback callback);
    }
}
