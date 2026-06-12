using BingoSync.CustomGoals;
using Modding;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace BingoGoalPackGrubDay
{
    public class BingoGoalPackGrubDay : Mod
    {
        new public string GetName() => "BingoGoalPackGrubDay";
        public override string GetVersion() => "1.0.0.0";

        public override void Initialize()
        {
            Log("Initializing");
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "BingoGoalPackGrubDay.Resources.Squares.Goals.json";
            Stream stream = assembly.GetManifestResourceStream(resourceName);
            Dictionary<string, BingoGoal> goals = BingoSync.Goals.ProcessGoalsStream(stream);
            BingoSync.Goals.RegisterGoalsForCustom("Grub Day 2026", goals);
        }
    }
}