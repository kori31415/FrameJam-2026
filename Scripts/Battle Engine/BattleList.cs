using Godot;
using System;

public partial class BattleList : Node
{
    public static System.Collections.Generic.Dictionary<string, BattleFilepathList> battles = new System.Collections.Generic.Dictionary<string, BattleFilepathList> {
        { "Test Battle", new TestBattleFilepaths()}   
    };
}
