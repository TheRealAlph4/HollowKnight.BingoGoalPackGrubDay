using BingoSync.CustomGoals;
using Modding;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BingoSync.Interfaces;
using System;

namespace BingoGoalPackGrubDay
{
    public class BingoGoalPackGrubDay : Mod
    {
        new public string GetName() => "BingoGoalPackGrubDay";
        public override string GetVersion() => "1.1.0.0";

        public override void Initialize()
        {
            Log("Initializing");
            OrderedLoader.OnReadyForGoalsGameModes += OnReadyForGoalsGameModes;
        }

        private void OnReadyForGoalsGameModes(object sender, EventArgs e)
        {
            Log("BingoGoalPackGrubDay.OnReadyForGoalsGameModes");
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "BingoGoalPackGrubDay.Resources.Squares.Goals.json";
            Stream stream = assembly.GetManifestResourceStream(resourceName);
            Dictionary<string, BingoGoal> goals = Goals.ProcessGoalsStream(stream);
            Goals.RegisterGoalsForCustom("Grub Day 2026", goals);
        }
    }
}