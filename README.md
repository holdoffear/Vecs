# Vecs

[![Documentation](https://img.shields.io/badge/NET-10.0-blue)]()

![showcase](docs/img/Showcase.gif)

Vecs is an Entity Component System written in C# that aims to be performant.
- Makes use of Archetypes to handle grouping of entities that share the same set of components.
- Uses Queries to perform operations on entity components.
- Component data is stored contiguously in memory making it cache friendly.
- Components are of type struct.

# Example
```c#
using Vecs;

World world = new World();
Entity entity = world.CreateEntity(new Health(){Value = 100}, new Damage(5));
Query query = world.CreateQuery();
query.Foreach((ref Health health, ref Damage damage) =>
{
    health.Value -= damage.Value;
});

struct Health
{
    public float Value;
}
record struct Damage(float Value);
```
# Entity

An Entity is a unique identifier of type struct that is used to manage a set of components assigned to that Entity.

Creating and removing an entity can be done as follows with varying component types:

### Create
```c#
Entity entity = world.CreateEntity<int>(4);
```
```c#
Entity entity = world.CreateEntity<Name, Position, Velocity>();
```
`An entity must have at least one component.`

Supports up to 32 components. <T1, T2, ..., T32>

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
record struct Mana(int Value);
```
Adding Components to Entities and removing Components from Entities can be done as follows:
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

query.With<Stamina>(),
    .With<Health, Mana>(),
    .Exclude<Dead>();

query.Foreach((ref Health health, ref Mana mana) =>
{
    health.Value += mana.Value;
    mana.Value = 0;
});
```
`Up to 8 components can be iterated at once.`
### Foreach

The query iterates over the component types given as parameters.

### With<>()
The query fetches all matching Archetypes that CONTAIN ALL matching component types.

### Exclude<>()
The query fetches all matching Archetypes that DO NOT CONTAIN ANY of the matching component types;