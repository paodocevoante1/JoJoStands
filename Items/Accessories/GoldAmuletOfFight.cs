﻿using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace JoJoStands.Items.Accessories
{
    public class GoldAmuletOfFight : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 4));
            DisplayName.SetDefault("Amuleto de Luta");
            Tooltip.SetDefault("Danos de ataque de stand aumentados em 10%");
        }
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 1;
            item.value = Item.buyPrice(0, 0, 25, 0);
            item.rare = ItemRarityID.Blue;
            item.accessory = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<MyPlayer>().standDamageBoosts += 0.1f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Chain, 1);
            recipe.AddIngredient(ItemID.GoldBar, 3);
            recipe.AddIngredient(mod.ItemType("WillToFight"), 3);
            recipe.AddTile(mod.TileType("RemixTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
