using System;

namespace SandboxMod.Common
{
    // May rename and/or move class
    public static class AssetDirectory
    {
        public static string Get() => $"{nameof(SandboxMod)}/Assets/";
        public static string GetTexture(Type type) => type.GetType().FullName.Replace('.', '/').Replace("Content/", "Assets/Textures/");
        public static string GetTexture<T>() => typeof(T).FullName.Replace('.', '/').Replace("Content/", "Assets/Textures/");
    }
}