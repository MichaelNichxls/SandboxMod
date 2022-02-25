using SandboxMod.Core;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Weapons
{
    public class BasicSword : ModItem
    {
        public override string Texture => AssetDirectory.WeaponTextures + nameof(BasicSword);

        public override void SetDefaults()
        {
            item.melee          = true;
            item.damage         = 50;
            item.knockBack      = 6;
            item.rare           = ItemRarityID.Green;
            item.value          = Item.gold;
            item.width          = 40;
            item.height         = 40;
            item.useTime        = 20;
            item.useAnimation   = 20;
            item.useStyle       = ItemUseStyleID.SwingThrow;
            item.UseSound       = SoundID.Item1;
            item.autoReuse      = true;
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}