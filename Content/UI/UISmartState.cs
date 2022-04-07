using System.Collections.Generic;
using Terraria.UI;

namespace SandboxMod.Content.UI
{
    public abstract class UISmartState : UIState
    {
        public abstract bool IsVisible { get; } // GameInterfaceLayer.Active
        public virtual string LayerName => GetType().Name; // rename
        public virtual InterfaceScaleType ScaleType => InterfaceScaleType.UI;

        public string FullLayerName => $"{SandboxMod.Instance.Name}: {LayerName}"; //

        //public GameInterfaceLayer InterfaceLayer { get; set; } = new GameInterfaceLayer($"{SandboxMod.Instance.Name}: {GetType().Name}", InterfaceScaleType.UI);

        public abstract int GetInsertionIndex(List<GameInterfaceLayer> layers);
    }
}