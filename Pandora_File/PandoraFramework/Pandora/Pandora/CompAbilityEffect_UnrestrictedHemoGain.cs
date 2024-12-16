using RimWorld;
using System;
using Verse;

namespace Pandora
{
    public class CompAbilityEffect_UnrestrictedHemoGain : CompAbilityEffect
    {
        public new CompProperties_UnrestrictedHemoGain Props
        {
            get
            {
                return (CompProperties_UnrestrictedHemoGain)this.props;
            }
        }

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            base.Apply(target, dest);
            Pawn pawn = target.Pawn;
            if (pawn == null)
            {
                return;
            }
            SanguophageUtility.DoBite(this.parent.pawn, pawn, this.Props.hemogenGain, this.Props.nutritionGain, this.Props.targetBloodLoss, this.Props.resistanceGain, this.Props.bloodFilthToSpawnRange, this.Props.thoughtDefToGiveTarget, this.Props.opinionThoughtDefToGiveTarget);
        }

        public override bool CanApplyOn(LocalTargetInfo target, LocalTargetInfo dest)
        {
            return this.Valid(target, false);
        }

        public override bool Valid(LocalTargetInfo target, bool throwMessages = false)
        {
            Pawn pawn = target.Pawn;
            if (pawn == null)
            {
                return false;
            }
            if (!AbilityUtility.ValidateMustBeHumanOrWildMan(pawn, throwMessages, this.parent))
            {
                return false;
            }          
            return true;
        }

        public override string ExtraLabelMouseAttachment(LocalTargetInfo target)
        {
            Pawn pawn = target.Pawn;
            if (pawn != null)
            {
                string text = null;               
                float num = this.BloodlossAfterBite(pawn);
                if (num >= HediffDefOf.BloodLoss.lethalSeverity)
                {
                    if (!text.NullOrEmpty())
                    {
                        text += "\n";
                    }
                    text += "WillKill".Translate();
                }
                else if (HediffDefOf.BloodLoss.stages[HediffDefOf.BloodLoss.StageAtSeverity(num)].lifeThreatening)
                {
                    if (!text.NullOrEmpty())
                    {
                        text += "\n";
                    }
                    text += "WillCauseSeriousBloodloss".Translate();
                }
                return text;
            }
            return base.ExtraLabelMouseAttachment(target);
        }

        public override Window ConfirmationDialog(LocalTargetInfo target, Action confirmAction)
        {
            Pawn pawn = target.Pawn;
            if (pawn != null)
            {
                if (pawn.genes != null && pawn.genes.HasGene(GeneDefOf.Deathless))
                {
                    return null;
                }              
            }
            return null;
        }

        private float BloodlossAfterBite(Pawn target)
        {
            if (target.Dead || !target.RaceProps.IsFlesh)
            {
                return 0f;
            }
            float num = this.Props.targetBloodLoss;
            Hediff firstHediffOfDef = target.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.BloodLoss, false);
            if (firstHediffOfDef != null)
            {
                num += firstHediffOfDef.Severity;
            }
            return num;
        }
    }
}
