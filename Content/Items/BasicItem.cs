using Microsoft.Xna.Framework;
using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items
{
    // Rename to BasicMaterial?
    public class BasicItem : ModItem
    {
        public override string Texture => AssetDirectory.GetTexture<BasicItem>();

        public override void SetStaticDefaults() =>
            Tooltip.SetDefault("A basic item");

        public override void SetDefaults()
        {
            item.rare       = ItemRarityID.Blue;
            item.value      = Item.sellPrice(silver: 15);
            item.Size       = new Vector2(18, 20);
            item.maxStack   = 999;
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.ShadowScale, 6);
            recipe.AddIngredient(ItemID.Emerald);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}