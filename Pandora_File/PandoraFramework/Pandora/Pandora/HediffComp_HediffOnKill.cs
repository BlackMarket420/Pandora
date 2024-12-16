using Verse;

namespace Pandora
{
	public class HediffComp_HediffOnKill : HediffComp
    {
        public HediffCompProperties_HediffOnKill Props => (HediffCompProperties_HediffOnKill)props;


		public override void Notify_KilledPawn(Pawn victim, DamageInfo? dInfo)
        {
            Pawn.health.AddHediff(Props.hediffDef, null, null, null);
			Props.effecterDef?.Spawn(Pawn, Pawn.Map);
        }
    }
}
