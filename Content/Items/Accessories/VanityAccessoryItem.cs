using Terraria.ModLoader;

namespace SandboxMod.Content.Items.Accessories
{
    public abstract class VanityAccessoryItem : ModItem
    {
        public virtual EquipTexture Head { get; } = new EquipTexture();
        public virtual EquipTexture Body { get; } = new EquipTexture();
        public virtual EquipTexture Legs { get; } = new EquipTexture();
    }
}