using System;
using Verse;

namespace Pandora
{
    public class HediffCompProperties_Regeneration : HediffCompProperties
    {
        public HediffCompProperties_Regeneration()
        {
            this.compClass = typeof(HediffComp_Regeneration);
        }

        public float Factor = 1f;
    }
}
