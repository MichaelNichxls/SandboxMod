using SandboxMod.Content.Items.Accessories;
using SandboxMod.Content.NPCs.Town;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

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
                Main.PlaySound(ModContent.GetInstance<BasicTownNPC>().npc.HitSound, player.position);
        }

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (IsActive)
                playSound = false;

            return base.PreKill(damage, hitDirection, pvp, ref playSound, ref genGore, ref damageSource);
        }

        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            if (IsActive)
                Main.PlaySound(ModContent.GetInstance<BasicTownNPC>().npc.DeathSound, player.position);
        }
    }
}