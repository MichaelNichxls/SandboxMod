using Microsoft.Xna.Framework;
using SandboxMod.Common;
using SandboxMod.Common.Players;
using SandboxMod.Content.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Accessories
{
    public partial class BasicCostume : ModItem, IVanityAccessoryItem
    {
        public override string Texture => Assets.GetTexture<BasicCostume>();

        public EquipTexture Head { get; } = new BasicCostumeHead();
        public EquipTexture Body { get; } = new BasicCostumeBody();
        public EquipTexture Legs { get; } = new BasicCostumeLegs();

        // I don't know a reliable way of getting some class' DisplayName while everything is still being initialized, so literals will do for now
        public override void SetStaticDefaults() =>
            Tooltip.SetDefault("Turns the holder into the Basic Town NPC near town NPCs");

        public override void SetDefaults()
        {
            item.accessory  = true;
            item.buffType   = ModContent.BuffType<BasicCostumeBuff>();
            item.rare       = ItemRarityID.Pink;
            item.Size       = new Vector2(16, 16);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var costumePlayer = player.GetModPlayer<BasicCostumePlayer>();

            costumePlayer.HasAccessoryEquipped  = true;
            costumePlayer.HasVanityHidden       = hideVisual;
        }
    }
}