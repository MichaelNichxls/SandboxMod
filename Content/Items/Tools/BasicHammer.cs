using SandboxMod.Core;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Tools
{
    public class BasicHammer : ModItem
    {
        public override string Texture => AssetDirectory.ToolTextures + nameof(BasicHammer);

        public override void SetStaticDefaults() => Tooltip.SetDefault("A basic hammer");

        public override void SetDefaults()
        {
            item.melee          = true;
            item.hammer         = 60;
            item.damage         = 12;
            item.knockBack      = 2.5f;
            item.rare           = ItemRarityID.Blue;
            item.value          = Item.sellPrice(silver: 24);
            item.width          = 36;
            item.height         = 36;
            item.useTime        = 18;
            item.useAnimation   = 28;
            item.useStyle       = ItemUseStyleID.SwingThrow;
            item.UseSound       = SoundID.Item1;
            item.useTurn        = true;
            item.autoReuse      = true;
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);

            recipe.AddRecipeGroup("Wood", 3);
            recipe.AddRecipeGroup("IronBar", 8);
            recipe.AddIngredient(ModContent.ItemType<BasicItem>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}