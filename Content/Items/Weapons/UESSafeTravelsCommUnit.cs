using SandboxMod.Content.UI;
using SandboxMod.Core;
using SandboxMod.Core.Loaders;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Weapons
{
    public class UESSafeTravelsCommUnit : ModItem
    {
        public override string Texture => AssetDirectory.WeaponTextures + nameof(UESSafeTravelsCommUnit);

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("UES Safe Travels Comm Unit");
            Tooltip.SetDefault("Used to call down a variety of tactical drops from orbit");
        }

        public override void SetDefaults()
        {
            item.magic          = true;
            item.noMelee        = true;
            item.damage         = 100; // ?
            item.mana           = 40;
            item.crit           = 4;
            item.knockBack      = 6; // ?
            item.rare           = ItemRarityID.Red;
            item.value          = Item.gold * 12;
            item.width          = 54;
            item.height         = 42;
            item.useTime        = 20;
            item.useAnimation   = 20;
            item.useStyle       = ItemUseStyleID.HoldingOut;
            item.UseSound       = new LegacySoundStyle(SoundID.Item, 15);
            item.reuseDelay     = 50; // or so
        }

        public override void AddRecipes()
        {
            // Make helper
            var recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.LunarBar, 8);
            recipe.AddIngredient(ItemID.FragmentNebula, 12);
            recipe.AddIngredient(ItemID.Sapphire, 1);
            recipe.AddIngredient(ItemID.Wire, 50);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool AltFunctionUse(Player player) =>
            UILoader.GetUIState<ButtonPanel>().Visible ^= true;
    }
}