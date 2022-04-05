using Microsoft.Xna.Framework;
using SandboxMod.Common;
using SandboxMod.Content.Dusts;
using Terraria;
using Terraria.ModLoader;

using ModTileItems = SandboxMod.Content.Items.Placeables.Tiles;

namespace SandboxMod.Content.Tiles
{
    public class BasicTile : ModTile
    {
        public override bool Autoload(ref string name, ref string texture)
        {
            texture = Assets.GetTexture<BasicTile>();
            return base.Autoload(ref name, ref texture);
        }

        public override void SetDefaults()
        {
            Main.tileSolid[Type]        = true;
            Main.tileMergeDirt[Type]    = true;
            Main.tileBlockLight[Type]   = true;

            drop        = ModContent.ItemType<ModTileItems.BasicTile>();
            dustType    = ModContent.DustType<BasicDust>();

            AddMapEntry(new Color(245, 245, 245));
        }

        public override void NumDust(int i, int j, bool fail, ref int num) =>
            num = fail ? 1 : 3;
    }
}