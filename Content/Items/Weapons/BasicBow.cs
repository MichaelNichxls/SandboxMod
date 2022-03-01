using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Weapons
{
    public class BasicBow : ModItem
    {
        public override string Texture => AssetDirectory.GetTexture<BasicBow>();

        public override void SetStaticDefaults() => Tooltip.SetDefault("A basic bow");

        public override void SetDefaults()
        {
            item.ranged         = true;
            item.noMelee        = true;
            item.damage         = 16;
            item.useAmmo        = AmmoID.Arrow;
            item.shoot          = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed     = 7.5f;
            item.rare           = ItemRarityID.Blue;
            item.value          = Item.sellPrice(silver: 22);
            item.width          = 20;
            item.height         = 36;
            item.useTime        = 25;
            item.useAnimation   = item.useTime;
            item.useStyle       = ItemUseStyleID.HoldingOut;
            item.UseSound       = SoundID.Item5;
            item.autoReuse      = true;
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.PlatinumBar, 7);
            recipe.AddIngredient(ModContent.ItemType<BasicItem>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}