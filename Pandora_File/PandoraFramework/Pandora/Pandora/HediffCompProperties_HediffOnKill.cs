﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace Pandora
{
    public class HediffCompProperties_HediffOnKill : HediffCompProperties
    {

        public HediffCompProperties_HediffOnKill()
        {
            this.compClass = typeof(HediffComp_HediffOnKill);
        }

        public HediffDef hediff;
    }
}