using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Weapons
{
    public class BasicBroadsword : ModItem
    {
        public override string Texture => AssetDirectory.GetTexture<BasicBroadsword>();

        public override void SetStaticDefaults() => Tooltip.SetDefault("A basic broadsword");

        public override void SetDefaults()
        {
            item.melee          = true;
            item.damage         = 20;
            item.knockBack      = 4.5f;
            item.rare           = ItemRarityID.Blue;
            item.value          = Item.sellPrice(silver: 22);
            item.width          = 40;
            item.height         = 40;
            item.useTime        = 18;
            item.useAnimation   = item.useTime;
            item.useStyle       = ItemUseStyleID.SwingThrow;
            item.UseSound       = SoundID.Item1;
            item.autoReuse      = true;
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);

            // Make const string
            recipe.AddIngredient(ItemID.PlatinumBar, 8);
            recipe.AddIngredient(ModContent.ItemType<BasicItem>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}