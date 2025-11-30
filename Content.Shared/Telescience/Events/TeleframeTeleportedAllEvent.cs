using Robust.Shared.Map;

namespace Content.Shared.Telescience.Events;

///<summary>
///Event raised on the teleframe just after teleporting every possible entity
/// </summary>
[ByRefEvent]
public readonly record struct TeleframeTeleportedAllEvent(List<EntityUid> Teleported, MapCoordinates To, MapCoordinates From);
