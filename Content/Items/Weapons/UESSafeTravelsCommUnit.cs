using SandboxMod.Common;
using SandboxMod.Common.Loaders;
using SandboxMod.Content.UI;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Weapons
{
    public class UESSafeTravelsCommUnit : ModItem
    {
        public override string Texture => Assets.GetTexture<UESSafeTravelsCommUnit>();

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("UES Safe Travels Comm Unit");
            Tooltip.SetDefault("Used to call down a variety of tactical drops from orbit");
        }

        public override void SetDefaults()
        {
            item.magic          = true;
            item.noMelee        = true;
            item.damage         = 100; //
            item.mana           = 40; //
            item.crit           = 4;
            item.knockBack      = 6;
            item.rare           = ItemRarityID.Red;
            item.value          = Item.sellPrice(gold: 12);
            item.Size           = ModContent.GetTexture(Texture).Size();
            item.useTime        = 10;
            item.useAnimation   = item.useTime;
            item.useStyle       = ItemUseStyleID.HoldingOut;
            item.UseSound       = SoundID.Item15;
            item.useTurn        = false; //
            //item.autoReuse      = true;
            //item.reuseDelay

            //channel
            //mech
            //shoot = ProjectileID.WireKite

            //item.CloneDefaults(ItemID.WireKite);
            //item.shoot = ProjectileID.None;
            //item.shootSpeed
            //item.mana = 10;
        }

        public override void AddRecipes()
        {
            // Make helper
            var recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.LunarBar, 8);
            recipe.AddIngredient(ItemID.FragmentNebula, 12);
            recipe.AddIngredient(ItemID.Sapphire);
            recipe.AddIngredient(ItemID.Wire, 50);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool AltFunctionUse(Player player) =>
            true;

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == ItemAlternativeFunctionID.ActivatedAndUsed)
            {
                // For once, something I do works.. I don't even care if this is a hacky way of doing this.
                if (PlayerInput.Triggers.JustPressed.MouseRight) //
                    // How incredibly verbose..
                    SandboxMod.Instance.GetLoader<UILoader>().GetUIState<CommUnitAbilitySelectionPanel>().IsVisible ^= true;

                //Main.Mouse

                return false;
            }

            return true;
        }

        //public override bool UseItem(Player player)
        //{
        //    if (player.altFunctionUse == ItemAlternativeFunctionID.ActivatedAndUsed)
        //    {
        //        // How incredibly verbose..
        //        SandboxMod.Instance.GetLoader<UILoader>().GetUIState<CommUnitAbilitySelectionPanel>().IsVisible ^= true;
        //    }
        //    else
        //    {
        //    }

        //    return true;
        //}
    }
}