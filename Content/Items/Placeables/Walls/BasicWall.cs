using Microsoft.Xna.Framework;
using SandboxMod.Common;
using Terraria.ID;
using Terraria.ModLoader;

using ModWalls = SandboxMod.Content.Walls;

namespace SandboxMod.Content.Items.Placeables.Walls
{
    public class BasicWall : ModItem
    {
        public override string Texture => Assets.GetTexture<BasicWall>();

        public override void SetStaticDefaults() =>
            Tooltip.SetDefault("A basic wall");

        public override void SetDefaults()
        {
            item.consumable     = true;
            item.createWall     = ModContent.WallType<ModWalls.BasicWall>();
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