using Godot;
using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public partial class Item : TextureRect
{
    private TextureRect _texture;

    [Export]
    public PackedScene scene;

    public override void _EnterTree()
    {
        //_texture.GuiInput += ItemClicked;
        EventManager.SendTextureEvent += SetTexture;
    }
    

    private void ItemClicked(InputEvent @event)
    {
        if (Input.IsActionJustPressed("ui_click"))
        {
            EventManager.BroadcastItemSelectedEvent(scene);

        }
    }

    public void SetTexture(Texture sentTexture)
    {
        sentTexture = Texture;
    }

    public override void _ExitTree()
    {
        if (_texture != null)
        {
            _texture.GuiInput -= ItemClicked;
        }
        EventManager.SendTextureEvent -= SetTexture;
    }
}
