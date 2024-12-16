using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace Pandora
{
    internal class WeaponHediff : CompCauseHediff_Apparel
    {
        public CompProperties_WeaponHediff Props
        {
            get
            {
                return (CompProperties_WeaponHediff)this.props;
            }
        }

        public override void Notify_Equipped(Pawn pawn)
        {
            pawn.health.AddHediff(this.Props.hediff, null, null, null);
        }

        public override void Notify_Unequipped(Pawn pawn)
        {
            if (pawn.health.hediffSet.GetFirstHediffOfDef(this.Props.hediff, false) != null)
            {
                pawn.health.RemoveHediff(pawn.health.hediffSet.GetFirstHediffOfDef(this.Props.hediff, false));
            }
        }
    }
}
