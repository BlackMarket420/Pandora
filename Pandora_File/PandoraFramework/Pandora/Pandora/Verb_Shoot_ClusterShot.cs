using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace Pandora
{
    public class Verb_Shoot_ClusterShot : Verb_Shoot
    {
        protected override bool TryCastShot()
        {
            bool flag = base.TryCastShot();
            Verb_Properties_ClusterShot verb_Properties_ShotGun = (Verb_Properties_ClusterShot)this.verbProps;
            bool flag2 = flag && verb_Properties_ShotGun.pellets - 1 > 0;
            if (flag2)
            {
                for (int i = 1; i < verb_Properties_ShotGun.pellets; i++)
                {
                    base.TryCastShot();
                }
            }
            return flag;
        }
    }
}
