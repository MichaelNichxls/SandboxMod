using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class BasicHelmet : ModItem
    {
        public override string Texture => Assets.GetTexture<BasicHelmet>();

        public override void SetStaticDefaults() =>
            Tooltip.SetDefault("A basic helmet");

        public override void SetDefaults()
        {
            item.defense    = 8;
            item.rare       = ItemRarityID.Blue;
            item.value      = Item.sellPrice(silver: 22);
            item.Size       = ModContent.GetTexture(Texture).Size();
        }

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.PlatinumBar, 18);
            recipe.AddIngredient(ModContent.ItemType<BasicItem>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) =>
            body.type == ModContent.ItemType<BasicBreastplate>()
                && legs.type == ModContent.ItemType<BasicLeggings>();

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "12% increased damage"
                + "\nGrants immunity to On Fire! and Chilled";

            player.allDamage                    += 0.12f;
            player.buffImmune[BuffID.OnFire]    = true;
            player.buffImmune[BuffID.Chilled]   = true;
        }
    }
}