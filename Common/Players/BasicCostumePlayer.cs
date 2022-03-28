using SandboxMod.Content.Items.Accessories;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace SandboxMod.Common.Players
{
    public class BasicCostumePlayer : VanityAccessoryPlayer<BasicCostume>
    {
        public override Func<bool> BuffPredicate => () => player.townNPCs >= 1;

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit,
            ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (IsActive)
                playSound = false;

            return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
        }

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (IsActive)
                Main.PlaySound(SoundID.NPCHit, player.position);
        }
    }
}