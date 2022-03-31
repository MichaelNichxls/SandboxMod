using Microsoft.Xna.Framework;
using SandboxMod.Common;
using SandboxMod.Content.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Projectiles.NPCs.Town
{
    public class BasicProjectile : ModProjectile
    {
        public override string Texture => Assets.GetTexture<BasicProjectile>();

        public override void SetDefaults()
        {
            projectile.magic        = true;
            projectile.friendly     = true;
            projectile.penetrate    = 3;
            projectile.timeLeft     = 600;
            projectile.Size         = new Vector2(16, 16);
            projectile.light        = 0.5f;
        }

        public override void AI()
        {
            projectile.velocity.Y += projectile.ai[0];

            if (Main.rand.NextBool(3))
                Dust.NewDust(
                    projectile.position + projectile.velocity,
                    projectile.width,
                    projectile.height,
                    ModContent.DustType<BasicDust>(),
                    projectile.velocity.X * 0.5f,
                    projectile.velocity.Y * 0.5f);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (--projectile.penetrate <= 0)
                projectile.Kill();
            else
            {
                projectile.ai[0] += 0.1f;

                if (projectile.velocity.X != oldVelocity.X)
                    projectile.velocity.X = -oldVelocity.X;

                if (projectile.velocity.Y != oldVelocity.Y)
                    projectile.velocity.Y = -oldVelocity.Y;

                projectile.velocity *= 0.75f;
                Main.PlaySound(SoundID.Item10, projectile.position);
            }

            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.ai[0]    += 0.1f;
            projectile.velocity *= 0.75f;
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
                Dust.NewDust(
                    projectile.position + projectile.velocity,
                    projectile.width,
                    projectile.height,
                    ModContent.DustType<BasicDust>(),
                    projectile.oldVelocity.X * 0.5f,
                    projectile.oldVelocity.Y * 0.5f);

            Main.PlaySound(SoundID.Item25, projectile.position);
        }
    }
}