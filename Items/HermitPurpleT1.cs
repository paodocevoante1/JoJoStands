using Terraria.ID;
using Terraria.ModLoader;

namespace JoJoStands.Items
{
    public class HermitPurpleT1 : StandItemClass
    {
        public override int standSpeed => 40;
        public override int standType => 1;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hermit Purple (Tier 1)");
            Tooltip.SetDefault("Left-click to use Hermit Purple as a whip!\nUsed in Stand Slot");
        }

        public override void SetDefaults()
        {
            item.damage = 17;
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
            recipe.AddIngredient(mod.ItemType("StandArrow"));
            recipe.AddIngredient(mod.ItemType("WillToProtect"));
            recipe.AddTile(mod.TileType("RemixTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
