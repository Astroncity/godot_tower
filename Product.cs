using Godot;

public partial class Product : Node3D {
	[Export] public string name;
	[Export] public Texture2D icon;
	[Export] public int buyPrice;
	[Export] public int sellPrice;
}
