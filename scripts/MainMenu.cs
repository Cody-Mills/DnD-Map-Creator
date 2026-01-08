using Godot;
using System;

public partial class MainMenu : CanvasLayer
{
    private Button _create;
    private Button _load;
    private Button _exit;

    public override void _EnterTree()
    {
        _create = GetNode<Button>("Control/VBoxContainer/Create Map Button");
        _load = GetNode<Button>("Control/VBoxContainer/Load Map Button");
        _exit = GetNode<Button>("Control/VBoxContainer/Exit Button");

        _create.Pressed += CreatePressed;
        _load.Pressed += LoadPressed;
        _exit.Pressed += ExitPressed;
    }

    private void CreatePressed()
    {        
        //Map Creator
        GetTree().Root.AddChild(GD.Load<PackedScene>("uid://ddb6u6do1vu24").Instantiate());
        this.QueueFree();
    }

    private void LoadPressed()
    {
        //Open File Explorer
    }

    private void ExitPressed()
    {
        GetTree().Quit();
    }

    public override void _ExitTree()
    {
        if (_create != null)
        {
            _create.Pressed -= CreatePressed;
        }
        if (_load != null)
        {
            _load.Pressed -= LoadPressed;
        }
        if (_exit != null)
        {
            _exit.Pressed -= ExitPressed;
        }
    }
}
