using Microsoft.Xna.Framework;
using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using ModTileItems = SandboxMod.Content.Items.Placeables.Tiles;

namespace SandboxMod.Content.Tiles
{
    public class BasicOre : ModTile
    {
        public override bool Autoload(ref string name, ref string texture)
        {
            texture = Assets.GetTexture<BasicOre>();
            return base.Autoload(ref name, ref texture);
        }

        public override void SetDefaults()
        {
            Main.tileSolid[Type]        = true;
            Main.tileMergeDirt[Type]    = true;
            Main.tileSpelunker[Type]    = true;
            Main.tileValue[Type]        = 420;
            Main.tileShine[Type]        = 975;
            Main.tileShine2[Type]       = true;
            Main.tileBlockLight[Type]   = true;
            Main.tileLighted[Type]      = true;

            TileID.Sets.Ore[Type] = true;

            minPick     = 65;
            mineResist  = 2.5f;
            drop        = ModContent.ItemType<ModTileItems.BasicOre>();
            dustType    = DustID.IceRod;
            soundType   = SoundID.Tink;
            soundStyle  = 1;

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Basic Ore");
            AddMapEntry(new Color(12, 224, 255), name);
        }

        public override void NumDust(int i, int j, bool fail, ref int num) =>
            num = fail ? 1 : 3;

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b) =>
            (r, g, b) = (1f / byte.MaxValue, 152f / byte.MaxValue, 220f / byte.MaxValue);
    }
}