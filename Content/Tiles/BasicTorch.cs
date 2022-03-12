using Microsoft.Xna.Framework;
using SandboxMod.Common;
using SandboxMod.Content.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SandboxMod.Content.Tiles
{
    public class BasicTorch : ModTile
    {
        public override bool Autoload(ref string name, ref string texture)
        {
            texture = AssetDirectory.GetTexture<BasicTorch>();
            return base.Autoload(ref name, ref texture);
        }

        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type]   = true;
            Main.tileNoAttach[Type]         = true;
            Main.tileNoFail[Type]           = true; // ?
            Main.tileWaterDeath[Type]       = true;
            Main.tileLavaDeath[Type]        = true;
            Main.tileLighted[Type]          = true;

            TileID.Sets.FramesOnKillWall[Type] = true;

            drop                = ModContent.ItemType<Items.Tiles.BasicTorch>();
            dustType            = ModContent.DustType<BasicDust>();
            adjTiles            = new int[] { TileID.Torches };
            torch               = true;
            disableSmartCursor  = true;

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Basic Torch");
            AddMapEntry(new Color(255, 255, 255), name);

            // Is this all?
            TileObjectData.newTile.CopyFrom(TileObjectData.StyleTorch);
            TileObjectData.addTile(Type);
        }

        public override void NumDust(int i, int j, bool fail, ref int num) =>
            num = Main.rand.Next(1, 3);

        // Modify all other basic tiles.. again
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            // Add light depending on frame
            (r, g, b) = (255f / byte.MaxValue, 255f / byte.MaxValue, 255f / byte.MaxValue);
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;

            player.noThrow          = 2;
            player.showItemIcon     = true;
            player.showItemIcon2    = ModContent.ItemType<Items.Tiles.BasicTorch>();
        }
    }
}