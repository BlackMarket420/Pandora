using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace Pandora
{
    public class MechImmunity : HediffComp
    {
        public HediffCompProperties_MechImmunity Props
        {
            get
            {
                return (HediffCompProperties_MechImmunity)this.props;
            }
        }

        public override void CompPostTick(ref float severityAdjustment)
        {
            bool flag = !this.Props.isInfectiousToMechanoid && base.Pawn.RaceProps.IsMechanoid;
            bool flag2 = flag;
            if (flag2)
            {
                base.Pawn.health.RemoveHediff(this.parent);
            }
        }
    }
}
