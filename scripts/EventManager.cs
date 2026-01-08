using System;
using System.Diagnostics.Contracts;
using Godot;

[GlobalClass]
public partial class EventManager : Node
{
    public static Action<PackedScene> ItemSelectedEvent;
    public static void BroadcastItemSelectedEvent(PackedScene scene) { ItemSelectedEvent?.Invoke(scene);}


}
