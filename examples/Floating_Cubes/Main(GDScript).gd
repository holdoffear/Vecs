extends Node3D

var ballCount = 10000;
var instance = [];
var mesh = SphereMesh.new();
var transform3D = [];

func _ready():
	for i in range(ballCount):
		var meshInstance3D = MeshInstance3D.new();
		meshInstance3D.mesh = mesh;
#		add_child(meshInstance3D);
		transform3D.push_back(Transform3D(Basis.IDENTITY, Vector3.ZERO));
		instance.push_back(meshInstance3D.get_instance());
		
		RenderingServer.instance_set_scenario(instance[i], get_world_3d().scenario);
#		RenderingServer.instance_set_base(instance[i], mesh);
		RenderingServer.instance_set_transform(instance[i], transform3D[i]);

func _physics_process(delta):
	for i in ballCount:
		transform3D[i].origin = Vector3(randi_range(-10, 10), randi_range(-10, 10), randi_range(-10, 10))
		RenderingServer.instance_set_transform(instance[i], transform3D[i]);
