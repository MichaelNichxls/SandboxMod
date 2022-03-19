﻿using Microsoft.Xna.Framework;
using SandboxMod.Common;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SandboxMod.Content.NPCs
{
    public class BasicNPC : ModNPC
    {
        public override string Texture => AssetDirectory.GetTexture<BasicNPC>();

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Basic NPC");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
        }

        public override void SetDefaults()
        {
            npc.lifeMax         = 70;
            npc.damage          = 14;
            npc.defense         = 6;
            npc.knockBackResist = 0.5f;
            npc.value           = 80f;
            npc.Size            = new Vector2(18, 40); // Should have a consistent way of automatically getting this, if possible
            npc.HitSound        = SoundID.NPCHit1;
            npc.DeathSound      = SoundID.NPCDeath2;
            npc.aiStyle         = 3;

            aiType          = NPCID.Zombie;
            animationType   = NPCID.Zombie;
            banner          = Item.NPCtoBanner(NPCID.Zombie);
            bannerItem      = Item.BannerToItem(banner);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) =>
            SpawnCondition.OverworldNightMonster.Chance * 0.1f;

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++)
            {
                var dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, Main.rand.Next(4) + DustID.Confetti);

                dust.velocity.X += Main.rand.NextFloat(-0.05f, 0.05f);
                dust.velocity.Y += Main.rand.NextFloat(-0.05f, 0.05f);
                dust.scale      *= Main.rand.NextFloat(-0.03f, 0.03f) + 1f;
            }
        }
    }
}