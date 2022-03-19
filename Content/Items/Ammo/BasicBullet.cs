using Microsoft.Xna.Framework;
using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Ammo
{
    public class BasicBullet : ModItem
    {
        public override string Texture => AssetDirectory.GetTexture<BasicBullet>();

        public override void SetStaticDefaults() =>
            Tooltip.SetDefault("A basic bullet");

        public override void SetDefaults()
        {
            item.ranged     = true;
            item.consumable = true;
            item.damage     = 11;
            item.knockBack  = 3.25f;
            item.ammo       = AmmoID.Bullet;
            item.shoot      = ModContent.ProjectileType<Projectiles.Ammo.BasicBullet>();
            item.shootSpeed = 5.25f;
            item.rare       = ItemRarityID.Blue;
            item.value      = Item.sellPrice(copper: 20);
            item.Size       = new Vector2(8, 8);
            item.maxStack   = 999;
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.SilverBullet, 700);
            recipe.AddIngredient(ModContent.ItemType<BasicItem>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 700);
            recipe.AddRecipe();
        }
    }
}