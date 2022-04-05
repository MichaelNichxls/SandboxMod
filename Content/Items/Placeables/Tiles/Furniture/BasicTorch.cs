using Microsoft.Xna.Framework;
using SandboxMod.Common;
using SandboxMod.Content.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using ModTiles = SandboxMod.Content.Tiles;

namespace SandboxMod.Content.Items.Placeables.Tiles.Furniture
{
    public class BasicTorch : ModItem
    {
        public override string Texture => Assets.GetTexture<BasicTorch>();

        public override void SetStaticDefaults() =>
            Tooltip.SetDefault("A basic torch that provides light");

        public override void SetDefaults()
        {
            item.consumable     = true;
            item.flame          = true;
            item.noWet          = true;
            item.createTile     = ModContent.TileType<ModTiles.Furniture.BasicTorch>();
            item.value          = Item.sellPrice(copper: 10);
            item.Size           = ModContent.GetTexture(Texture).Size();
            item.maxStack       = 99;
            item.useTime        = 10;
            item.useAnimation   = 15;
            item.useStyle       = ItemUseStyleID.SwingThrow;
            item.holdStyle      = ItemHoldStyleID.HoldingOut;
            item.useTurn        = true;
            item.autoReuse      = true;
        }

        public override void AutoLightSelect(ref bool dryTorch, ref bool wetTorch, ref bool glowstick) =>
            dryTorch = true;

        public override void HoldItem(Player player)
        {
            if (player.wet)
                return;

            if (Main.rand.Next(player.itemAnimation > 0 ? 40 : 80) == 0)
                Dust.NewDust(new Vector2(player.itemLocation.X + (player.direction * 16f), player.itemLocation.Y - (player.gravDir * 14f)), 4, 4, ModContent.DustType<BasicDust>());

            Vector2 position = player.RotatedRelativePoint(new Vector2(player.itemLocation.X + (player.direction * 12f) + player.velocity.X, player.itemLocation.Y - 14f + player.velocity.Y));
            Lighting.AddLight(position, new Vector3(1, 1, 1));
        }

        public override void PostUpdate()
        {
            if (item.wet)
                return;

            Lighting.AddLight(item.Center, new Vector3(1, 1, 1));
        }
    }
}