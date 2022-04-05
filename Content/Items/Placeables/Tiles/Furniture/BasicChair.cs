using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using ModTiles = SandboxMod.Content.Tiles;

namespace SandboxMod.Content.Items.Placeables.Tiles.Furniture
{
    public class BasicChair : ModItem
    {
        public override string Texture => Assets.GetTexture<BasicChair>();

        public override void SetStaticDefaults() =>
            Tooltip.SetDefault("A basic chair");

        public override void SetDefaults()
        {
            item.consumable     = true;
            item.createTile     = ModContent.TileType<ModTiles.Furniture.BasicChair>();
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