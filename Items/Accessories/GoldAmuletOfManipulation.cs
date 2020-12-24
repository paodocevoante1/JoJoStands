using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace JoJoStands.Items.Accessories
{
    public class GoldAmuletOfManipulation : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 4));
            DisplayName.SetDefault("Amuleto de Manipulação");
            Tooltip.SetDefault("Redução do resfriamento da Habilidade de Resistência de 20% \ nFaz rstans de corpo a corpo infligir Chamas Amaldiçoadas nos inimigos.");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 1;
            item.value = Item.buyPrice(0, 50, 0, 0);
            item.rare = ItemRarityID.Lime;
            item.accessory = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<MyPlayer>().standCooldownReduction += 0.2f;
            player.GetModPlayer<MyPlayer>().greaterDestroyEquipped = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("GreaterGoldAmuletOfControl"));
            recipe.AddIngredient(mod.ItemType("GreaterGoldAmuletOfDestroy"));
            recipe.AddIngredient(mod.ItemType("WillToControl"), 2);
            recipe.AddIngredient(mod.ItemType("WillToDestroy"), 2);
            recipe.AddIngredient(ItemID.Ectoplasm, 5);
            recipe.AddTile(mod.TileType("RemixTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
