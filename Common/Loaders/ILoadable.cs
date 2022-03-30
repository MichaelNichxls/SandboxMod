namespace SandboxMod.Common.Loaders
{
    // ILoader?
    internal interface ILoadable
    {
        float Priority { get; }

        void Load();
        void Unload();
    }
}