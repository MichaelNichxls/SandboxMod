using Microsoft.Xna.Framework;
using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class BasicBreastplate : ModItem
    {
        public override string Texture => Assets.GetTexture<BasicBreastplate>();

        public override void SetStaticDefaults() =>
            Tooltip.SetDefault("A basic breastplate");

        public override void SetDefaults()
        {
            item.defense    = 9;
            item.rare       = ItemRarityID.Blue;
            item.value      = Item.sellPrice(silver: 24);
            item.Size       = new Vector2(30, 18);
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.PlatinumBar, 22);
            recipe.AddIngredient(ModContent.ItemType<BasicItem>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}