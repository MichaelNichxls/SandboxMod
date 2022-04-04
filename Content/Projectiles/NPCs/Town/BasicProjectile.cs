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
            projectile.velocity.Y       += projectile.ai[0];
            projectile.spriteDirection  = projectile.direction = (projectile.velocity.X > 0).ToDirectionInt();
            projectile.rotation         = projectile.velocity.ToRotation() + (projectile.spriteDirection == 1 ? 0f : MathHelper.Pi);

            //if (Main.rand.NextBool(6))
            //    Dust.NewDust(
            //        projectile.position + projectile.velocity,
            //        projectile.width,
            //        projectile.height,
            //        ModContent.DustType<BasicDust>(),
            //        projectile.velocity.X * 0.5f,
            //        projectile.velocity.Y * 0.5f);
        }

        // Pre or Post
        public override void PostAI()
        {
            for (int i = projectile.oldPos.Length - 1; i > 0; i--)
            {
                projectile.oldPos[i]                = projectile.oldPos[i - 1];
                projectile.oldRot[i]                = projectile.oldRot[i - 1];
                projectile.oldSpriteDirection[i]    = projectile.oldSpriteDirection[i - 1];
            }

            projectile.oldPos[0]                = projectile.position;
            projectile.oldRot[0]                = projectile.rotation;
            projectile.oldSpriteDirection[0]    = projectile.spriteDirection;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            DrawAfterimage(spriteBatch, Vector2.Zero, 0.5f, 0.1f, 1f, 0.5f);
            return true;
        }

        //Main.projectileTexture[projectile.type].Width

        // DrawAfterimages()?
        // Make into helper method, if that's even possible

        // Add overload that takes in lightColor, or just Color
        public void DrawAfterimage(SpriteBatch spriteBatch, Vector2 offset, float startOpacity, float endOpacity, float startScale, float endScale)
        {
            for (int afterimageCount = projectile.oldPos.Length, i = afterimageCount - 1; i >= 0; i--)
                spriteBatch.Draw(
                    ModContent.GetTexture($"{Texture}_Afterimage"),
                    projectile.oldPos[i] - Main.screenPosition + (projectile.Size / 2f) + new Vector2(0, projectile.gfxOffY) + offset,
                    new Rectangle(0, 0, projectile.width, projectile.height),
                    Lighting.GetColor((int)(projectile.oldPos[i].X + (projectile.width / 2f)) / 16, (int)(projectile.oldPos[i].Y + (projectile.height / 2f)) / 16)
                        * MathHelper.Lerp(startOpacity, endOpacity, i / (float)(afterimageCount - 1)),
                    projectile.oldRot[i],
                    projectile.Size / 2f,
                    MathHelper.Lerp(startScale, endScale, i / (float)(afterimageCount - 1)),
                    projectile.oldSpriteDirection[i] == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally,
                    0f);
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