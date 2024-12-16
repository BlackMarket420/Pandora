using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace Pandora
{
    public class CompProperties_EquippedWeaponAbilities : CompProperties
    {
        public CompProperties_EquippedWeaponAbilities()
        {
            this.compClass = typeof(Comp_EquippedWeaponAbilities);
        }
        public List<AbilityDef> Abilities;
    }
}
