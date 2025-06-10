using Godot;
using System.Collections.Generic;

public partial class Container : Node3D {
	[Export] public string name;
	[Export] public Texture2D icon;
	[Export] public int price;
	[Export] public int size;
	
	public int stock = 0;
	public float depth;
	public List<Product> products = new();

	[Export] public Node3D shelfStart; 
	[Export] public Node3D shelfEnd; 

	public override void _Ready() {	
		depth = Mathf.Abs(shelfStart.GlobalPosition.Z - shelfEnd.GlobalPosition.Z);
	}

	private void OnClick() {
		stock++;
		GD.Print("increased my stock. Currently at: " + stock);
		// TEST
		var prod = ItemDB.self.products[0].Instantiate<Product>();
		GetTree().Root.AddChild(prod);
		GD.Print(prod.GetUnitSize(this));
	}

    public override void _Process(double delta)
    {
		if (PlayerMovement.aimingAt == this && Input.IsActionJustReleased("left_click")){
				OnClick();
		}
    }
}
