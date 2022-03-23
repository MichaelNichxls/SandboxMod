using SandboxMod.Content.Buffs;
using SandboxMod.Content.Items.Armor.Vanity;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Common.Players
{
    // May rename
    public class CostumePlayer : ModPlayer
    {
        // May pack into struct or class
        // May change some visibilities
        // May rename to fit the boolean naming conventions
        public bool BlockyAccessoryPrevious { get; private set; }
        public bool BlockyAccessory { get; set; }
        public bool BlockyHideVanity { get; set; }
        public bool BlockyForceVanity { get; set; }
        public bool BlockyPower { get; set; }

        public override void ResetEffects()
        {
            BlockyAccessoryPrevious = BlockyAccessory;
            BlockyAccessory = BlockyHideVanity = BlockyForceVanity = BlockyPower = false;
        }

        public override void FrameEffects()
        {
            if ((BlockyPower || BlockyForceVanity) && !BlockyHideVanity)
            {
                // Get internal names
                player.head = mod.GetEquipSlot("BasicHead", EquipType.Head);
                player.body = mod.GetEquipSlot("BasicBody", EquipType.Body);
                player.legs = mod.GetEquipSlot("BasicLegs", EquipType.Legs);
            }
        }

        public override void ModifyDrawInfo(ref PlayerDrawInfo drawInfo)
        {
            if ((BlockyPower || BlockyForceVanity) && !BlockyHideVanity)
            {
                player.headRotation = player.velocity.Y * player.direction * 0.1f;
                player.headRotation = Utils.Clamp(player.headRotation, -0.3f, 0.3f);

                //if (player.InModBiome(ModContent.GetInstance<ExampleSurfaceBiome>()))
                //    player.headRotation = (float)Main.time * player.direction * 0.1f;
            }
        }

        public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff)
        {
            // Make sure this condition is the same as the condition in the Buff to remove itself.
            // This is done here instead of in ModItem.UpdateAccessory in case we want future upgraded items to set BlockyAccessory
            if (player.townNPCs >= 1 && BlockyAccessory)
                player.AddBuff(ModContent.BuffType<BasicCostumeBuff>(), 60);
        }

        public override void UpdateVanityAccessories()
        {
            // Make 13 and/or 18 const?
            for (int i = 13; i < 18 + player.extraAccessorySlots; i++)
            {
                Item armor = player.armor[i];

                if (armor.type == ModContent.ItemType<BasicCostume>())
                {
                    BlockyHideVanity    = false;
                    BlockyForceVanity   = true;
                }
            }
        }

        public override bool PreHurt(
            bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit,
            ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (BlockyAccessory)
                playSound = false;

            return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
        }

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (BlockyAccessory)
                Main.PlaySound(SoundID.Zombie, player.position, 13);
        }
    }
}