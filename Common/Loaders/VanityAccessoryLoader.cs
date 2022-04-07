using SandboxMod.Content.Items.Accessories;
using System;
using System.Linq;
using System.Reflection;
using Terraria;
using Terraria.ModLoader;

namespace SandboxMod.Common.Loaders
{
    internal class VanityAccessoryLoader : ILoadable
    {
        // Enum?
        public float Priority => 1f;

        public void Load()
        {
            // Make condition
            if (Main.dedServ)
                return;

            foreach (Type type in SandboxMod.Instance.Code.GetTypes())
            {
                if (type.IsSubclassOf(typeof(ModItem)) && type.GetInterfaces().Contains(typeof(IVanityAccessoryItem)) && !type.IsAbstract)
                {
                    var modItem = (ModItem)typeof(ModContent)
                        .GetMethod(nameof(ModContent.GetInstance), BindingFlags.Static | BindingFlags.Public)
                        .MakeGenericMethod(type)
                        .Invoke(null, null);

                    SandboxMod.Instance.AddEquipTexture(((IVanityAccessoryItem)modItem).Head, null, EquipType.Head, modItem.Name, $"{modItem.Texture}_Head");
                    SandboxMod.Instance.AddEquipTexture(((IVanityAccessoryItem)modItem).Body, null, EquipType.Body, modItem.Name, $"{modItem.Texture}_Body", $"{modItem.Texture}_Arms");
                    SandboxMod.Instance.AddEquipTexture(((IVanityAccessoryItem)modItem).Legs, null, EquipType.Legs, modItem.Name, $"{modItem.Texture}_Legs");
                }
            }
        }

        public void Unload()
        {
        }
    }
}