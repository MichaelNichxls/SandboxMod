using Microsoft.Xna.Framework;
using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Placeables.Tiles
{
    public class BasicDoor : ModItem
    {
        public override string Texture => AssetDirectory.GetTexture<BasicDoor>();

        public override void SetStaticDefaults() => Tooltip.SetDefault("A basic door");

        public override void SetDefaults()
        {
            item.consumable     = true;
            item.createTile     = ModContent.TileType<Content.Tiles.BasicDoorClosed>();
            item.value          = Item.sellPrice(copper: 40);
            item.Size           = new Vector2(18, 32);
            item.maxStack       = 99;
            item.useTime        = 10;
            item.useAnimation   = 15;
            item.useStyle       = ItemUseStyleID.SwingThrow;
            item.useTurn        = true;
            item.autoReuse      = true;
        }
    }
}