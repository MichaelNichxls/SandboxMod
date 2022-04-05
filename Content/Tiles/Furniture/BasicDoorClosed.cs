using Microsoft.Xna.Framework;
using SandboxMod.Common;
using SandboxMod.Content.Dusts;
using SandboxMod.Content.Items.Placeables.Tiles.Furniture;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SandboxMod.Content.Tiles.Furniture
{
    public class BasicDoorClosed : ModTile
    {
        public override bool Autoload(ref string name, ref string texture)
        {
            texture = Assets.GetTexture<BasicDoorClosed>();
            return base.Autoload(ref name, ref texture);
        }

        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type]   = true;
            Main.tileNoAttach[Type]         = true;
            Main.tileSolid[Type]            = true;
            Main.tileLavaDeath[Type]        = true;
            Main.tileBlockLight[Type]       = true;

            TileID.Sets.NotReallySolid[Type]    = true;
            TileID.Sets.DrawsWalls[Type]        = true; // ?
            TileID.Sets.HasOutlines[Type]       = true;

            openDoorID          = ModContent.TileType<BasicDoorOpen>();
            dustType            = ModContent.DustType<BasicDust>();
            adjTiles            = new int[] { TileID.ClosedDoor };
            disableSmartCursor  = true;

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Basic Door");
            AddMapEntry(new Color(225, 225, 225), name);

            TileObjectData.newTile.UsesCustomCanPlace   = true;
            TileObjectData.newTile.Width                = 1;
            TileObjectData.newTile.Height               = 3;
            TileObjectData.newTile.CoordinateWidth      = 16;
            TileObjectData.newTile.CoordinateHeights    = new int[] { 16, 16, 16 };
            TileObjectData.newTile.CoordinatePadding    = 2;
            TileObjectData.newTile.Origin               = new Point16(0, 0);
            TileObjectData.newTile.AnchorTop            = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.AnchorBottom         = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.LavaDeath            = true;

            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Origin = new Point16(0, 1);
            TileObjectData.addAlternate(0);

            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Origin = new Point16(0, 2);
            TileObjectData.addAlternate(0);
            TileObjectData.addTile(Type);
        }

        public override bool HasSmartInteract() =>
            true;

        public override void NumDust(int i, int j, bool fail, ref int num) =>
            num = 1;

        public override void KillMultiTile(int i, int j, int frameX, int frameY) =>
            Item.NewItem(new Vector2(i, j) * 16, new Vector2(16, 48), ModContent.ItemType<BasicDoor>());

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;

            player.noThrow          = 2; // ?
            player.showItemIcon     = true;
            player.showItemIcon2    = ModContent.ItemType<BasicDoor>();
        }
    }
}