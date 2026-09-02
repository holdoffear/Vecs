# Vecs

[![Documentation](https://img.shields.io/badge/NET-10.0-blue)]()

![showcase](docs/img/Showcase.gif)

Vecs is an Entity Component System written in C# that aims to be performant.
- Makes use of Archetypes to handle grouping of entities that share the same set of components.
- Uses a Query to access entity component data as a packed array.
- Component data is stored contiguously in memory making it cache friendly.
- Components are of type struct.

# Example
```c#
using Vecs;

World world = new World(10);
Entity entity = world.CreateEntity(new Velocity(){Value = 0});
Query query = world.CreateQuery();
query.Get<Velocity>();
query.Foreach<Velocity>((ref Velocity velocity) =>
{
    velocity.Value = 1;
});

struct Velocity
{
    public float Value;
}
```
# Entity

An Entity is a unique identifier of type struct that is used to manage a set of components assigned to that Entity.

Creating and removing an entity can be done as follows with variable component types:

### Create
```c#
Entity entity = world.CreateEntity();
```
```c#
Entity entity = world.CreateEntity<int>();
```
```c#
Entity entity = world.CreateEntity<Name, Position, Velocity>();
```
Supporting up to 32 components. <T1, T2, ..., T32>

### Remove

```c#
world.RemoveEntity(entity);
```

# Component

A component is any `struct`.
```c#
struct Health
{
    public int Value;
}
struct Mana(int Value)
```
Adding and removing Components to Entities can be done as follows:
### Add
```c#
world.AddComponent(entity, new Stamina(100));
```
### Remove
```c#
world.RemoveComponent<Animation>(entity);
```

# Query

Requesting entity components can be done through a query:
```c#
Query query = world.CreateQuery();

query.Get<Health, Mana>()
     .With<Stamina>()
     .Exclude<Dead>();

query.Foreach((ref Health health, ref Mana mana) =>
{
    health.Value += mana.Value;
    mana.Value = 0;
});
```
### Get<>()

The query iterates over the SELECTED type components.

### With<>()
The query fetches all matching Archetypes that CONTAIN ALL matching types.

### Exclude<>()
The query fetches all matching Archetypes that DO NOT CONTAIN ANY of the matching types;