using Godot;

public partial class ItemDB : Node3D {
	[Export] public Godot.Collections.Array<PackedScene> products = new();
	[Export] public Godot.Collections.Array<PackedScene> containers = new();

	public static ItemDB self;

	public override void _Ready() {
		self = this;
	}
}
