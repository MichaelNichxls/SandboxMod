using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using ModTiles = SandboxMod.Content.Tiles;

namespace SandboxMod.Content.Items.Placeables.Tiles.Furniture
{
    public class MaterialTransmuter : ModItem
    {
        public override string Texture => Assets.GetTexture<MaterialTransmuter>();

        public override void SetStaticDefaults() =>
            Tooltip.SetDefault("Allows for transmutation of materials into their counterparts");

        public override void SetDefaults()
        {
            item.consumable     = true;
            item.createTile     = ModContent.TileType<ModTiles.Furniture.MaterialTransmuter>();
            item.value          = Item.sellPrice(gold: 1);
            item.Size           = ModContent.GetTexture(Texture).Size();
            item.maxStack       = 99;
            item.useTime        = 10;
            item.useAnimation   = 15;
            item.useStyle       = ItemUseStyleID.SwingThrow;
            item.useTurn        = true;
            item.autoReuse      = true;
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);

            // Make const string
            recipe.AddRecipeGroup($"{nameof(SandboxMod)}:EvilBar", 6);
            recipe.AddIngredient(ItemID.Obsidian, 8);
            recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}