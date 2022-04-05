using Microsoft.Xna.Framework;
using SandboxMod.Common;
using SandboxMod.Content.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

using ModTileItems = SandboxMod.Content.Items.Placeables.Tiles;

namespace SandboxMod.Content.Tiles
{
    public class BasicWorkBench : ModTile
    {
        public override bool Autoload(ref string name, ref string texture)
        {
            texture = Assets.GetTexture<BasicWorkBench>();
            return base.Autoload(ref name, ref texture);
        }

        public override void SetDefaults()
        {
            // How to disable NPC step-up?
            Main.tileFrameImportant[Type]   = true;
            Main.tileNoAttach[Type]         = true;
            Main.tileTable[Type]            = true;
            Main.tileSolidTop[Type]         = true;
            Main.tileLavaDeath[Type]        = true;

            dustType            = ModContent.DustType<BasicDust>();
            adjTiles            = new int[] { TileID.WorkBenches };
            disableSmartCursor  = true;

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Basic Work Bench");
            AddMapEntry(new Color(225, 225, 225), name);

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 18 };
            TileObjectData.addTile(Type);
        }

        public override void NumDust(int i, int j, bool fail, ref int num) =>
            num = fail ? 1 : 3;

        public override void KillMultiTile(int i, int j, int frameX, int frameY) =>
            Item.NewItem(new Vector2(i * 16, j * 16), new Vector2(32, 16), ModContent.ItemType<ModTileItems.BasicWorkBench>());
    }
}