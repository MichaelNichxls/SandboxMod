namespace SandboxMod.Core.Loaders
{
    internal interface ILoadable
    {
        float Priority { get; }

        void Load();
        void Unload();
    }
}