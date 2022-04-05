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

            if (Main.rand.NextBool(6))
                Dust.NewDust(
                    projectile.position + projectile.velocity,
                    projectile.width,
                    projectile.height,
                    ModContent.DustType<BasicDust>(),
                    projectile.velocity.X * 0.5f,
                    projectile.velocity.Y * 0.5f);
        }

        public override void PostAI()
        {
            for (int k = projectile.oldPos.Length - 1; k > 0; k--)
            {
                projectile.oldPos[k]                = projectile.oldPos[k - 1];
                projectile.oldRot[k]                = projectile.oldRot[k - 1];
                projectile.oldSpriteDirection[k]    = projectile.oldSpriteDirection[k - 1];
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
            // Move some things into variables
            for (int afterimageCount = projectile.oldPos.Length, k = afterimageCount - 1; k >= 0; k--)
                spriteBatch.Draw(
                    ModContent.GetTexture($"{Texture}_Afterimage"),
                    projectile.oldPos[k] - Main.screenPosition + (projectile.Size / 2f) + new Vector2(0, projectile.gfxOffY) + offset,
                    new Rectangle(0, 0, projectile.width, projectile.height),
                    Lighting.GetColor((int)(projectile.oldPos[k].X + (projectile.width / 2f)) / 16, (int)(projectile.oldPos[k].Y + (projectile.height / 2f)) / 16)
                        * MathHelper.Lerp(startOpacity, endOpacity, k / (float)(afterimageCount - 1)),
                    projectile.oldRot[k],
                    projectile.Size / 2f,
                    MathHelper.Lerp(startScale, endScale, k / (float)(afterimageCount - 1)),
                    projectile.oldSpriteDirection[k] == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally,
                    0f);

            //if (false)
            //{ 
            //    Color color21 = Lighting.GetColor((int)(projectile.position.X + projectile.width * 0.5) / 16, (int)((projectile.position.Y + projectile.height * 0.5) / 16.0));
            //    float num100 = ((Main.projectileTexture[projectile.type].Width - projectile.width) / 2f) + (projectile.width / 2f);

            //    for (int num126 = 0; num126 < 10; num126++)
            //    {
            //        Color alpha4 = projectile.GetAlpha(color21);
            //        float num127 = (9 - num126) / 9f;
            //        alpha4.R = (byte)(alpha4.R * num127);
            //        alpha4.G = (byte)(alpha4.G * num127);
            //        alpha4.B = (byte)(alpha4.B * num127);
            //        alpha4.A = (byte)(alpha4.A * num127);
            //        float num128 = (9 - num126) / 9f;

            //        Main.spriteBatch.Draw(
            //            Main.projectileTexture[projectile.type],
            //            new Vector2(projectile.oldPos[num126].X - Main.screenPosition.X + num100, projectile.oldPos[num126].Y - Main.screenPosition.Y + (projectile.height / 2) + projectile.gfxOffY),
            //            new Rectangle(0, 0, Main.projectileTexture[projectile.type].Width, Main.projectileTexture[projectile.type].Height),
            //            alpha4,
            //            projectile.rotation,
            //            new Vector2(num100, (projectile.height / 2)),
            //            num128 * projectile.scale,
            //            SpriteEffects.None,
            //            0f);
            //    }
            //}
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
            for (int k = 0; k < 5; k++)
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