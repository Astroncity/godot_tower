using Godot;

public partial class PlayerMovement : CharacterBody3D {
    [Export] public float speed = 8.0f;
    [Export] public float jump_vel = 4.5f;
    const float g = 9.8f;
    Vector3 vel = Vector3.Zero;

	[Export] public Camera3D cam;
    [Export] public float sens = 0.002f;

    float pitch = 0f;
	[Export] public Node3D pivot;

	public static Node3D aimingAt;
	[Export] public int lookDistance;


	public override void _Ready() {
        Input.MouseMode = Input.MouseModeEnum.Captured;
	}
	
	public override void _PhysicsProcess(double delta) {
        Move((float)delta);
		GetAiming();
    }

	private void GetAiming() {
		var state = GetWorld3D().DirectSpaceState;
		var origin = cam.GlobalPosition - GlobalTransform.Basis.Z * 2;
		var end = origin - GlobalTransform.Basis.Z * lookDistance;

		var q = PhysicsRayQueryParameters3D.Create(origin, end);
		q.CollideWithAreas = true;
		var res = state.IntersectRay(q);
		if (res.Count == 0) {aimingAt = null; return;}

		var col = (RigidBody3D)res["collider"];
		aimingAt = col.GetParentNode3D();
		
	}
	
    public override void _Input(InputEvent @event) {
        if (@event is InputEventMouseMotion motion) {
            RotateY(-motion.Relative.X * sens);

            pitch += -motion.Relative.Y * sens;
            pitch = Mathf.Clamp(pitch, -Mathf.Pi / 2, Mathf.Pi / 2);
            pivot.Rotation = new Vector3(pitch, 0, 0);
        }
    }

	private void Move(float dt) {
		Vector3 in_dir = Vector3.Zero;

        if (Input.IsActionPressed("move_forward"))
            in_dir -= Transform.Basis.Z;
        if (Input.IsActionPressed("move_backward"))
            in_dir += Transform.Basis.Z;
        if (Input.IsActionPressed("move_left"))
            in_dir -= Transform.Basis.X;
        if (Input.IsActionPressed("move_right"))
            in_dir += Transform.Basis.X;

		
		in_dir = in_dir.Normalized();

        var hvel = in_dir * speed;
        vel.X = hvel.X;
        vel.Z = hvel.Z;

        if (!IsOnFloor())
            vel.Y -= g * dt;
        else
            vel.Y = 0.0f;

        if (IsOnFloor() && Input.IsActionJustPressed("jump"))
            vel.Y = jump_vel;

        Velocity = vel;
        MoveAndSlide();
	}

    
}
