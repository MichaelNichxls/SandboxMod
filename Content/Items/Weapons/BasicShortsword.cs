using Microsoft.Xna.Framework;
using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Weapons
{
    public class BasicShortsword : ModItem
    {
        public override string Texture => AssetDirectory.GetTexture<BasicShortsword>();

        public override void SetStaticDefaults() => Tooltip.SetDefault("A basic shortsword");

        public override void SetDefaults()
        {
            item.melee          = true;
            item.damage         = 20;
            item.knockBack      = 4.5f;
            item.rare           = ItemRarityID.Blue;
            item.value          = Item.sellPrice(silver: 22);
            item.Size           = new Vector2(32, 32);
            item.useTime        = 18;
            item.useAnimation   = item.useTime;
            item.useStyle       = ItemUseStyleID.Stabbing;
            item.UseSound       = SoundID.Item1;
            item.autoReuse      = true;
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.PlatinumBar, 6);
            recipe.AddIngredient(ModContent.ItemType<BasicItem>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}