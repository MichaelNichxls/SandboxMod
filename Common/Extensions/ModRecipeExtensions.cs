using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ModLoader.Exceptions;

namespace SandboxMod.Common.Extensions
{
    public static class ModRecipeExtensions
    {
        // Make recipe.SetResult() capable of returning more than 1 ingredient, as well as recipe groups
        public static void AddBidirectionalRecipe(this ModRecipe recipe)
        {
            IEnumerable<int> tiles =
                from tile in recipe.requiredTile
                where tile != -1
                select tile;

            IEnumerable<Item> ingredients =
                from ingredient in recipe.requiredItem
                where ingredient.type != ItemID.None
                select ingredient;

            Item result = recipe.createItem;

            if (ingredients.Count() > 1)
                throw new RecipeException();

            recipe.AddRecipe();
            recipe = new ModRecipe(recipe.mod);

            foreach (int tile in tiles)
                recipe.AddTile(tile);

            recipe.AddIngredient(result.type);
            recipe.SetResult(ingredients.First().type);
            recipe.AddRecipe();
        }
    }
}