using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
            texture = Assets.GetTexture<BasicTorch>();
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

            drop                = ModContent.ItemType<Items.Placeables.Tiles.BasicTorch>();
            dustType            = ModContent.DustType<BasicDust>();
            adjTiles            = new int[] { TileID.Torches };
            torch               = true;
            disableSmartCursor  = true;

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Basic Torch");
            AddMapEntry(new Color(255, 255, 255), name);

            TileObjectData.newTile.CopyFrom(TileObjectData.StyleTorch);
            // I don't understand why this doesn't work
            //TileObjectData.newTile.WaterPlacement = Terraria.Enums.LiquidPlacement.NotAllowed;
            TileObjectData.addTile(Type);
        }

        public override void NumDust(int i, int j, bool fail, ref int num) =>
            num = Main.rand.Next(1, 3);

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            Tile tile = Main.tile[i, j];

            // Make a helper for getting frames
            // Make a helper for the RGB scaling math, with an added brightness factor
            if (tile.frameX < 66)
                (r, g, b) = (255f / byte.MaxValue, 255f / byte.MaxValue, 255f / byte.MaxValue);
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;

            player.noThrow          = 2;
            player.showItemIcon     = true;
            player.showItemIcon2    = ModContent.ItemType<Items.Placeables.Tiles.BasicTorch>();
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height) =>
            offsetY = WorldGen.SolidTile(i, j - 1)
                ? WorldGen.SolidTile(i - 1, j + 1) || WorldGen.SolidTile(i + 1, j + 1)
                    ? 4
                    : 2
                : 0;

        // I don't even know
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];

            // Helper getter
            int width = 20;
            int height = 20;

            // Could make helper getters for these
            int offsetY = WorldGen.SolidTile(i, j - 1)
                ? WorldGen.SolidTile(i - 1, j + 1) || WorldGen.SolidTile(i + 1, j + 1)
                    ? 4
                    : 2
                : 0;

            var zero = Main.drawToScreen
                ? Vector2.Zero
                : new Vector2(Main.offScreenRange);

            ulong seed = Main.TileFrameSeed ^ (ulong)(((long)j << 32) | (long)(uint)i);

            for (int k = 0; k < 7; k++)
            {
                float x = Utils.RandomInt(ref seed, -10, 11) * 0.15f;
                float y = Utils.RandomInt(ref seed, -10, 1) * 0.35f;

                spriteBatch.Draw(
                    ModContent.GetTexture($"{Assets.GetTexture<BasicTorch>()}_Flame"),
                    new Vector2((i * 16) - (int)Main.screenPosition.X + x - ((width - 16f) / 2f), (j * 16) - (int)Main.screenPosition.Y + y + offsetY) + zero,
                    new Rectangle(tile.frameX, tile.frameY, width, height),
                    new Color(100, 100, 100, 0));
            }
        }
    }
}