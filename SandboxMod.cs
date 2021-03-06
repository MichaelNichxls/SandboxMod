using SandboxMod.Common.Extensions;
using SandboxMod.Common.Loaders;
using SandboxMod.Content.Tiles.Furniture;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace SandboxMod
{
    public partial class SandboxMod : Mod
    {
        private readonly List<ILoadable> _loaderCache = new List<ILoadable>();

        public static SandboxMod Instance { get; private set; }
        public bool HasLoaded { get; private set; }

        public SandboxMod() => Instance = this;

        internal TLoader GetLoader<TLoader>()
            where TLoader : class, ILoadable
        {
            return _loaderCache.FirstOrDefault(loader => loader is TLoader) as TLoader;
        }

        public override void Load()
        {
            if (HasLoaded)
                return;

            _loaderCache.AddRange(Code
                .GetTypes()
                .Where(type => type.GetInterfaces().Contains(typeof(ILoadable)) && !type.IsAbstract)
                .Select(type => (ILoadable)Activator.CreateInstance(type)));
            _loaderCache.Sort((x, y) => x.Priority > y.Priority ? 1 : -1);
            _loaderCache.ForEach(loader => loader.Load());

            HasLoaded = true;
        }

        public override void Unload()
        {
            if (!HasLoaded)
                return;

            _loaderCache.ForEach(loader => loader.Unload());
            _loaderCache.Clear();

            if (!Main.dedServ)
                Instance = null;

            HasLoaded = false;
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            var uiLoader = GetLoader<UILoader>();

            for (int k = 0; k < uiLoader?.UserInterfaces.Count; k++)
                uiLoader.InsertLayer(layers, uiLoader.UserInterfaces[k], uiLoader.UIStates[k]);
        }

        // Move
        public override void AddRecipes()
        {
            #region Pre-Hardmode Ores
            // Make helper
            var recipe = new ModRecipe(this);

            recipe.AddIngredient(ItemID.CopperOre);
            recipe.AddTile(ModContent.TileType<MaterialTransmuter>());
            recipe.SetResult(ItemID.TinOre);
            recipe.AddBidirectionalRecipe();

            recipe = new ModRecipe(this);

            recipe.AddIngredient(ItemID.CopperBar);
            recipe.AddTile(ModContent.TileType<MaterialTransmuter>());
            recipe.SetResult(ItemID.TinBar);
            recipe.AddBidirectionalRecipe();

            recipe = new ModRecipe(this);

            recipe.AddIngredient(ItemID.IronOre);
            recipe.AddTile(ModContent.TileType<MaterialTransmuter>());
            recipe.SetResult(ItemID.LeadOre);
            recipe.AddBidirectionalRecipe();

            recipe = new ModRecipe(this);

            recipe.AddIngredient(ItemID.IronBar);
            recipe.AddTile(ModContent.TileType<MaterialTransmuter>());
            recipe.SetResult(ItemID.LeadBar);
            recipe.AddBidirectionalRecipe();

            recipe = new ModRecipe(this);

            recipe.AddIngredient(ItemID.SilverOre);
            recipe.AddTile(ModContent.TileType<MaterialTransmuter>());
            recipe.SetResult(ItemID.TungstenOre);
            recipe.AddBidirectionalRecipe();

            recipe = new ModRecipe(this);

            recipe.AddIngredient(ItemID.SilverBar);
            recipe.AddTile(ModContent.TileType<MaterialTransmuter>());
            recipe.SetResult(ItemID.TungstenBar);
            recipe.AddBidirectionalRecipe();

            recipe = new ModRecipe(this);

            recipe.AddIngredient(ItemID.GoldOre);
            recipe.AddTile(ModContent.TileType<MaterialTransmuter>());
            recipe.SetResult(ItemID.PlatinumOre);
            recipe.AddBidirectionalRecipe();

            recipe = new ModRecipe(this);

            recipe.AddIngredient(ItemID.GoldBar);
            recipe.AddTile(ModContent.TileType<MaterialTransmuter>());
            recipe.SetResult(ItemID.PlatinumBar);
            recipe.AddBidirectionalRecipe();

            recipe = new ModRecipe(this);

            recipe.AddIngredient(ItemID.DemoniteOre);
            recipe.AddTile(ModContent.TileType<MaterialTransmuter>());
            recipe.SetResult(ItemID.CrimtaneOre);
            recipe.AddBidirectionalRecipe();

            recipe = new ModRecipe(this);

            recipe.AddIngredient(ItemID.DemoniteBar);
            recipe.AddTile(ModContent.TileType<MaterialTransmuter>());
            recipe.SetResult(ItemID.CrimtaneBar);
            recipe.AddBidirectionalRecipe();
            #endregion Pre-Hardmode Ores
            #region Hardmode Ores
            recipe = new ModRecipe(this);

            recipe.AddIngredient(ItemID.CobaltOre);
            recipe.AddTile(ModContent.TileType<MaterialTransmuter>());
            recipe.SetResult(ItemID.PalladiumOre);
            recipe.AddBidirectionalRecipe();

            recipe = new ModRecipe(this);

            recipe.AddIngredient(ItemID.CobaltBar);
            recipe.AddTile(ModContent.TileType<MaterialTransmuter>());
            recipe.SetResult(ItemID.PalladiumBar);
            recipe.AddBidirectionalRecipe();

            recipe = new ModRecipe(this);

            recipe.AddIngredient(ItemID.MythrilOre);
            recipe.AddTile(ModContent.TileType<MaterialTransmuter>());
            recipe.SetResult(ItemID.OrichalcumOre);
            recipe.AddBidirectionalRecipe();

            recipe = new ModRecipe(this);

            recipe.AddIngredient(ItemID.MythrilBar);
            recipe.AddTile(ModContent.TileType<MaterialTransmuter>());
            recipe.SetResult(ItemID.OrichalcumBar);
            recipe.AddBidirectionalRecipe();

            recipe = new ModRecipe(this);

            recipe.AddIngredient(ItemID.AdamantiteOre);
            recipe.AddTile(ModContent.TileType<MaterialTransmuter>());
            recipe.SetResult(ItemID.TitaniumOre);
            recipe.AddBidirectionalRecipe();

            recipe = new ModRecipe(this);

            recipe.AddIngredient(ItemID.AdamantiteBar);
            recipe.AddTile(ModContent.TileType<MaterialTransmuter>());
            recipe.SetResult(ItemID.TitaniumBar);
            recipe.AddBidirectionalRecipe();
            #endregion Hardmode Ores
            #region Etc.
            recipe = new ModRecipe(this);

            recipe.AddIngredient(ItemID.ShadowScale);
            recipe.AddTile(ModContent.TileType<MaterialTransmuter>());
            recipe.SetResult(ItemID.TissueSample);
            recipe.AddBidirectionalRecipe();

            recipe = new ModRecipe(this);

            recipe.AddIngredient(ItemID.UnholyWater);
            recipe.AddTile(ModContent.TileType<MaterialTransmuter>());
            recipe.SetResult(ItemID.BloodWater);
            recipe.AddBidirectionalRecipe();

            recipe = new ModRecipe(this);

            recipe.AddIngredient(ItemID.CursedFlame);
            recipe.AddTile(ModContent.TileType<MaterialTransmuter>());
            recipe.SetResult(ItemID.Ichor);
            recipe.AddBidirectionalRecipe();

            recipe = new ModRecipe(this);

            recipe.AddIngredient(ItemID.FlaskofCursedFlames);
            recipe.AddTile(ModContent.TileType<MaterialTransmuter>());
            recipe.SetResult(ItemID.FlaskofIchor);
            recipe.AddBidirectionalRecipe();

            // etc.
            #endregion Etc.
        }

        public override void AddRecipeGroups()
        {
            var group = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} Evil Bar", new int[]
            {
                ItemID.DemoniteBar,
                ItemID.CrimtaneBar
            });

            RecipeGroup.RegisterGroup($"{nameof(SandboxMod)}:EvilBar", group);
            // etc.
        }
    }
}