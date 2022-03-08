using Microsoft.Xna.Framework;
using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Tiles
{
    public class BasicOre : ModItem
    {
        public override string Texture => AssetDirectory.GetTexture<BasicOre>();

        public override void SetStaticDefaults() => Tooltip.SetDefault("A basic ore");

        public override void SetDefaults()
        {
            item.consumable     = true;
            item.createTile     = ModContent.TileType<Content.Tiles.BasicOre>();
            item.rare           = ItemRarityID.Green;
            item.value          = Item.sellPrice(silver: 2, copper: 50);
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