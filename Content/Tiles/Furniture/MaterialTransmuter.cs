using Microsoft.Xna.Framework;
using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

using ModTileItems = SandboxMod.Content.Items.Placeables.Tiles;

namespace SandboxMod.Content.Tiles.Furniture
{
    public class MaterialTransmuter : ModTile
    {
        public override bool Autoload(ref string name, ref string texture)
        {
            texture = Assets.GetTexture<MaterialTransmuter>();
            return base.Autoload(ref name, ref texture);
        }

        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type]   = true;
            Main.tileNoAttach[Type]         = true;
            Main.tileLavaDeath[Type]        = true;
            Main.tileLighted[Type]          = true;

            dustType            = DustID.Wraith;
            disableSmartCursor  = true;

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Material Transmuter");
            AddMapEntry(new Color(30, 6, 49), name);

            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.addTile(Type);
        }

        public override void NumDust(int i, int j, bool fail, ref int num) =>
            num = fail ? 1 : 3;

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b) =>
            (r, g, b) = (116f / byte.MaxValue, 30f / byte.MaxValue, 146f / byte.MaxValue);

        public override void KillMultiTile(int i, int j, int frameX, int frameY) =>
            Item.NewItem(new Vector2(i, j) * 16, new Vector2(48, 32), ModContent.ItemType<ModTileItems.Furniture.MaterialTransmuter>());
    }
}