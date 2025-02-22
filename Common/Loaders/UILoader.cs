﻿using SandboxMod.Content.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.UI;

namespace SandboxMod.Common.Loaders
{
    internal class UILoader : ILoadable
    {
        public float Priority => 1.1f;

        // Dictionary/Tuple?
        public List<UserInterface> UserInterfaces { get; } = new List<UserInterface>();
        public List<UISmartState> UIStates { get; } = new List<UISmartState>();

        public void Load()
        {
            if (Main.dedServ)
                return;

            foreach (Type type in SandboxMod.Instance.Code.GetTypes())
            {
                if (type.IsSubclassOf(typeof(UISmartState)) && !type.IsAbstract)
                {
                    var userInterface   = new UserInterface();
                    var state           = (UISmartState)Activator.CreateInstance(type);

                    state.Activate();
                    userInterface.SetState(state);

                    UserInterfaces.Add(userInterface);
                    UIStates.Add(state);
                }
            }
        }

        public void Unload()
        {
            UserInterfaces.Clear();
            UIStates.Clear();
        }

        // Bracing
        public void InsertLayer(List<GameInterfaceLayer> layers, UserInterface userInterface, UISmartState state)
        {
            if (state.GetInsertionIndex(layers) is var index && index != -1)
            {
                layers.Insert(index, new LegacyGameInterfaceLayer(
                    state.InterfaceLayer.Name,
                    () =>
                    {
                        //if (state.IsVisible)
                        //    userInterface.Draw(Main.spriteBatch, new GameTime());

                        if (state.IsVisible) // state.InterfaceLayer.Active // ?
                        {
                            userInterface.Update(Main._drawInterfaceGameTime);
                            state.Draw(Main.spriteBatch);
                        }

                        return true;
                    },
                    state.InterfaceLayer.ScaleType));
            }
        }

        public TUIState GetUIState<TUIState>()
            where TUIState : UISmartState
        {
            return UIStates.FirstOrDefault(state => state is TUIState) as TUIState;
        }

        //public static void ReloadState<T>() where T : SmartUIState
        //{
        //    var index = UIStates.IndexOf(GetUIState<T>());
        //    UIStates[index] = (T)Activator.CreateInstance(typeof(T), null);
        //    UserInterfaces[index] = new UserInterface();
        //    UserInterfaces[index].SetState(UIStates[index]);
        //}
    }
}