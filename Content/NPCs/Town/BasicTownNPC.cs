using Microsoft.Xna.Framework;
using SandboxMod.Common;
using SandboxMod.Content.Dusts;
using SandboxMod.Content.Items.Armor.Vanity;
using SandboxMod.Content.Tiles;
using SandboxMod.Content.Walls;
using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace SandboxMod.Content.NPCs.Town
{
    [AutoloadHead]
    public class BasicTownNPC : ModNPC
    {
        public override string Texture => AssetDirectory.GetTexture<BasicTownNPC>();
        //public override string[] AltTextures => new string[] { Texture + "_Alt_1" };

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Basic Town NPC");

            Main.npcFrameCount[npc.type] = 25;

            NPCID.Sets.ExtraFramesCount[npc.type]       = 9; // Generally for Town NPCs, but this is how the NPC does extra things such as sitting in a chair and talking to other NPCs.
            NPCID.Sets.AttackFrameCount[npc.type]       = 4;
            NPCID.Sets.DangerDetectRange[npc.type]      = 700; // The amount of pixels away from the center of the npc that it tries to attack enemies.
            NPCID.Sets.AttackType[npc.type]             = 0;
            NPCID.Sets.AttackTime[npc.type]             = 90; // The amount of time it takes for the NPC's attack animation to be over once it starts.
            NPCID.Sets.AttackAverageChance[npc.type]    = 30;
            NPCID.Sets.HatOffsetY[npc.type]             = 4; // For when a party is active, the party hat spawns at a Y offset.
        }

        public override void SetDefaults()
        {
            npc.townNPC         = true;
            npc.friendly        = true;
            npc.lifeMax         = 250;
            npc.damage          = 10;
            npc.defense         = 15;
            npc.knockBackResist = 0.5f;
            npc.Size            = new Vector2(18, 40);
            npc.HitSound        = SoundID.NPCHit1;
            npc.DeathSound      = SoundID.NPCDeath1;
            npc.aiStyle         = 7;

            animationType = NPCID.Guide;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < (npc.life > 0 ? 1 : 5); i++)
                Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<BasicDust>());
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            for (int i = 0; i < 255; i++)
            {
                Player player = Main.player[i];

                if (!player.active)
                    continue;

                // Create using
                if (player.inventory.Any(item => item.type == ModContent.ItemType<Items.Placeables.Tiles.BasicTile>()))
                    return true;
            }

            return false;
        }

        public override bool CheckConditions(int left, int right, int top, int bottom)
        {
            int score = 0;

            for (int x = left; x <= right; x++)
            {
                for (int y = top; y <= bottom; y++)
                {
                    Tile tile = Main.tile[x, y];

                    // Create group
                    if (tile.type == ModContent.TileType<BasicTile>()
                        || tile.type == ModContent.TileType<BasicChair>()
                        || tile.type == ModContent.TileType<BasicWorkBench>()
                        || tile.type == ModContent.TileType<BasicDoorOpen>()
                        || tile.type == ModContent.TileType<BasicDoorClosed>()
                        || tile.type == ModContent.TileType<BasicTorch>()
                        || tile.wall == ModContent.WallType<BasicWall>())
                    {
                        score++;
                    }
                }
            }

            return score >= (right - left) * (bottom - top) / 2;
        }

        public override string TownNPCName()
        {
            return new WeightedRandom<string>(WorldGen.genRand, new[]
            {
                new Tuple<string, double>("Somebody",   1.0),
                new Tuple<string, double>("Someone",    1.0),
                new Tuple<string, double>("Pixel",      1.0),
                new Tuple<string, double>("Blocky",     1.0),
                new Tuple<string, double>("Blank",      1.0),
                new Tuple<string, double>("Colorless",  1.0),
                new Tuple<string, double>("Unknown",    0.75),
                new Tuple<string, double>("Undefined",  0.5),
                new Tuple<string, double>("Null",       0.25)
            });
        }

        public override string GetChat()
        {
            var chat = new WeightedRandom<string>(new[]
            {
                new Tuple<string, double>("What's your favorite color? Mine are white and black.",                                                                                              1.0),
                new Tuple<string, double>("Sometimes, I feel like I'm different from everybody else here.",                                                                                     1.0),
                new Tuple<string, double>("What? I don't have any arms or legs? Oh, don't be ridiculous!",                                                                                      1.0),
                new Tuple<string, double>("I think I should take up croquet as a hobby. It seems relaxing.",                                                                                    1.0),
                new Tuple<string, double>("Do you ever wonder if you're living in a simulation? Or even a game?",                                                                               0.5),
                new Tuple<string, double>("My curiosity often leads me to exploring places I don't think I should be in. Something about this world seems off-putting, yet enticing to me.",    0.25),
                new Tuple<string, double>("Am I a butterfly dreaming I'm a man? Or a bowling ball dreaming I'm a plate of sashimi? Never assume that what you see and feel is real.",           0.1)
            });

            if (NPC.FindFirstNPC(NPCID.PartyGirl) is var partyGirl && partyGirl >= 0)
                chat.Add($"Can you please tell {Main.npc[partyGirl].GivenName} to stop decorating my house with colors?", 0.25);

            return chat;
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button  = Language.GetTextValue("LegacyInterface.28");
            button2 = "Crack";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
                shop = true;
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
        }

        public override void NPCLoot() =>
            Item.NewItem(npc.getRect(), ModContent.ItemType<BasicCostume>());

        public override bool CanGoToStatue(bool toKingStatue) =>
            true;

        public override void OnGoToStatue(bool toKingStatue)
        {
            //if (Main.netMode == NetmodeID.Server)
            //{
            //    ModPacket packet = mod.GetPacket();

            //    packet.Write((byte)SandboxMod.MessageType.ExampleTeleportToStatue);
            //    packet.Write((byte)NPC.whoAmI);
            //    packet.Send();
            //}
            //else
            //{
            //    StatueTeleport();
            //}
        }

        //public void StatueTeleport()
        //{
        //    for (int i = 0; i < 30; i++)
        //    {
        //        Vector2 position = Main.rand.NextVector2Square(-20, 21);
        //        if (Math.Abs(position.X) > Math.Abs(position.Y))
        //        {
        //            position.X = Math.Sign(position.X) * 20;
        //        }
        //        else
        //        {
        //            position.Y = Math.Sign(position.Y) * 20;
        //        }
        //        Dust.NewDustPerfect(npc.Center + position, ModContent.DustType<BasicDust>(), Vector2.Zero).noGravity = true;
        //    }
        //}

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            //damage = 20;
            //knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            //cooldown = 30;
            //randExtraCooldown = 30;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            //projType = ModContent.ProjectileType<SparklingBall>();
            //attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            //multiplier = 12f;
            //randomOffset = 2f;
        }
    }
}