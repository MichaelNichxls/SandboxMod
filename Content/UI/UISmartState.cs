using System.Collections.Generic;
using System.Text.RegularExpressions;
using Terraria.UI;

namespace SandboxMod.Content.UI
{
    public abstract class UISmartState : UIState
    {
        // ActivePredicate

        public GameInterfaceLayer InterfaceLayer { get; } // Remove, I guess

        public virtual bool IsVisible { get; set; } // Only getter?

        public virtual string LayerName => $"{SandboxMod.Instance.Name}: {Regex.Replace(GetType().Name, "([A-Z])", " $1").Trim()}";

        public UISmartState()
            : base() =>
            InterfaceLayer = new GameInterfaceLayer(LayerName, InterfaceScaleType.UI) { Active = false };

        public virtual int GetInsertionIndex(List<GameInterfaceLayer> layers) =>
            layers.FindIndex(layer => layer.Name == "Vanilla: Mouse Text");
    }
}