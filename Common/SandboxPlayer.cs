using SandboxMod.Common.Loaders;
using Terraria.GameInput;
using Terraria.ModLoader;

namespace SandboxMod.Common
{
    public class SandboxPlayer : ModPlayer
    {
        // Rename
        private int _selectedUIIndex = 0;

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            // Rewrite and refactor
            // using static?
            if (SandboxMod.CycleUIHotKey.JustPressed)
            {
                UILoader.UIStates[_selectedUIIndex - 1 >= 0 ? _selectedUIIndex - 1 : _selectedUIIndex].Visible = false;

                if (_selectedUIIndex < UILoader.UIStates.Count)
                    UILoader.UIStates[_selectedUIIndex++].Visible = true;
                else
                    _selectedUIIndex -= UILoader.UIStates.Count;
            }
        }
    }
}