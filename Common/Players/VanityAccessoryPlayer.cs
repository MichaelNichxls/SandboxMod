using System;
using Terraria.ModLoader;

namespace SandboxMod.Common.Players
{
    // rename to VanityAccessoryBuffPlayer? I don't know
    public abstract class VanityAccessoryPlayer<TModItem> : ModPlayer
        where TModItem : ModItem
    {
        public virtual Func<bool> BuffPredicate => () => true;

        public bool IsActive => (HasBuff || HasVanityForced) && !HasVanityHidden;
        public bool HasAccessoryEquippedPrevious { get; private set; }
        public bool HasAccessoryEquipped { get; set; }
        public bool HasVanityHidden { get; set; }
        public bool HasVanityForced { get; set; }
        public bool HasBuff { get; set; }

        public override void ResetEffects()
        {
            HasAccessoryEquippedPrevious = HasAccessoryEquipped;
            HasAccessoryEquipped = HasVanityHidden = HasVanityForced = HasBuff = false;
        }

        public override void FrameEffects()
        {
            if (!IsActive)
                return;

            var modItem = ModContent.GetInstance<TModItem>();

            if (mod.GetEquipSlot(modItem.Name, EquipType.Head) is var headEquipSlot && headEquipSlot != -1)
                player.head = headEquipSlot;

            if (mod.GetEquipSlot(modItem.Name, EquipType.Body) is var bodyEquipSlot && bodyEquipSlot != -1)
                player.body = bodyEquipSlot;

            if (mod.GetEquipSlot(modItem.Name, EquipType.Legs) is var legsEquipSlot && legsEquipSlot != -1)
                player.legs = legsEquipSlot;
        }

        public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff)
        {
            if (HasAccessoryEquipped && BuffPredicate())
                player.AddBuff(ModContent.GetInstance<TModItem>().item.buffType, 60);
        }

        public override void UpdateVanityAccessories()
        {
            for (int k = 13; k < 18 + player.extraAccessorySlots; k++)
            {
                if (player.armor[k].type == ModContent.ItemType<TModItem>())
                {
                    HasVanityHidden = false;
                    HasVanityForced = true;
                }
            }
        }
    }
}