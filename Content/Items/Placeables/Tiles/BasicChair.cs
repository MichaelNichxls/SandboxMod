using Microsoft.Xna.Framework;
using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Placeables.Tiles
{
    public class BasicChair : ModItem
    {
        public override string Texture => Assets.GetTexture<BasicChair>();

        public override void SetStaticDefaults() =>
            Tooltip.SetDefault("A basic chair");

        public override void SetDefaults()
        {
            item.consumable     = true;
            item.createTile     = ModContent.TileType<Content.Tiles.BasicChair>();
            item.value          = Item.sellPrice(copper: 30);
            item.Size           = new Vector2(16, 32);
            item.maxStack       = 99;
            item.useTime        = 10;
            item.useAnimation   = 15;
            item.useStyle       = ItemUseStyleID.SwingThrow;
            item.useTurn        = true;
            item.autoReuse      = true;
        }
    }
}