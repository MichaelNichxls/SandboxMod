using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using ModTiles = SandboxMod.Content.Tiles;

namespace SandboxMod.Content.Items.Placeables.Tiles.Furniture
{
    public class BasicWorkBench : ModItem
    {
        public override string Texture => Assets.GetTexture<BasicWorkBench>();

        public override void SetStaticDefaults() =>
            Tooltip.SetDefault("A basic work bench used for basic crafting");

        public override void SetDefaults()
        {
            item.consumable     = true;
            item.createTile     = ModContent.TileType<ModTiles.Furniture.BasicWorkBench>();
            item.value          = Item.sellPrice(copper: 30);
            item.Size           = ModContent.GetTexture(Texture).Size();
            item.maxStack       = 99;
            item.useTime        = 10;
            item.useAnimation   = 15;
            item.useStyle       = ItemUseStyleID.SwingThrow;
            item.useTurn        = true;
            item.autoReuse      = true;
        }
    }
}