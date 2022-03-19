using Microsoft.Xna.Framework;
using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Accessories
{
    public class BasicAccessory : ModItem
    {
        public override string Texture => AssetDirectory.GetTexture<BasicAccessory>();

        public override void SetStaticDefaults() =>
            Tooltip.SetDefault("4 defense"
                + "\n+20 max life"
                + "\n16% increased damage"
                + "\nA basic accessory");

        public override void SetDefaults()
        {
            item.accessory  = true;
            item.rare       = ItemRarityID.Green;
            item.value      = Item.sellPrice(silver: 28);
            item.Size       = new Vector2(18, 20);
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.Spike, 6);
            recipe.AddIngredient(ModContent.ItemType<BasicItem>(), 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statDefense  += 4;
            player.statLifeMax2 += 20;
            player.allDamage    += 0.16f;
        }
    }
}