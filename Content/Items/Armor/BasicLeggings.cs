using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class BasicLeggings : ModItem
    {
        public override string Texture => AssetDirectory.GetTexture<BasicLeggings>();

        public override void SetStaticDefaults() => Tooltip.SetDefault(
            "20% increased movement speed"
                + "\nBasic leggings");

        public override void SetDefaults()
        {
            item.defense    = 14;
            item.rare       = ItemRarityID.Blue;
            item.value      = Item.sellPrice(silver: 20);
            item.width      = 22;
            item.height     = 18;
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);

            recipe.AddRecipeGroup("IronBar", 14);
            recipe.AddIngredient(ModContent.ItemType<BasicItem>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateEquip(Player player) => player.moveSpeed += 0.2f;
    }
}