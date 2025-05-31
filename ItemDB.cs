using Godot;

public partial class ItemDB : Node3D {
	[Export] public Godot.Collections.Array<PackedScene> products = new();
	[Export] public Godot.Collections.Array<PackedScene> containers = new();


	public override void _Ready() {
			// NOTE: Unknown if this is bad performance wise
			GD.Print(containers[0].Instantiate<Node3D>().Name);
	}
}
