using Microsoft.Xna.Framework;
using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Tools
{
    public class BasicHamaxe : ModItem
    {
        public override string Texture => Assets.GetTexture<BasicHamaxe>();

        public override void SetStaticDefaults() =>
            Tooltip.SetDefault("A basic hamaxe");

        public override void SetDefaults()
        {
            item.melee          = true;
            item.hammer         = 60;
            item.axe            = 16;
            item.damage         = 14;
            item.knockBack      = 3.25f;
            item.rare           = ItemRarityID.Blue;
            item.value          = Item.sellPrice(silver: 24);
            item.Size           = new Vector2(38, 38);
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

            recipe.AddRecipeGroup(RecipeGroupID.Wood, 3);
            recipe.AddIngredient(ItemID.PlatinumBar, 14);
            recipe.AddIngredient(ModContent.ItemType<BasicItem>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}