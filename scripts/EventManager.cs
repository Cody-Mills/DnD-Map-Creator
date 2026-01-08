using System;
using System.Diagnostics.Contracts;
using Godot;

[GlobalClass]
public partial class EventManager : Node
{
    public static Action<PackedScene> ItemSelectedEvent;
    //Goes to EditorObject.cs & Sprite.cs
    public static void BroadcastItemSelectedEvent(PackedScene scene) { ItemSelectedEvent?.Invoke(scene);}

    public static Action<Texture> SendTextureEvent;
    //Goes to Item.cs
    public static void BroadcastSendTextureEvent(Texture texture) { SendTextureEvent?.Invoke(texture);}
}
