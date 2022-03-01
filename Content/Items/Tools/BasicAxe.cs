using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Tools
{
    public class BasicAxe : ModItem
    {
        public override string Texture => AssetDirectory.GetTexture<BasicAxe>();

        public override void SetStaticDefaults() => Tooltip.SetDefault("A basic axe");

        public override void SetDefaults()
        {
            item.melee          = true;
            item.axe            = 16;
            item.damage         = 14;
            item.knockBack      = 3.25f;
            item.rare           = ItemRarityID.Blue;
            item.value          = Item.sellPrice(silver: 24);
            item.width          = 38;
            item.height         = 34;
            item.useTime        = 17;
            item.useAnimation   = item.useTime;
            item.useStyle       = ItemUseStyleID.SwingThrow;
            item.UseSound       = SoundID.Item1;
            item.autoReuse      = true;
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);

            recipe.AddRecipeGroup("Wood", 3);
            recipe.AddIngredient(ItemID.PlatinumBar, 8);
            recipe.AddIngredient(ModContent.ItemType<BasicItem>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}