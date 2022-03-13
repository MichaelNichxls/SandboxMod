using Microsoft.Xna.Framework;
using SandboxMod.Common;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Placeables.Tiles
{
    public class BasicTile : ModItem
    {
        public override string Texture => AssetDirectory.GetTexture<BasicTile>();

        public override void SetStaticDefaults() => Tooltip.SetDefault("A basic tile");

        public override void SetDefaults()
        {
            item.consumable     = true;
            item.createTile     = ModContent.TileType<Content.Tiles.BasicTile>();
            item.Size           = new Vector2(16, 16);
            item.maxStack       = 999;
            item.useTime        = 10;
            item.useAnimation   = 15;
            item.useStyle       = ItemUseStyleID.SwingThrow;
            item.useTurn        = true;
            item.autoReuse      = true;
        }
    }
}