using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items
{
    public class BasicItem : ModItem
    {
        public override string Texture => AssetDirectory.GetTexture<BasicItem>();

        public override void SetStaticDefaults() => Tooltip.SetDefault("A basic item");

        public override void SetDefaults()
        {
            item.rare       = ItemRarityID.Blue;
            item.value      = Item.sellPrice(silver: 15);
            item.width      = 18;
            item.height     = 20;
            item.maxStack   = 999;
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);

            // Make recipe group
            recipe.AddIngredient(ItemID.ShadowScale, 6);
            recipe.AddIngredient(ItemID.Emerald);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}