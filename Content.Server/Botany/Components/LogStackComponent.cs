using Content.Server.Botany.Systems;
using Robust.Shared.Prototypes;
using Content.Shared.Stacks;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;

namespace Content.Server.Botany.Components;
// TODO: This should probably be merged with SliceableFood somehow or made into a more generic Choppable.
// Yeah this is pretty trash. also consolidating this type of behavior will avoid future transform parenting bugs (see #6090).

[RegisterComponent]
[Access(typeof(LogStackSystem))]
public sealed partial class LogStackComponent : Component
{
    /// <summary>
    ///     Spawned stacking entity
    /// </summary>
    [DataField("spawnedPrototype", customTypeSerializer: typeof(PrototypeIdSerializer<StackPrototype>))]
    public string SpawnedPrototype = "Credit";

    /// <summary>
    ///     How much is spawned, overridden if usePotency is true.
    ///     if usePotency is true, but fails for some reason, it will default back to this value.
    /// </summary>
    [DataField("spawnCount")] public float SpawnCount = 10f;

    /// <summary>
    ///     How much to divide potency value by, does nothing if usePotency is false. Division rounds up to nearest integer.
    /// </summary>
    [DataField("potencyDivisor")] public float PotencyDivisor = 1f;
    /// <summary>
    ///     replaces spawnCount value with whatever a plant's potency is. Only works for plants, obviously.
    ///     note that spawned in plants will be spawnCount/PotencyDivisor, has to be naturally grown to draw directly from potency.
    /// </summary>
    [DataField("usePotency")] public bool UsePotency = false;
}
