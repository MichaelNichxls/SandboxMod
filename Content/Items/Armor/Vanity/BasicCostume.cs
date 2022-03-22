using Microsoft.Xna.Framework;
using SandboxMod.Common;
using SandboxMod.Common.Players;
using SandboxMod.Content.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Armor.Vanity
{
    public class BasicCostume : ModItem
    {
        public override string Texture => AssetDirectory.GetTexture<BasicCostume>();

        public override void SetStaticDefaults() =>
            Tooltip.SetDefault("Turns the holder into Blocky"); // Update

        public override void SetDefaults()
        {
            item.accessory  = true;
            item.rare       = ItemRarityID.Pink;
            item.value      = Item.buyPrice(gold: 15); // vs. Item.sellPrice()
            item.Size       = new Vector2(16, 16);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var costumePlayer = player.GetModPlayer<CostumePlayer>();

            costumePlayer.BlockyAccessory   = true;
            costumePlayer.BlockyHideVanity  = hideVisual;
        }
    }

    // Move
    public class BasicHead : EquipTexture
    {
        public override bool DrawHead() =>
            false;

        public override void UpdateVanitySet(Player player)
        {
            if (Main.rand.NextBool(20))
                Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<BasicDust>());
        }
    }

    public class BasicBody : EquipTexture
    {
        public override bool DrawBody() =>
            false;
    }

    public class BasicLegs : EquipTexture
    {
        public override bool DrawLegs() =>
            false;
    }
}