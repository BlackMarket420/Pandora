using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace Pandora
{
    public class HediffComp_HediffOnKill : HediffComp
    {
        public HediffCompProperties_HediffOnKill Props
        {
            get
            {
                return (HediffCompProperties_HediffOnKill)this.props;
            }
        }
        public override void Notify_KilledPawn(Pawn victim, DamageInfo? dInfo)
        {
            Pawn.health.AddHediff(this.Props.hediff, null, null, null);
        }
    }
}
