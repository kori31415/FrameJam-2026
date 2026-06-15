using Godot;
using System;

public partial class BattleLoader : Node
{
    public string SceneFile { get; set; }

    public string BattleFile { get; set; }

    public void LoadBattle(Node previousScene, Battle newBattle) {;
        PackedScene scene = GD.Load<PackedScene>(SceneFile);
        BattleRunner battleProcesser = new BattleRunner(newBattle);
        
        //Get everything in the Battle UI, add the runner.
        Node battleNode = scene.Instantiate();
        battleNode.AddChild(battleProcesser);

        //LISTEN. Calling deferred may be a lazy way to do it, 
        //but if you want deal with multithreading, that's a YOU problem.
        previousScene.GetParent().CallDeferred(Node.MethodName.AddChild, battleNode);
        previousScene.GetParent().CallDeferred(Node.MethodName.RemoveChild, previousScene);
    }    

    public BattleLoader() : this("", "") {}

    public BattleLoader(string sceneFile, string battleFile) {
        SceneFile =  sceneFile;
        BattleFile = battleFile;
    }
}