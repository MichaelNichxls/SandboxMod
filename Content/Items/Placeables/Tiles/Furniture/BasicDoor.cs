using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using ModTiles = SandboxMod.Content.Tiles;

namespace SandboxMod.Content.Items.Placeables.Tiles.Furniture
{
    public class BasicDoor : ModItem
    {
        public override string Texture => Assets.GetTexture<BasicDoor>();

        public override void SetStaticDefaults() =>
            Tooltip.SetDefault("A basic door");

        public override void SetDefaults()
        {
            item.consumable     = true;
            item.createTile     = ModContent.TileType<ModTiles.Furniture.BasicDoorClosed>();
            item.value          = Item.sellPrice(copper: 40);
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