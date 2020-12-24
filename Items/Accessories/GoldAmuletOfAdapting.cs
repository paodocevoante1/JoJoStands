using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace JoJoStands.Items.Accessories
{
    public class GoldAmuletOfAdapting : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 4));
            DisplayName.SetDefault("Amuleto de Adaptação");
            Tooltip.SetDefault("2 velocidade de ataque de resistência aumentada \n30% de chance de crítica de resistência aumentada");
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
            player.GetModPlayer<MyPlayer>().standSpeedBoosts += 2;
            player.GetModPlayer<MyPlayer>().standCritChangeBoosts += 30f;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("GreaterGoldAmuletOfEscape"));
            recipe.AddIngredient(mod.ItemType("GreaterGoldAmuletOfChange"));
            recipe.AddIngredient(mod.ItemType("WillToChange"), 2);
            recipe.AddIngredient(mod.ItemType("WillToEscape"), 2);
            recipe.AddIngredient(ItemID.Ectoplasm, 5);
            recipe.AddTile(mod.TileType("RemixTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
