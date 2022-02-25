namespace SandboxMod.Core
{
    public static class AssetDirectory
    {
        private const string Assets     = nameof(SandboxMod) + "/" + nameof(Assets) + "/";
        private const string Textures   = Assets + nameof(Textures) + "/";
        private const string Items      = Textures + nameof(Items) + "/";

        public const string MissingTexture  = Textures + nameof(MissingTexture);
        public const string WeaponTextures  = Items + "Weapons/";
    }
}