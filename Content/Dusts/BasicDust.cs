using Microsoft.Xna.Framework;
using SandboxMod.Common;
using Terraria;
using Terraria.ModLoader;

namespace SandboxMod.Content.Dusts
{
    public class BasicDust : ModDust
    {
        public override bool Autoload(ref string name, ref string texture)
        {
            texture = AssetDirectory.GetTexture<BasicDust>();
            return base.Autoload(ref name, ref texture);
        }

        public override void OnSpawn(Dust dust)
        {
            // May or may not make a helper for reading custom dust spritesheets
            dust.frame      = new Rectangle(0, Main.rand.Next(3) * 10, 10, 10);
            dust.noGravity  = true;
            dust.noLight    = true;
            dust.scale      *= 1.5f;
        }

        public override bool Update(Dust dust)
        {
            dust.position   += dust.velocity / 1.5f;
            dust.rotation   += dust.velocity.X * 0.15f;
            dust.scale      *= 0.99f;

            Lighting.AddLight(dust.position, new Vector3(0.35f * dust.scale));

            if (dust.scale < 0.5f)
                dust.active = false;

            return false;
        }
    }
}