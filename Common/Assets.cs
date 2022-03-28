using System;
using Terraria.ModLoader;

namespace SandboxMod.Common
{
    internal static class Assets
    {
        public static string Directory          => $"{SandboxMod.Instance.Name}/Assets/";
        public static string TextureDirectory   => $"{Directory}Textures/";

        public static string GetTexture(Type type) =>
            type.FullName.Replace('.', '/').Replace($"{SandboxMod.Instance.Name}/Content/", TextureDirectory) is var texture && ModContent.TextureExists(texture)
                ? texture
                : $"{TextureDirectory}MissingTexture";

        public static string GetTexture<T>() =>
            GetTexture(typeof(T));
    }
}