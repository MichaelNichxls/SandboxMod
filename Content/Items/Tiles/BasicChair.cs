using SandboxMod.Common;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Tiles
{
    public class BasicChair : ModItem
    {
        public override string Texture => AssetDirectory.GetTexture<BasicChair>();

        public override void SetStaticDefaults() => Tooltip.SetDefault("A basic chair");

        public override void SetDefaults()
        {
            item.consumable     = true;
            item.createTile     = ModContent.TileType<Content.Tiles.BasicChair>();
            item.width          = 16;
            item.height         = 32;
            item.maxStack       = 99;
            item.useTime        = 10;
            item.useAnimation   = 15;
            item.useStyle       = ItemUseStyleID.SwingThrow;
            item.useTurn        = true;
            item.autoReuse      = true;
        }
    }
}