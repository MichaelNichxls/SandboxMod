using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace SandboxMod
{
    public partial class SandboxMod : Mod
    {
        public override void AddRecipeGroups()
        {
            var group = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Evil Bar", new int[]
            {
                ItemID.DemoniteBar,
                ItemID.CrimtaneBar
            });
            RecipeGroup.RegisterGroup($"{nameof(SandboxMod)}:EvilBar", group);

            // etc.
        }
    }
}