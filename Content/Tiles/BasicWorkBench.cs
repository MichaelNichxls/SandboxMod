using Microsoft.Xna.Framework;
using SandboxMod.Common;
using SandboxMod.Content.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SandboxMod.Content.Tiles
{
    public class BasicWorkBench : ModTile
    {
        public override bool Autoload(ref string name, ref string texture)
        {
            texture = AssetDirectory.GetTexture<BasicWorkBench>();
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
            Main.tileLighted[Type]          = true;

            dustType            = ModContent.DustType<BasicDust>();
            adjTiles            = new int[] { TileID.WorkBenches };
            disableSmartCursor  = true;

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Basic Work Bench");
            AddMapEntry(new Color(235, 235, 235), name);

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 18 };
            TileObjectData.addTile(Type);
        }

        public override void NumDust(int i, int j, bool fail, ref int num) =>
            num = fail ? 1 : 3;

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b) =>
            (r, g, b) = (255f / byte.MaxValue, 255f / byte.MaxValue, 255f / byte.MaxValue);

        public override void KillMultiTile(int i, int j, int frameX, int frameY) =>
            Item.NewItem(new Vector2(i * 16, j * 16), new Vector2(32, 16), ModContent.ItemType<Items.Tiles.BasicWorkBench>());
    }
}