﻿using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Tools
{
    public class BasicPickaxe : ModItem
    {
        public override string Texture => Assets.GetTexture<BasicPickaxe>();

        public override void SetStaticDefaults() =>
            Tooltip.SetDefault("Able to mine Hellstone"
                + "\nA basic pickaxe");

        public override void SetDefaults()
        {
            item.melee          = true;
            item.pick           = 70;
            item.damage         = 10;
            item.knockBack      = 1.75f;
            item.rare           = ItemRarityID.Blue;
            item.value          = Item.sellPrice(silver: 20);
            item.Size           = ModContent.GetTexture(Texture).Size();
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

            recipe.AddRecipeGroup(RecipeGroupID.Wood, 3);
            recipe.AddIngredient(ItemID.PlatinumBar, 10);
            recipe.AddIngredient(ModContent.ItemType<BasicItem>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}