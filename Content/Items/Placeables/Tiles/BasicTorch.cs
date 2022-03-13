using Microsoft.Xna.Framework;
using SandboxMod.Common;
using SandboxMod.Content.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Placeables.Tiles
{
    public class BasicTorch : ModItem
    {
        public override string Texture => AssetDirectory.GetTexture<BasicTorch>();

        public override void SetStaticDefaults() => Tooltip.SetDefault("A basic torch that provides light");

        public override void SetDefaults()
        {
            item.consumable     = true;
            item.flame          = true;
            item.noWet          = true;
            item.createTile     = ModContent.TileType<Content.Tiles.BasicTorch>();
            item.value          = Item.sellPrice(copper: 10);
            item.Size           = new Vector2(14, 16);
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
                Dust.NewDust(new Vector2(player.itemLocation.X + (16f * player.direction), player.itemLocation.Y - (14f * player.gravDir)), 4, 4, ModContent.DustType<BasicDust>());

            Lighting.AddLight(
                player.RotatedRelativePoint(new Vector2(player.itemLocation.X + (12f * player.direction) + player.velocity.X, player.itemLocation.Y - 14f + player.velocity.Y)),
                new Vector3(1f, 1f, 1f));
        }

        public override void PostUpdate()
        {
            if (item.wet)
                return;

            Lighting.AddLight(item.Center, new Vector3(1f, 1f, 1f));
        }
    }
}