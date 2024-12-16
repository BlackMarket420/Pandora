using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Pandora
{
    public class CompProperties_UnrestrictedHemoGain : CompProperties_AbilityEffect
    {
        public CompProperties_UnrestrictedHemoGain()
        {
            this.compClass = typeof(CompAbilityEffect_UnrestrictedHemoGain);
        }

        public override IEnumerable<string> ExtraStatSummary()
        {
            yield return "AbilityHemogenGain".Translate() + ": " + (this.hemogenGain * 100f).ToString("F0");
            yield break;
        }

        public float hemogenGain;

        public ThoughtDef thoughtDefToGiveTarget;

        public ThoughtDef opinionThoughtDefToGiveTarget;

        public float resistanceGain;

        public float nutritionGain = 0.1f;

        public float targetBloodLoss = 0.4499f;

        public IntRange bloodFilthToSpawnRange;
    }
}
