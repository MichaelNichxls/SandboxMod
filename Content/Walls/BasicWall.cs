﻿using Microsoft.Xna.Framework;
using SandboxMod.Common;
using SandboxMod.Content.Dusts;
using Terraria;
using Terraria.ModLoader;

using ModWallItems = SandboxMod.Content.Items.Placeables.Walls;

namespace SandboxMod.Content.Walls
{
    public class BasicWall : ModWall
    {
        public override bool Autoload(ref string name, ref string texture)
        {
            texture = Assets.GetTexture<BasicWall>();
            return base.Autoload(ref name, ref texture);
        }

        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;

            drop        = ModContent.ItemType<ModWallItems.BasicWall>();
            dustType    = ModContent.DustType<BasicDust>();

            AddMapEntry(new Color(200, 200, 200));
        }

        public override void NumDust(int i, int j, bool fail, ref int num) =>
            num = fail ? 1 : 3;
    }
}