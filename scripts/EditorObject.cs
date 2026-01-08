using Godot;
using System;

public partial class EditorObject : Node2D
{
    private bool _canPlace = true;
    private PackedScene _currentItem;

    private Node _level;

    public override void _EnterTree()
    {
        //From Item.cs
        EventManager.ItemSelectedEvent += ItemSelected;
    }

    public override void _Ready()
    {
        _level = GetNode("/root/Map Creator/Level");
    }

    private void ItemSelected(PackedScene scene)
    {
        _currentItem = scene;
    }

    public override void _Process(double delta)
    {
        GlobalPosition = GetGlobalMousePosition();
        if (_currentItem != null && _canPlace && Input.IsActionJustPressed("ui_click"))
        {
            // Cast to Node2D to access GlobalPosition
            var _newItem = (Node2D)_currentItem.Instantiate(); 
            _level.AddChild(_newItem);

            _newItem.GlobalPosition = GetGlobalMousePosition();
        }
    }

    public override void _ExitTree()
    {
        EventManager.ItemSelectedEvent -= ItemSelected;
    }
}
