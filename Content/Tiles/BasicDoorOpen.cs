using Microsoft.Xna.Framework;
using SandboxMod.Common;
using SandboxMod.Content.Dusts;
using SandboxMod.Content.Items.Placeables.Tiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SandboxMod.Content.Tiles
{
    public class BasicDoorOpen : ModTile
    {
        public override bool Autoload(ref string name, ref string texture)
        {
            texture = AssetDirectory.GetTexture<BasicDoorOpen>();
            return base.Autoload(ref name, ref texture);
        }

        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type]   = true;
            Main.tileLavaDeath[Type]        = true;
            Main.tileNoSunLight[Type]       = true; // ?
            Main.tileLighted[Type]          = true;

            TileID.Sets.HousingWalls[Type]  = true; // ?
            TileID.Sets.HasOutlines[Type]   = true;

            closeDoorID         = ModContent.TileType<BasicDoorClosed>();
            dustType            = ModContent.DustType<BasicDust>();
            adjTiles            = new int[] { TileID.OpenDoor };
            disableSmartCursor  = true;

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Basic Door");
            AddMapEntry(new Color(225, 225, 225), name);

            TileObjectData.newTile.UsesCustomCanPlace   = true;
            TileObjectData.newTile.StyleHorizontal      = true;
            TileObjectData.newTile.Width                = 2;
            TileObjectData.newTile.Height               = 3;
            TileObjectData.newTile.CoordinateWidth      = 16;
            TileObjectData.newTile.CoordinateHeights    = new int[] { 16, 16, 16 };
            TileObjectData.newTile.CoordinatePadding    = 2;
            TileObjectData.newTile.AnchorTop            = new AnchorData(AnchorType.SolidTile, 1, 0);
            TileObjectData.newTile.AnchorBottom         = new AnchorData(AnchorType.SolidTile, 1, 0);
            TileObjectData.newTile.Direction            = TileObjectDirection.PlaceRight;
            TileObjectData.newTile.LavaDeath            = true;

            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.AnchorTop       = new AnchorData(AnchorType.SolidTile, 1, 1);
            TileObjectData.newAlternate.AnchorBottom    = new AnchorData(AnchorType.SolidTile, 1, 1);
            TileObjectData.newTile.Direction            = TileObjectDirection.PlaceLeft;
            TileObjectData.addAlternate(1);
            TileObjectData.addTile(Type);
        }

        public override bool HasSmartInteract() =>
            true;

        public override void NumDust(int i, int j, bool fail, ref int num) =>
            num = 1;

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b) =>
            (r, g, b) = (255f / byte.MaxValue, 255f / byte.MaxValue, 255f / byte.MaxValue);

        public override void KillMultiTile(int i, int j, int frameX, int frameY) =>
            Item.NewItem(new Vector2(i * 16, j * 16), new Vector2(32, 48), ModContent.ItemType<BasicDoor>());

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;

            player.noThrow          = 2; // Still don't know what this does
            player.showItemIcon     = true;
            player.showItemIcon2    = ModContent.ItemType<BasicDoor>();
        }
    }
}