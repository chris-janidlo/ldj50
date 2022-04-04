using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LDJ50.CoreRules;
using crass;

namespace LDJ50
{
    [CreateAssetMenu(menuName = "LDJ50/Deciders/Random", fileName = "newRandomDecider.asset")]
    public class RandomDecider : IDecider
    {
        public override void DecideMove (GameState currentState, DecisionCallback callback)
        {
            var movePool = currentState.LegalFutureStates().ToList();
            callback(movePool.PickRandom());
        }
    }
}
