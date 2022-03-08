using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Tiles
{
    public class BasicWorkBench : ModItem
    {
        public override string Texture => AssetDirectory.GetTexture<BasicWorkBench>();

        public override void SetStaticDefaults() => Tooltip.SetDefault("A basic work bench used for basic crafting");

        public override void SetDefaults()
        {
            item.consumable     = true;
            item.createTile     = ModContent.TileType<Content.Tiles.BasicWorkBench>();
            item.value          = Item.sellPrice(copper: 30);
            item.width          = 32;
            item.height         = 18;
            item.maxStack       = 99;
            item.useTime        = 10;
            item.useAnimation   = 15;
            item.useStyle       = ItemUseStyleID.SwingThrow;
            item.useTurn        = true;
            item.autoReuse      = true;
        }
    }
}