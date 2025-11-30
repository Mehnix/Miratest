using Content.Shared.Telescience.Components;
using Content.Shared.Telescience.Events;
using Robust.Shared.Random;

namespace Content.Shared.Telescience.Systems;

public abstract partial class SharedBluespaceDistortionSystem : EntitySystem
{
    [Dependency] protected readonly IRobustRandom Random = default!;
    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<BluespaceDistortionComponent, ComponentStartup>(OnStartup);
        SubscribeLocalEvent<BluespaceDistortionComponent, TelechargeScanEvent>(OnScanned);
    }

    private void OnStartup(Entity<BluespaceDistortionComponent> ent, ref ComponentStartup args)
    {
        ent.Comp.MaxHealth = Random.Next(ent.Comp.MinHealthRoll, ent.Comp.MaxHealthRoll);
        ent.Comp.Health = ent.Comp.MaxHealth;
        Dirty(ent);
    }

    private void OnScanned(Entity<BluespaceDistortionComponent> ent, ref TelechargeScanEvent args)
    {
        Log.Debug("Scanned");
        var damage = DoScanDamage(ent, args.Distance);
        if (HasComp<TelechargeComponent>(args.Telecharge))
        {
            var status = (float)(ent.Comp.Health / ent.Comp.MaxHealth);
            var scienceEv = new TelechargeAddScienceEvent(damage, status);
            RaiseLocalEvent(args.Telecharge, ref scienceEv); //send a science event back to the telecharge
        }
    }
    private int DoScanDamage(Entity<BluespaceDistortionComponent> ent, float distance)
    {
        var damage = (int)(ent.Comp.MaxHealth * ent.Comp.Gradiant / (ent.Comp.Gradiant + distance));
        ent.Comp.Health -= damage;
        Dirty(ent);
        return damage;
    }
}

