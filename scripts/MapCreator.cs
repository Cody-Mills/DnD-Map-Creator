using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class MapCreator : Node2D
{
    private Button _save;

    public override void _EnterTree()
    {
        _save = GetNode<Button>("%Save");

        _save.Pressed += SavePressed;
    }

    private void SavePressed()
    {
        GD.Print("SAVING");
    }

    public override void _ExitTree()
    {
        if (_save != null)
        {
            _save.Pressed -= SavePressed;
        }
    }
}
