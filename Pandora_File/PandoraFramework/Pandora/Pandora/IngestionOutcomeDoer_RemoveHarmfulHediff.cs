using RimWorld;
using Verse;

namespace Pandora
{
    public class IngestionOutcomeDoer_RemoveHarmfulHediff : IngestionOutcomeDoer
    {
        protected override void DoIngestionOutcomeSpecial(Pawn pawn, Thing ingested, int ingestedCount)
        {
            Hediff firstHediffOfDef = pawn.health.hediffSet.GetFirstHediffOfDef(this.hediffDef, false);
            bool flag = firstHediffOfDef != null;
            bool flag2 = flag;
            if (flag2)
            {
                pawn.health.RemoveHediff(firstHediffOfDef);
            }
        }

        public HediffDef hediffDef;
    }
}
