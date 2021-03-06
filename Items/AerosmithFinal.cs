using Terraria.ID;
using Terraria.ModLoader;

namespace JoJoStands.Items
{
    public class AerosmithFinal : StandItemClass
    {
        public override int standType => 2;
        public override int standSpeed => 6;

        public override string Texture
        {
            get { return mod.Name + "/Items/AerosmithT1"; }
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aerosmith (Final Tier)");
            Tooltip.SetDefault("Left-click to move and right-click to shoot bullets at the enemies!\nSpecial: Drop a bomb on enemies!\nPassive: Carbon Radar\nUsed in Stand Slot");
        }

        public override void SetDefaults()
        {
            item.damage = 75;
            item.width = 32;
            item.height = 32;
            item.maxStack = 1;
            item.value = 0;
            item.noUseGraphic = true;
            item.rare = ItemRarityID.LightPurple;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("AerosmithT3"));
            recipe.AddIngredient(ItemID.ShroomiteBar, 10);
            recipe.AddIngredient(ItemID.MartianConduitPlating, 75);
            recipe.AddIngredient(mod.ItemType("CaringLifeforce"));
            recipe.AddIngredient(mod.ItemType("WillToProtect"), 2);
            recipe.AddTile(mod.TileType("RemixTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
