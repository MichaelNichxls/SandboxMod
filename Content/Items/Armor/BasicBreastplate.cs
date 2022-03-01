using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class BasicBreastplate : ModItem
    {
        public override string Texture => AssetDirectory.GetTexture<BasicBreastplate>();

        public override void SetStaticDefaults() => Tooltip.SetDefault("A basic breastplate");

        public override void SetDefaults()
        {
            item.defense    = 18;
            item.rare       = ItemRarityID.Blue;
            item.value      = Item.sellPrice(silver: 24);
            item.width      = 30;
            item.height     = 18;
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);

            recipe.AddRecipeGroup("IronBar", 22);
            recipe.AddIngredient(ModContent.ItemType<BasicItem>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}