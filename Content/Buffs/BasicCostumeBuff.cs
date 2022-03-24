using SandboxMod.Common;
using SandboxMod.Common.Players;
using SandboxMod.Content.Items.Placeables.Tiles;
using Terraria;
using Terraria.ModLoader;

namespace SandboxMod.Content.Buffs
{
    public class BasicCostumeBuff : ModBuff
    {
        public override bool Autoload(ref string name, ref string texture)
        {
            texture = AssetDirectory.GetTexture<BasicCostumeBuff>();
            return base.Autoload(ref name, ref texture);
        }

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Basic Costume Buff");
            Description.SetDefault("Greatly increases jump speed and fall resistance"
                + $"\nOccasionally grants the player a {ModContent.GetInstance<BasicTile>().DisplayName.GetDefault()}");

            Main.debuff[Type]               = true;
            Main.buffNoSave[Type]           = true;
            Main.buffNoTimeDisplay[Type]    = true;

            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            var costumePlayer = player.GetModPlayer<CostumePlayer>();

            // BlockyAccessoryPrevious is used here instead of BlockyAccessory because UpdateBuffs happens before UpdateEquips but after ResetEffects.
            if (player.townNPCs >= 1 && costumePlayer.BlockyAccessoryPrevious)
            {
                costumePlayer.BlockyPower = true;

                player.jumpSpeedBoost   += 5f;
                player.extraFall        += 30;

                if (Main.myPlayer == player.whoAmI && Main.time % 1000 == 0)
                    player.QuickSpawnItem(ModContent.ItemType<BasicTile>());
            }
            else
                player.DelBuff(buffIndex--);
        }
    }
}