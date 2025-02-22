﻿using Microsoft.Xna.Framework;
using SandboxMod.Common;
using SandboxMod.Content.Dusts;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

using ModTileItems = SandboxMod.Content.Items.Placeables.Tiles;

namespace SandboxMod.Content.Tiles.Furniture
{
    public class BasicChair : ModTile
    {
        public override bool Autoload(ref string name, ref string texture)
        {
            texture = Assets.GetTexture<BasicChair>();
            return base.Autoload(ref name, ref texture);
        }

        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type]   = true;
            Main.tileNoAttach[Type]         = true;
            Main.tileLavaDeath[Type]        = true;

            dustType            = ModContent.DustType<BasicDust>();
            adjTiles            = new int[] { TileID.Chairs };
            disableSmartCursor  = true;

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Basic Chair");
            AddMapEntry(new Color(225, 225, 225), name);

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
            TileObjectData.newTile.StyleHorizontal      = true;
            TileObjectData.newTile.CoordinateHeights    = new int[] { 16, 18 };
            TileObjectData.newTile.Direction            = TileObjectDirection.PlaceLeft;

            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
            TileObjectData.addAlternate(1);
            TileObjectData.addTile(Type);
        }

        public override void NumDust(int i, int j, bool fail, ref int num) =>
            num = fail ? 1 : 3;

        public override void KillMultiTile(int i, int j, int frameX, int frameY) =>
            Item.NewItem(new Vector2(i, j) * 16, new Vector2(16, 32), ModContent.ItemType<ModTileItems.Furniture.BasicChair>());
    }
}