using Godot;

public partial class Product : Node3D {
	[Export] public string name;
	[Export] public Texture2D icon;
	[Export] public int buyPrice;
	[Export] public int sellPrice;

	private Vector3 size;

	public override void _Ready() {
		size = (GetChild<CollisionShape3D>(0).Shape as BoxShape3D).Size;
	}

	public override void _Process(double delta) {
	}

	public int GetUnitSize(Container con) {
		return (int)(con.depth / size.Z);	
	}
}
