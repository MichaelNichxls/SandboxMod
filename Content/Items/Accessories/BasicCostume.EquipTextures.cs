using SandboxMod.Content.Dusts;
using Terraria;
using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Accessories
{
    partial class BasicCostume
    {
        public class BasicCostumeHead : EquipTexture
        {
            public override bool DrawHead() =>
                false;

            public override bool IsVanitySet(int head, int body, int legs) =>
                body == mod.GetEquipSlot(Name, EquipType.Body)
                    && legs == mod.GetEquipSlot(Name, EquipType.Legs);

            public override void UpdateVanitySet(Player player)
            {
                if (Main.rand.NextBool(120))
                    Dust.NewDust(player.position, player.width, player.height, ModContent.DustType<BasicDust>());
            }
        }

        public class BasicCostumeBody : EquipTexture
        {
            public override bool DrawBody() =>
                false;
        }

        public class BasicCostumeLegs : EquipTexture
        {
            public override bool DrawLegs() =>
                false;
        }
    }
}