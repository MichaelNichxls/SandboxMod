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
                case MessageType.StatueTeleport:
                    if (Main.npc[reader.ReadByte()].modNPC is BasicTownNPC basicTownNPC && basicTownNPC.npc.active)
                        basicTownNPC.StatueTeleport();

                    break;
                default:
                    Logger.WarnFormat($"{Name}: Unknown message type: {messageType}");
                    break;
            }
        }
    }
}