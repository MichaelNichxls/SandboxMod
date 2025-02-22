﻿using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using ModTiles = SandboxMod.Content.Tiles;

namespace SandboxMod.Content.Items.Placeables.Tiles
{
    public class BasicTile : ModItem
    {
        public override string Texture => Assets.GetTexture<BasicTile>();

        public override void SetStaticDefaults() =>
            Tooltip.SetDefault("A basic tile");

        public override void SetDefaults()
        {
            item.consumable     = true;
            item.createTile     = ModContent.TileType<ModTiles.BasicTile>();
            item.Size           = ModContent.GetTexture(Texture).Size();
            item.maxStack       = 999;
            item.useTime        = 10;
            item.useAnimation   = 15;
            item.useStyle       = ItemUseStyleID.SwingThrow;
            item.useTurn        = true;
            item.autoReuse      = true;
        }
    }
}