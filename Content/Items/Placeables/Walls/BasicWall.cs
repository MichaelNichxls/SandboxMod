﻿using Microsoft.Xna.Framework;
using SandboxMod.Common;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Placeables.Walls
{
    public class BasicWall : ModItem
    {
        public override string Texture => AssetDirectory.GetTexture<BasicWall>();

        public override void SetStaticDefaults() =>
            Tooltip.SetDefault("A basic wall");

        public override void SetDefaults()
        {
            item.consumable     = true;
            item.createWall     = ModContent.WallType<Content.Walls.BasicWall>();
            item.Size           = new Vector2(16, 16);
            item.maxStack       = 999;
            item.useTime        = 7;
            item.useAnimation   = 15;
            item.useStyle       = ItemUseStyleID.SwingThrow;
            item.useTurn        = true;
            item.autoReuse      = true;
        }
    }
}