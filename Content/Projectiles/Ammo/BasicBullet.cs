using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Projectiles.Ammo
{
    public class BasicBullet : ModProjectile
    {
        public override string Texture => AssetDirectory.AmmoTextures_Projectile + Name;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            projectile.ranged       = true;
            projectile.friendly     = true;
            projectile.penetrate    = 3;
            projectile.timeLeft     = 600;
            projectile.width        = 8;
            projectile.height       = 8;
            projectile.alpha        = byte.MaxValue;
            projectile.light        = 0.5f;
            projectile.extraUpdates = 1;
            projectile.aiStyle      = 1;

            aiType = ProjectileID.Bullet;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) =>
            target.immune[projectile.owner] = 6;

        public override void Kill(int timeLeft) =>
            Main.PlaySound(SoundID.Item10, projectile.position);
    }
}