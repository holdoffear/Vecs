//using System;
//using System.Diagnostics;
//using Godot;
//using Vecs;
//
//
//public partial class SecondSystem : Node3D
//{
	//World world = new World();
	//Query query;
	//int instances = 5000;
	//Rid MeshRid;
	//Mesh Mesh;
	//public override void _Ready()
	//{
		//Mesh = new BoxMesh();
		//MeshRid = Mesh.GetRid();
		//query = new Query(world);
//
		//Stopwatch stopwatch = new Stopwatch();
		//stopwatch.Start();
		//for (int i = 0; i < instances; i++)
		//{
			//Transform3D transform3D = new Transform3D(Basis.Identity, Vector3.Zero);
			//MeshInstance3D meshInstance3D = new MeshInstance3D();
			//meshInstance3D.Mesh = Mesh;
			//// AddChild(meshInstance3D);
			//// Rid rid = meshInstance3D.GetInstance();
			//Rid rid = meshInstance3D.GetInstance();
//
			//Entity entity = world.CreateEntity();
			//query.AddComponent(ref entity, transform3D);
			//query.AddComponent(ref entity, rid);
//
			//RenderingServer.InstanceSetScenario(rid, GetWorld3D().Scenario);
			//// RenderingServer.InstanceSetBase(rid, MeshRid);
			//RenderingServer.InstanceSetTransform(rid, transform3D);
		//}
		//stopwatch.Stop();
		//GD.Print(stopwatch.ElapsedMilliseconds);
		//stopwatch.Reset();
//
		//query.With(new Type[]{typeof(Rid), typeof(Transform3D)});
	//}
	//public override void _PhysicsProcess(double delta)
	//{
		//Stopwatch stopwatch = new Stopwatch();
		//stopwatch.Start();
//
		//// query.Foreach((ref Rid rid, ref Transform3D transform3D) => 
		//// {
		//// 	transform3D = transform3D.Translated(GD.RandRange(-1, 1) * new Godot.Vector3(GD.Randf(), GD.Randf(), GD.Randf()));
		//// 	RenderingServer.InstanceSetTransform(rid, transform3D);
		//// });
		//// for (int i = 0; i < 1000; i++)
		//// {
		//// 	Entity entity = world.CreateEntity();
		//// 	query.AddComponent(ref entity, 4);
		//// }
		//stopwatch.Stop();
		//GD.Print(stopwatch.ElapsedMilliseconds);
		//stopwatch.Reset();
	//}
	//// public override void _Process(double delta)
	//// {
	//// 	for (int i = 0; i < 1000; i++)
	//// 	{
	//// 		Entity entity = world.CreateEntity();
	//// 		query.AddComponent(ref entity, 4);
	//// 	}
	//// }
//}
