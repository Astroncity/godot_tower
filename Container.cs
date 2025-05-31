using Godot;
using System.Collections.Generic;

public partial class Container : Node3D {
	[Export] public string name;
	[Export] public Texture2D icon;
	[Export] public int price;
	[Export] public int size;
	
	public int stock = 0;
	public List<Product> products = new();


	public override void _Ready() {

	}

	private void OnClick() {
		stock++;
		GD.Print("increased my stock. Currently at: " + stock);
	}

    public override void _Process(double delta)
    {
		if (PlayerMovement.aimingAt == this && Input.IsMouseButtonPressed(MouseButton.Left)){
				OnClick();
		}
    }
}
