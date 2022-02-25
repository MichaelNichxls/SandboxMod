using SandboxMod.Core;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Tools
{
    public class BasicHamaxe : ModItem
    {
        public override string Texture => AssetDirectory.ToolTextures + nameof(BasicHamaxe);

        public override void SetStaticDefaults() => Tooltip.SetDefault("A basic hamaxe");

        public override void SetDefaults()
        {
            item.melee          = true;
            item.hammer         = 60;
            item.axe            = 13;
            item.damage         = 14;
            item.knockBack      = 3.25f;
            item.rare           = ItemRarityID.Blue;
            item.value          = Item.sellPrice(silver: 24);
            item.width          = 38;
            item.height         = 40;
            item.useTime        = 17;
            item.useAnimation   = 25;
            item.useStyle       = ItemUseStyleID.SwingThrow;
            item.UseSound       = SoundID.Item1;
            item.useTurn        = true;
            item.autoReuse      = true;
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);

            recipe.AddRecipeGroup("Wood", 3);
            recipe.AddRecipeGroup("IronBar", 14);
            recipe.AddIngredient(ModContent.ItemType<BasicItem>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}