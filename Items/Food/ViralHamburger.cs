using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JoJoStands.Items.Food
{
    public class ViralHamburger : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A regular ol' hamburger... but sprinkled with Viral Powder!\nGrants Stand related buffs upon consumption.");
        }

        public override void SetDefaults()
        {
            item.width = 10;
            item.height = 10;
            item.useTime = 20;
            item.useAnimation = 20;
            item.value = Item.buyPrice(0, 0, 60, 0);
            item.UseSound = SoundID.Item2;
            item.rare = ItemRarityID.Green;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.consumable = true;
        }

        public override bool UseItem(Player player)
        {
            return true;
        }

        public override void OnConsumeItem(Player player)
        {
            player.AddBuff(mod.BuffType("StrongWill"), (4 * 60) * 60);
            player.AddBuff(mod.BuffType("SharpMind"), (4 * 60) * 60);
            player.AddBuff(mod.BuffType("QuickThinking"), (4 * 60) * 60);
            player.AddBuff(mod.BuffType("MentalFortitude"), (4 * 60) * 60);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ViralPowder"), 4);
            recipe.AddIngredient(ItemID.Hay, 4);
            recipe.AddIngredient(ItemID.Vine, 5);
            recipe.AddIngredient(ItemID.Bunny);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
