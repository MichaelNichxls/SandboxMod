using Microsoft.Xna.Framework;
using SandboxMod.Content.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace SandboxMod.Core.Loaders
{
    internal class UILoader : ILoadable
    {
        // Dictionary or Tuple
        // And these two fields should probably be relocated somewhere else
        public static List<UserInterface> UserInterfaces { get; private set; } = new List<UserInterface>();
        public static List<UISmartState> UIStates { get; private set; } = new List<UISmartState>();

        public float Priority => 1f;

        public void Load()
        {
            if (Main.dedServ)
                return;

            foreach (Type type in ModContent.GetInstance<SandboxMod>().Code.GetTypes())
            {
                if (!type.IsAbstract && type.IsSubclassOf(typeof(UISmartState)))
                {
                    var userInterface = new UserInterface();
                    var state = (UISmartState)Activator.CreateInstance(type);

                    state.Activate();
                    userInterface.SetState(state);

                    UserInterfaces.Add(userInterface);
                    UIStates.Add(state);
                }
            }
        }

        public void Unload()
        {
            UserInterfaces = null;
            UIStates = null;
        }

        public static void InsertLayer(List<GameInterfaceLayer> layers, UserInterface userInterface, UISmartState state)
        {
            if (state.GetInsertionIndex(layers) is var index && index != -1)
            {
                layers.Insert(index, new LegacyGameInterfaceLayer(
                    state.LayerName,
                    () =>
                    {
                        if (state.Visible)
                            userInterface.Draw(Main.spriteBatch, new GameTime());

                        return true;
                    },
                    state.ScaleType));
            }
        }

        public static T GetUIState<T>()
            where T : UISmartState =>
            UIStates.FirstOrDefault(state => state is T) as T;

        //public static void ReloadState<T>() where T : SmartUIState
        //{
        //    var index = UIStates.IndexOf(GetUIState<T>());
        //    UIStates[index] = (T)Activator.CreateInstance(typeof(T), null);
        //    UserInterfaces[index] = new UserInterface();
        //    UserInterfaces[index].SetState(UIStates[index]);
        //}
    }
}