using System;
using UnityEngine;
using LDJ50;
namespace UnityAtoms.LDJ50Atoms
{
    /// <summary>
    /// IPair of type `&lt;IDecider&gt;`. Inherits from `IPair&lt;IDecider&gt;`.
    /// </summary>
    [Serializable]
    public struct IDeciderPair : IPair<IDecider>
    {
        public IDecider Item1 { get => _item1; set => _item1 = value; }
        public IDecider Item2 { get => _item2; set => _item2 = value; }

        [SerializeField]
        private IDecider _item1;
        [SerializeField]
        private IDecider _item2;

        public void Deconstruct(out IDecider item1, out IDecider item2) { item1 = Item1; item2 = Item2; }
    }
}