using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.LDJ50Atoms;
using TMPro;
using LDJ50.CoreRules;

namespace LDJ50.KinUI
{
    public class GameLog : MonoBehaviour
    {
        public GameLogGenerator Generator;
        public TextMeshProUGUI Text;

        List<string> logEntries;

        void Start ()
        {
            logEntries = new List<string>();
            Text.text = "";
        }

        public void OnDecisionMade (GameStatePair decision)
        {
            decision.Deconstruct(out GameState oldState, out GameState newState);
            string newLogEntry = Generator.GetLogEntryForAction(oldState, newState);

            if (logEntries.Count > 0) Text.text += "\n\n";
            Text.text += newLogEntry;
            logEntries.Add(newLogEntry);
        }
    }
}
