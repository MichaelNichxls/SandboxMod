using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;

namespace SandboxMod.Content.UI
{
    // internal?
    // Adopt a more simple name
    // Merge
    public class CommUnitAbilitySelectionPanel : UISmartState
    {
        //private readonly UIPanel _buttonPanel = new UIPanel();
        //private readonly UIImage _playButton = new UIImage(ModContent.GetTexture("Terraria/UI/ButtonPlay"));

        private readonly UIImageButton _orbitalProbeButton = new UIImageButton(ModContent.GetTexture("Terraria/UI/Wires_0"));
        private readonly UIImageButton _orbitalProbeButton_Highlight = new UIImageButton(ModContent.GetTexture("Terraria/UI/Wires_1"));

        public override void OnInitialize()
        {
            // Make helper
            _orbitalProbeButton.Left.Set((Main.screenWidth / 2f) + 20, 0);
            _orbitalProbeButton.Top.Set((Main.screenHeight / 2f) - 80, 0);
            //_button.Width.Set(50, 0);
            //_button.Height.Set(50, 0);

            Append(_orbitalProbeButton);
        }
    }
}