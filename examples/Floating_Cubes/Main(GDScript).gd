extends Node3D

var ballCount = 10000;
var instance = [];
var mesh = [];
var transform3D = [];
var meshInstance;

func _ready():
	for i in range(ballCount):
		transform3D.push_back(Transform3D(Basis.IDENTITY, Vector3.ZERO));
		meshInstance = SphereMesh.new();
		instance.push_back(RenderingServer.instance_create());
		mesh.push_back(meshInstance);
		
		RenderingServer.instance_set_scenario(instance[i], get_world_3d().scenario);
		RenderingServer.instance_set_base(instance[i], mesh[i]);
		RenderingServer.instance_set_transform(instance[i], transform3D[i]);

func _physics_process(delta):
	for i in ballCount:
		transform3D[i] = transform3D[i].translated(randi_range(-1, 1)*Vector3(randf(), randf(), randf()));
		RenderingServer.instance_set_transform(instance[i], transform3D[i]);
