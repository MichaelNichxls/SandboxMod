﻿namespace SandboxMod.Common
{
    public static class AssetDirectory
    {
        public const string Assets          = nameof(SandboxMod) + "/" + nameof(Assets) + "/";
        public const string Textures        = Assets + nameof(Textures) + "/";
        public const string MissingTexture  = Textures + nameof(MissingTexture);

        public const string Items               = Textures + nameof(Items) + "/";
        public const string AccessoryTextures   = Items + "Accessories/";
        public const string AmmoTextures_Item   = Items + "Ammo/";
        public const string ArmorTextures       = Items + "Armor/";
        public const string ToolTextures        = Items + "Tools/";
        public const string WeaponTextures      = Items + "Weapons/";

        public const string Projectiles             = Textures + nameof(Projectiles) + "/";
        public const string AmmoTextures_Projectile = Projectiles + "Ammo/";
    }
}