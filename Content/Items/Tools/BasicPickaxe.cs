using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Tools
{
    public class BasicPickaxe : ModItem
    {
        public override string Texture => AssetDirectory.GetTexture<BasicPickaxe>();

        public override void SetStaticDefaults() => Tooltip.SetDefault("A basic pickaxe");

        public override void SetDefaults()
        {
            item.melee          = true;
            item.pick           = 60;
            item.damage         = 10;
            item.knockBack      = 1.75f;
            item.rare           = ItemRarityID.Blue;
            item.value          = Item.sellPrice(silver: 20);
            item.width          = 36;
            item.height         = 36;
            item.useTime        = 13;
            item.useAnimation   = 20;
            item.useStyle       = ItemUseStyleID.SwingThrow;
            item.UseSound       = SoundID.Item1;
            item.useTurn        = true;
            item.autoReuse      = true;
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);

            recipe.AddRecipeGroup("Wood", 3);
            recipe.AddRecipeGroup("IronBar", 10);
            recipe.AddIngredient(ModContent.ItemType<BasicItem>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}