using Microsoft.Xna.Framework;
using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SandboxMod.Content.Tiles
{
    public class MaterialTransmuter : ModTile
    {
        // Am I doing this right?
        public override bool Autoload(ref string name, ref string texture)
        {
			texture = AssetDirectory.GetTexture<MaterialTransmuter>();
            return base.Autoload(ref name, ref texture);
        }

        public override void SetDefaults()
        {
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            Main.tileFrameImportant[Type] = true;

            //disableSmartCursor = true;
            //TileID.Sets.DisableSmartCursor[Type] = true;
            //TileID.Sets.IgnoredByNpcStepUp[Type] = true; // This line makes NPCs not try to step up this tile during their movement. Only use this for furniture with solid tops.

            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            TileObjectData.addTile(Type);

            //adjTiles = new int[] { ModContent.ItemType<Items.Tiles.MaterialTransmuter>() };
            dustType = DustID.Wraith;

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Material Transmuter");
            AddMapEntry(new Color(30, 6, 49), name);

            // Add lights
        }

        // Impending helpers galore
        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;

        // Make const for 16, maybe
        public override void KillMultiTile(int i, int j, int frameX, int frameY) =>
            Item.NewItem(new Vector2(i * 16, j * 16), new Vector2(48, 32), ModContent.ItemType<Items.Tiles.MaterialTransmuter>());
    }
}