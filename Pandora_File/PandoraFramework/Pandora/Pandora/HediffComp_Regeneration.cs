using RimWorld;
using System;
using System.Linq;
using UnityEngine;
using Verse;

namespace Pandora

{
    public class HediffComp_Regeneration : HediffComp
    {
        public HediffCompProperties_Regeneration Props
        {
            get
            {
                return (HediffCompProperties_Regeneration)this.props;
            }
        }

        public override void CompPostMake()
        {
            base.CompPostMake();
            this.ResetTicksToHeal();
        }

        private void ResetTicksToHeal()
        {
            this.ticksToHeal = (int)(Props.Factor * 20);
        }

        public override void CompPostTick(ref float severityAdjustment)
        {
            this.ticksToHeal--;
            bool flag = this.ticksToHeal <= 0;
            bool flag2 = flag;
            if (flag2)
            {
                HediffComp_Regeneration.TryHealRandomPermanentWound(base.Pawn, this.parent.LabelCap);
                this.ResetTicksToHeal();
            }
        }

        public static void TryHealRandomPermanentWound(Pawn pawn, string cause)
        {
            Hediff hediff;
            bool flag = !(from hd in pawn.health.hediffSet.hediffs
                          where hd.IsPermanent() || hd.def.chronic || hd.def.displayWound
                          select hd).TryRandomElement(out hediff);
            bool flag2 = !flag;
            if (flag2)
            {
                HealthUtility.Cure(hediff);
                bool flag3 = PawnUtility.ShouldSendNotificationAbout(pawn);
            }
        }

        public override void CompExposeData()
        {
            Scribe_Values.Look<int>(ref this.ticksToHeal, "ticksToHeal", 0, false);
        }

        public override string CompDebugString()
        {
            return "ticksToHeal: " + this.ticksToHeal.ToString();
        }

        private int ticksToHeal;
    }
}
