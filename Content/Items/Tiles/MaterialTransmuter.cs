using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Tiles
{
    public class MaterialTransmuter : ModItem
    {
        // Maybe widen the texture a bit
        public override string Texture => AssetDirectory.GetTexture<MaterialTransmuter>();

        public override void SetStaticDefaults() => Tooltip.SetDefault("Allows for transmutation of materials into their counterparts");

        public override void SetDefaults()
        {
            item.consumable     = true;
            item.createTile     = ModContent.TileType<Content.Tiles.MaterialTransmuter>();
            item.value          = Item.sellPrice(gold: 1);
            item.width          = 38;
            item.height         = 34;
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