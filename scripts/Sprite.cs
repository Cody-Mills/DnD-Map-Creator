using Godot;
using System;

public partial class Sprite : Sprite2D
{
    public override void _EnterTree()
    {
        EventManager.ItemSelectedEvent += ItemSelected;
    }

    private void ItemSelected(PackedScene scene)
    {
        EventManager.BroadcastSendTextureEvent(this.Texture);
    }

    public override void _ExitTree()
    {
        EventManager.ItemSelectedEvent -= ItemSelected;
    }
}
