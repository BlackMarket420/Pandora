using RimWorld;

namespace Pandora
{
    public class Projectile_AccuracyBullet : Bullet
    {
        public override void Tick()
        {
            bool flag = this.intendedTarget.Thing != null;
            if (flag)
            {
                this.destination = this.intendedTarget.Thing.DrawPos;
            }
            base.Tick();
        }
    }
}
