using Microsoft.Xna.Framework;
using SandboxMod.Common;
using SandboxMod.Common.Players;
using SandboxMod.Content.Dusts;
using SandboxMod.Content.NPCs.Town;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Armor.Vanity
{
    public class BasicCostume : ModItem
    {
        public override string Texture => AssetDirectory.GetTexture<BasicCostume>();

        public override void SetStaticDefaults() =>
            Tooltip.SetDefault($"Turns the holder into the {ModContent.GetInstance<BasicTownNPC>().DisplayName.GetDefault()} near town NPCs"); // Doesn't work

        public override void SetDefaults()
        {
            item.accessory  = true;
            item.rare       = ItemRarityID.Pink;
            item.value      = Item.buyPrice(gold: 15);
            item.Size       = new Vector2(16, 16);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var costumePlayer = player.GetModPlayer<CostumePlayer>();

            costumePlayer.BlockyAccessory   = true;
            costumePlayer.BlockyHideVanity  = hideVisual;
        }
    }

    // Move into separate file
    // Could probably be simplified
    public class BasicHead : EquipTexture
    {
        public override bool DrawHead() =>
            false;

        // UpdateVanitySet() for the hell of it
        public override void UpdateVanity(Player player, EquipType type)
        {
            if (Main.rand.NextBool(120))
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