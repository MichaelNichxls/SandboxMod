using Microsoft.Xna.Framework;
using SandboxMod.Common;
using SandboxMod.Content.Dusts;
using Terraria;
using Terraria.ModLoader;

namespace SandboxMod.Content.Tiles
{
    public class BasicTile : ModTile
    {
        public override bool Autoload(ref string name, ref string texture)
        {
            texture = AssetDirectory.GetTexture<BasicTile>();
            return base.Autoload(ref name, ref texture);
        }

        public override void SetDefaults()
        {
            Main.tileSolid[Type]        = true;
            Main.tileMergeDirt[Type]    = true;
            Main.tileBlockLight[Type]   = true;
            Main.tileLighted[Type]      = true;

            drop        = ModContent.ItemType<Items.Tiles.BasicTile>();
            dustType    = ModContent.DustType<BasicDust>();

            AddMapEntry(new Color(245, 245, 245));
        }

        public override void NumDust(int i, int j, bool fail, ref int num) =>
            num = fail ? 1 : 3;

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b) =>
            (r, g, b) = (255f / byte.MaxValue, 255f / byte.MaxValue, 255f / byte.MaxValue);
    }
}