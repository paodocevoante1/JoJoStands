﻿using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace JoJoStands.Items.Accessories
{
    public class GreaterGoldAmuletOfProtect : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 4));
            DisplayName.SetDefault("Grande Amuleto da Proteção");
            Tooltip.SetDefault("Maior defesa enquanto o Stand está fora");
        }
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 1;
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.Pink;
            item.accessory = true;
        }

        public override void UpdateEquip(Player player)
        {
            if (player.GetModPlayer<MyPlayer>().StandOut)
            {
                player.statDefense += 10;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Chain, 1);
            recipe.AddIngredient(ItemID.HallowedBar, 5);
            recipe.AddIngredient(mod.ItemType("WillToProtect"), 5);
            recipe.AddTile(mod.TileType("RemixTableTile"));
            recipe.AddIngredient(mod.ItemType("GoldAmuletOfProtect"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
