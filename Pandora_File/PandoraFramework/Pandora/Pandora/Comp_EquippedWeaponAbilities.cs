using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace Pandora
{
    public class Comp_EquippedWeaponAbilities : ThingComp
    {
        private CompProperties_EquippedWeaponAbilities Props
        {
            get
            {
                return (CompProperties_EquippedWeaponAbilities)this.props;
            }
        }
        public override void PostSpawnSetup(bool respawningAfterLoad)
        {
            base.PostSpawnSetup(respawningAfterLoad);
            this.ProvideAbility();
        }
        public override void CompTick()
        {
            base.CompTick();
            this.ProvideAbility();
        }
        public override void Notify_Equipped(Pawn pawn)
        {
            base.Notify_Equipped(pawn);
            wearer = pawn;
            this.ProvideAbility();
        }

        public void ProvideAbility()
        {
            ThingWithComps parent = this.parent;
            bool flag = parent != null;
            if (flag)
            {
                Pawn_EquipmentTracker pawn_EquipmentTracker = parent.ParentHolder as Pawn_EquipmentTracker;
                bool flag2 = pawn_EquipmentTracker == null || pawn_EquipmentTracker.pawn != this.wearer;
                if (flag2)
                {
                    bool flag3 = this.wearer != null;
                    if (flag3)
                    {
                        for (int i = 0; i < this.Props.Abilities.Count; i++)
                        {
                            this.wearer.abilities.RemoveAbility(this.Props.Abilities[i]);
                        }
                        this.wearerAbility.Clear();
                        this.wearer = null;
                    }
                }
                IThingHolder parentholder = parent.ParentHolder;
                Pawn_EquipmentTracker tracker2 = parentholder as Pawn_EquipmentTracker;
                bool flag5;
                if (tracker2 != null && tracker2.pawn != null)
                {
                    if (tracker2.pawn == this.wearer)
                    {
                        List<Ability> list = (List<Ability>)this.wearerAbility;
                        bool? flag4 = (list != null) ? new bool?(list.Any((Ability x) => ((x != null) ? x.pawn : null) == tracker2.pawn)) : null;
                        flag5 = (flag4 != null && !flag4.GetValueOrDefault());
                    }
                    else
                    {
                        flag5 = true;
                    }
                }
                else
                {
                    flag5 = false;
                }
                bool flag6 = flag5;
                if (flag6)
                {
                    this.wearerAbility = new List<Ability>();
                    for (int i = 0; 1 < this.Props.Abilities.Count; i++)
                    {
                        this.wearer.abilities.GainAbility(this.Props.Abilities[i]);
                    }
                    this.wearer = tracker2.pawn;
                }
            }           
        }

        public Pawn wearer = null;

        public List<Ability> wearerAbility = new List<Ability>();
    }
}
