using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        // Add TrailCacheLength?

        public override void SetDefaults()
        {
            projectile.magic        = true;
            projectile.friendly     = true;
            projectile.penetrate    = 3;
            projectile.timeLeft     = 600;
            projectile.Size         = new Vector2(16, 16);
            projectile.light        = 0.5f;
        }

        // Add rotation?
        public override void AI()
        {
            projectile.velocity.Y += projectile.ai[0];

            if (Main.rand.NextBool(6))
                Dust.NewDust(
                    projectile.position + projectile.velocity,
                    projectile.width,
                    projectile.height,
                    ModContent.DustType<BasicDust>(),
                    projectile.velocity.X * 0.5f,
                    projectile.velocity.Y * 0.5f);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            DrawAfterimage(spriteBatch, Vector2.Zero, 0.75f, Color.White, Color.White * 0.1f, 1f, 0.5f);
            return false;
        }

        //public void DrawAfterimage(SpriteBatch spriteBatch, Vector2 offset, float trailLengthModifier, Color color, float opacity, float startScale, float endScale) =>
        //    DrawAfterImage(spriteBatch, offset, trailLengthModifier, color, color, opacity, startScale, endScale);

        // Make into helper method
        // Draw afterimages behind each one another instead of in front
        public void DrawAfterimage(SpriteBatch spriteBatch, Vector2 offset, float trailLength, Color startColor, Color endColor, float startScale, float endScale)
        {
            // Make afterimageCount into param
            for (int i = 0, afterimageCount = 5; i < afterimageCount; i++)
            {
                // projectile.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None // check
                // Main.projectileTexture[projectile.type] ??

                // Use newer methods for math
                spriteBatch.Draw(
                    ModContent.GetTexture(Texture),
                    new Vector2(projectile.Center.X, projectile.Center.Y) + offset - Main.screenPosition + new Vector2(0, projectile.gfxOffY) - projectile.velocity * i * trailLength,
                    new Rectangle(0, 0, projectile.width, projectile.height),
                    Color.Lerp(startColor, endColor, i / (float)afterimageCount),
                    projectile.rotation,
                    projectile.Size / 2f,
                    MathHelper.Lerp(startScale, endScale, i / (float)afterimageCount),
                    SpriteEffects.None,
                    0f);
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (--projectile.penetrate <= 0)
            {
                projectile.Kill();
                return false;
            }

            projectile.ai[0] += 0.1f;

            if (projectile.velocity.X != oldVelocity.X)
                projectile.velocity.X = -oldVelocity.X;

            if (projectile.velocity.Y != oldVelocity.Y)
                projectile.velocity.Y = -oldVelocity.Y;

            projectile.velocity *= 0.75f;

            Main.PlaySound(SoundID.Item10, projectile.position);
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