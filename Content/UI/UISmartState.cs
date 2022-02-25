using System.Collections.Generic;
using Terraria.UI;

namespace SandboxMod.Content.UI
{
    public abstract class UISmartState : UIState
    {
        // Probably should be abstract
        // Consider making this a setter as well
        public virtual bool Visible { get; set; } = false;
        public virtual string LayerName => nameof(SandboxMod) + ": Unknown";
        public virtual InterfaceScaleType ScaleType => InterfaceScaleType.UI;

        public abstract int GetInsertionIndex(List<GameInterfaceLayer> layers);
    }
}