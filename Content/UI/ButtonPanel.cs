using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace SandboxMod.Content.UI
{
    internal class ButtonPanel : UISmartState
    {
        private readonly UIPanel _buttonPanel = new UIPanel();
        private readonly UIImage _playButton = new UIImage(ModContent.GetTexture("Terraria/UI/ButtonPlay"));

        public override string LayerName => nameof(SandboxMod) + ": Button Panel";

        public override int GetInsertionIndex(List<GameInterfaceLayer> layers) =>
            layers.FindIndex(layer => layer.Name == "Vanilla: Mouse Text");

        public override void OnInitialize()
        {
            // Make helper
            _buttonPanel.Left.Set((Main.screenWidth / 2f) + 20, 0);
            _buttonPanel.Top.Set((Main.screenHeight / 2f) - 60, 0);
            _buttonPanel.Width.Set(40, 0);
            _buttonPanel.Height.Set(40, 0);

            _playButton.HAlign = 1 / 2f;
            _playButton.VAlign = 1 / 2f;
            _playButton.OnClick += new MouseEvent(PlayButton_OnClick);
            _buttonPanel.Append(_playButton);

            Append(_buttonPanel);
        }

        private void PlayButton_OnClick(UIMouseEvent evt, UIElement listeningElement) =>
            Main.PlaySound(SoundID.MenuOpen);
    }
}