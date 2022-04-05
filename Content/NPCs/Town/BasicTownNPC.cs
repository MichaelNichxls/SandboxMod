using Microsoft.Xna.Framework;
using SandboxMod.Common;
using SandboxMod.Content.Dusts;
using SandboxMod.Content.Items.Accessories;
using SandboxMod.Content.Projectiles.NPCs.Town;
using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

using ModTileItems  = SandboxMod.Content.Items.Placeables.Tiles;
using ModTiles      = SandboxMod.Content.Tiles;
using ModWallItems  = SandboxMod.Content.Items.Placeables.Walls;
using ModWalls      = SandboxMod.Content.Walls;

namespace SandboxMod.Content.NPCs.Town
{
    [AutoloadHead]
    public class BasicTownNPC : ModNPC
    {
        public override string Texture => Assets.GetTexture<BasicTownNPC>();
        public override string[] AltTextures => new[] { $"{Texture}_Alt_1" };

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Basic Town NPC");

            Main.npcFrameCount[npc.type] = 25;

            NPCID.Sets.ExtraFramesCount[npc.type]       = 9;
            NPCID.Sets.AttackFrameCount[npc.type]       = 4;
            NPCID.Sets.DangerDetectRange[npc.type]      = 700;
            NPCID.Sets.AttackType[npc.type]             = 0;
            NPCID.Sets.AttackTime[npc.type]             = 90;
            NPCID.Sets.AttackAverageChance[npc.type]    = 30;
            NPCID.Sets.HatOffsetY[npc.type]             = 4;
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
            npc.HitSound        = SoundID.NPCHit3;
            npc.DeathSound      = SoundID.NPCDeath3;
            npc.aiStyle         = 7;

            animationType = NPCID.Guide;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int k = 0; k < (npc.life > 0 ? 1 : 5); k++)
                Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<BasicDust>());
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            for (int k = 0; k < byte.MaxValue; k++)
            {
                Player player = Main.player[k];

                if (!player.active)
                    continue;

                if (player.inventory.Any(item => item.type == ModContent.ItemType<ModTileItems.BasicTile>()
                    || item.type == ModContent.ItemType<ModTileItems.Furniture.BasicChair>()
                    || item.type == ModContent.ItemType<ModTileItems.Furniture.BasicWorkBench>()
                    || item.type == ModContent.ItemType<ModTileItems.Furniture.BasicDoor>()
                    || item.type == ModContent.ItemType<ModTileItems.Furniture.BasicTorch>()
                    || item.type == ModContent.ItemType<ModWallItems.BasicWall>()))
                {
                    return true;
                }
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
                    // Move inside if-statement?
                    Tile tile = Main.tile[x, y];

                    // Change to && ?
                    if (tile.type == ModContent.TileType<ModTiles.BasicTile>()
                        || tile.type == ModContent.TileType<ModTiles.Furniture.BasicChair>()
                        || tile.type == ModContent.TileType<ModTiles.Furniture.BasicWorkBench>()
                        || tile.type == ModContent.TileType<ModTiles.Furniture.BasicDoorOpen>()
                        || tile.type == ModContent.TileType<ModTiles.Furniture.BasicDoorClosed>()
                        || tile.type == ModContent.TileType<ModTiles.Furniture.BasicTorch>()
                        || tile.wall == ModContent.WallType<ModWalls.BasicWall>())
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

            // Make extension
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
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<ModTileItems.Furniture.BasicChair>());
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<ModTileItems.Furniture.BasicWorkBench>());
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<ModTileItems.Furniture.BasicDoor>());
            shop.item[nextSlot++].SetDefaults(ModContent.ItemType<ModTileItems.Furniture.BasicTorch>());
        }

        public override void NPCLoot() =>
            Item.NewItem(npc.getRect(), ModContent.ItemType<BasicCostume>());

        public override bool CanGoToStatue(bool toKingStatue) =>
            true;

        public override void OnGoToStatue(bool toKingStatue)
        {
            if (Main.netMode == NetmodeID.Server)
            {
                ModPacket packet = mod.GetPacket();

                packet.Write((byte)SandboxMod.MessageType.StatueTeleport);
                packet.Write((byte)npc.whoAmI);
                packet.Send();
            }
            else
                StatueTeleport();
        }

        public void StatueTeleport()
        {
            for (int k = 0; k < 15; k++)
            {
                Vector2 position = Main.rand.NextVector2Square(-20, 21);

                if (Math.Abs(position.X) > Math.Abs(position.Y))
                    position.X = Math.Sign(position.X) * 20;
                else
                    position.Y = Math.Sign(position.Y) * 20;

                Vector2 velocity = new Vector2(Utils.Clamp(position.X, -1, 1) + Main.rand.NextFloat(-0.75f, 0.75f), Utils.Clamp(position.Y, -1, 1) + Main.rand.NextFloat(-0.75f, 0.75f));
                Dust.NewDustPerfect(npc.Center + position, ModContent.DustType<BasicDust>(), velocity);
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage      = 20;
            knockback   = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown            = 30;
            randExtraCooldown   = 20;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType    = ModContent.ProjectileType<BasicProjectile>();
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier      = 12f;
            randomOffset    = 1f;
        }
    }
}