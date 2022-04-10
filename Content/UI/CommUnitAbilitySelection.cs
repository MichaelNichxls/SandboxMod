using Microsoft.Xna.Framework;
using SandboxMod.Common;
using SandboxMod.Content.Items.Weapons;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

namespace SandboxMod.Content.UI
{
    // Rename?
    public class CommUnitAbilitySelection : UISmartState
    {
        // Instance.Assets.Request<Texture2D>();
        // SetState()

        public override bool IsVisible => Main.LocalPlayer.HeldItem?.type == ModContent.ItemType<UESSafeTravelsCommUnit>();

        // public?
        // Rename or make enum
        // Rename texture files?
        // Make spacing consistent throughout all files
        private readonly UIImage _orbitalProbe          = new UIImage(ModContent.GetTexture($"{Assets.TextureDirectory}UI/Selection_OrbitalProbe"));
        private readonly UIImage _diabloStrike          = new UIImage(ModContent.GetTexture($"{Assets.TextureDirectory}UI/Selection_DiabloStrike"));
        private readonly UIImage _orbitalSupplyBeacon   = new UIImage(ModContent.GetTexture($"{Assets.TextureDirectory}UI/Selection_OrbitalSupplyBeacon"));

        public override int GetInsertionIndex(List<GameInterfaceLayer> layers) =>
            layers.FindIndex(layer => layer.Name == "Vanilla: Wire Selection");

        public override void OnInitialize()
        {
            // Use object initializer
            //_orbitalProbe.Left.Set(Main.mouseX, 0);
            //_orbitalProbe.Top.Set(Main.mouseY + 40, 0);

            Append(_orbitalProbe);
            Append(_diabloStrike);
            Append(_orbitalSupplyBeacon);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            _orbitalProbe.Left.Set(Main.mouseX - 7, 0);
            _orbitalProbe.Top.Set(Main.mouseY + 20, 0);

            _diabloStrike.Left.Set(Main.mouseX + 5, 0);
            _diabloStrike.Top.Set(Main.mouseY + 20, 0);

            _orbitalSupplyBeacon.Left.Set(Main.mouseX + 17, 0);
            _orbitalSupplyBeacon.Top.Set(Main.mouseY + 20, 0);
            
            Recalculate();
        }
    }
}