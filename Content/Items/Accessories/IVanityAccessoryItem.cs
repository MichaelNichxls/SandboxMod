using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Accessories
{
    // Move somewhere else
    public interface IVanityAccessoryItem
    {
        EquipTexture Head { get; }
        EquipTexture Body { get; }
        EquipTexture Legs { get; }
    }
}