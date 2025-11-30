using Content.Shared.Radio;
using Content.Shared.Whitelist;
using Robust.Shared.Prototypes;
using Robust.Shared.GameStates;

namespace Content.Shared.Telescience.Components;

/// <summary>
/// finds <see cref="BluespaceDistortionComponent"=> in range
/// if in scanning range, take some of distortion's stored science
/// if suffering an incident, tell distortion and it flickers
/// </summary>
[RegisterComponent, NetworkedComponent, AutoGenerateComponentState(true)]
public sealed partial class TelechargeComponent : Component
{
    /// <summary>
    /// What to look for on teleporting
    /// </summary>
    [DataField]
    public EntityWhitelist? Whitelist;

    /// <summary>
    /// What to ignore on teleporting. Takes priority over Whitelist.
    /// </summary>
    [DataField]
    public EntityWhitelist? Blacklist;

    /// <summary>
    /// Detection range (radius)
    /// </summary>
    [DataField]
    public int Range = 25;

    /// <summary>
    /// Sends a special event to detected targets if the entity this component is attached to suffers a teleport incident
    /// </summary>
    [DataField]
    public bool InformOnIncident = true;
    /// <summary>
    /// Radio channel to announce discovery on
    /// </summary>
    [DataField]
    public ProtoId<RadioChannelPrototype>? AnnouncementChannel;

    /// <summary>
    /// Amount of stored science
    /// </summary>
    [ViewVariables, AutoNetworkedField]
    public int Science = 0;

    /// <summary>
    /// Max range at which the telecharge gains science from a distortion
    /// </summary>
    [DataField]
    public int ScanRange = 5;

}
