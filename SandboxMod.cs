using SandboxMod.Core.Loaders;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader;
using Terraria.UI;

namespace SandboxMod
{
    public partial class SandboxMod : Mod
    {
        // Static?
        private readonly List<ILoadable> _loadCache = new List<ILoadable>();

        public static ModHotKey CycleUIHotKey { get; private set; }

        public override void Load()
        {
            foreach (Type type in Code.GetTypes())
            {
                // Use 'is' pattern matching
                if (!type.IsAbstract && type.GetInterfaces().Contains(typeof(ILoadable)))
                    _loadCache.Add((ILoadable)Activator.CreateInstance(type));
            }

            _loadCache.Sort((x, y) => x.Priority > y.Priority ? 1 : -1);

            foreach (ILoadable loadable in _loadCache)
                loadable.Load();

            // Move into its own Loader class
            CycleUIHotKey = RegisterHotKey("Cycle Through UIs", "T");
        }

        public override void Unload()
        {
            foreach (ILoadable loadable in _loadCache)
                loadable.Unload();

            _loadCache.Clear();
            CycleUIHotKey = null;
        }

        //public override void UpdateUI(GameTime gameTime)
        //{
        //    foreach (UserInterface userInterface in UILoader.UserInterfaces)
        //        userInterface.Update(gameTime);
        //}

        //public override void UpdateUI(GameTime gameTime)
        //{
        //    if (ExampleUI.Visible)
        //    {
        //        _exampleUserInterface?.Update(gameTime);
        //    }
        //    _exampleResourceBarUserInterface?.Update(gameTime);
        //    ExamplePersonUserInterface?.Update(gameTime);
        //}

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            for (int i = 0; i < UILoader.UserInterfaces.Count; i++)
                UILoader.InsertLayer(layers, UILoader.UserInterfaces[i], UILoader.UIStates[i]);
        }
    }
}