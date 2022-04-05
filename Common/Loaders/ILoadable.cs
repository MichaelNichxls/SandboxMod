namespace SandboxMod.Common.Loaders
{
    internal interface ILoadable
    {
        float Priority { get; }

        void Load();
        void Unload();
    }
}