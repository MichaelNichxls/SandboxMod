using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

namespace SandboxMod.Content.UI
{
    // internal?
    public class ButtonPanel : UISmartState
    {
        private readonly UIPanel _buttonPanel = new UIPanel();
        private readonly UIImage _playButton = new UIImage(ModContent.GetTexture("Terraria/UI/ButtonPlay"));

        public override bool IsVisible => true;

        // Make more concise
        public override int GetInsertionIndex(List<GameInterfaceLayer> layers) =>
            layers.FindIndex(layer => layer.Name == "Vanilla: Mouse Text");

        public override void OnInitialize()
        {
            // Make helper
            _buttonPanel.Left.Set((Main.screenWidth / 2f) + 20, 0);
            _buttonPanel.Top.Set((Main.screenHeight / 2f) - 80, 0);
            _buttonPanel.Width.Set(50, 0);
            _buttonPanel.Height.Set(50, 0);

            _playButton.HAlign = _playButton.VAlign = 0.5f;
            _buttonPanel.Append(_playButton);

            Append(_buttonPanel);
        }
    }
}