using Microsoft.Xna.Framework;
using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Walls
{
    public class BasicWall : ModWall
    {
        public override bool Autoload(ref string name, ref string texture)
        {
            texture = AssetDirectory.GetTexture<BasicWall>();
            return base.Autoload(ref name, ref texture);
        }

        public override void SetDefaults()
        {
            // Needs more here
            Main.wallHouse[Type] = true;

            drop = ModContent.ItemType<Items.Walls.BasicWall>();
            dustType = DustID.Sparkle; // Make custom dust

            AddMapEntry(new Color(200, 200, 200));
        }

        public override void NumDust(int i, int j, bool fail, ref int num) =>
            num = fail ? 1 : 3;

        //public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b) =>
        //    (r, g, b) = (1f / byte.MaxValue, 152f / byte.MaxValue, 220f / byte.MaxValue);
    }
}