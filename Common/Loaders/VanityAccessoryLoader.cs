using SandboxMod.Content.Items.Accessories;
using System;
using System.Reflection;
using Terraria;
using Terraria.ModLoader;

namespace SandboxMod.Common.Loaders
{
    public class VanityAccessoryLoader : ILoadable
    {
        public float Priority => 1f;

        public void Load()
        {
            // May make condition
            if (!Main.dedServ)
            {
                foreach (Type type in SandboxMod.Instance.Code.GetTypes())
                {
                    if (type.IsSubclassOf(typeof(VanityAccessoryItem)) && !type.IsAbstract)
                    {
                        var modItem = (VanityAccessoryItem)typeof(ModContent)
                            .GetMethod(nameof(ModContent.GetInstance), BindingFlags.Static | BindingFlags.Public)
                            .MakeGenericMethod(type)
                            .Invoke(null, null);

                        SandboxMod.Instance.AddEquipTexture(modItem.Head, null, EquipType.Head, modItem.Name, $"{modItem.Texture}_Head");
                        SandboxMod.Instance.AddEquipTexture(modItem.Body, null, EquipType.Body, modItem.Name, $"{modItem.Texture}_Body", $"{modItem.Texture}_Arms");
                        SandboxMod.Instance.AddEquipTexture(modItem.Legs, null, EquipType.Legs, modItem.Name, $"{modItem.Texture}_Legs");
                    }
                }
            }
        }

        public void Unload()
        {
        }
    }
}