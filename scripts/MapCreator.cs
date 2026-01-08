using Godot;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

public partial class MapCreator : Node2D
{
    private Button _save;
    private Camera2D _camera;
    private Camera2D _screenshotCamera;
    private CanvasLayer _canvas;

    public override void _EnterTree()
    {
        _save = GetNode<Button>("%Save");
        _camera = GetNode<Camera2D>("%Camera2D");
        _screenshotCamera = GetNode<Camera2D>("%Screenshot Camera");
        _canvas = GetNode<CanvasLayer>("%CanvasLayer");

        _save.Pressed += SavePressed;
    }

    public override void _Ready()
    {
        if (_camera.IsCurrent() != true)
        {
            _camera.MakeCurrent();    
        }
        
    }

    private async void SavePressed()
    {
        GD.Print("SAVING");
        //Opens File Explorer (To be handled later)
        _canvas.Visible = false;
        //Screenshots whole image border & all
        _screenshotCamera.MakeCurrent();
        await ToSignal(GetTree().CreateTimer(1.0f), "timeout");
        var _file = GetViewport().GetTexture().GetImage();
        _file.SavePng("user://map.png"); //Change to save Location 
    }

    public override void _ExitTree()
    {
        if (_save != null)
        {
            _save.Pressed -= SavePressed;
        }
    }
}
