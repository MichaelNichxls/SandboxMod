using SandboxMod.Content.NPCs.Town;
using System.IO;
using Terraria;

namespace SandboxMod
{
    partial class SandboxMod
    {
        internal enum MessageType : byte
        {
            StatueTeleport
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            var messageType = (MessageType)reader.ReadByte();

            switch (messageType)
            {
                // Main.npc[reader.ReadByte()].modNPC

                case MessageType.StatueTeleport:
                    if (Main.npc[(byte)messageType].modNPC is BasicTownNPC basicTownNPC && basicTownNPC.npc.active)
                        basicTownNPC.StatueTeleport();

                    break;

                default:
                    Logger.Warn($"{Name}: Unknown message type of type `{messageType}`");
                    break;
            }
        }
    }
}