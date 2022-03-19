﻿using System;

namespace SandboxMod.Common
{
    // May rename and/or move class
    internal static class AssetDirectory
    {
        public static string Get() =>
            $"{nameof(SandboxMod)}/Assets/";

        // in?
        public static string GetTexture(Type type) =>
            type.GetType().FullName.Replace('.', '/').Replace("Content/", "Assets/Textures/");

        public static string GetTexture<T>() =>
            typeof(T).FullName.Replace('.', '/').Replace("Content/", "Assets/Textures/");

        // Add overload that returns Texture2D
    }
}