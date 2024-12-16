using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace Pandora
{
    public class HediffCompProperties_MechImmunity : HediffCompProperties
    {
        public HediffCompProperties_MechImmunity()
        {
            this.compClass = typeof(MechImmunity);
        }

        public bool isInfectiousToMechanoid = false;
    }
}
