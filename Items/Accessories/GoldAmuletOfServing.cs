﻿using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace JoJoStands.Items.Accessories
{
    public class GoldAmuletOfServing : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 4));
            DisplayName.SetDefault("Amuleto de Servir");
            Tooltip.SetDefault("Dano de ataque de suporte aumentado em 30% e aumento da defesa enquanto o stand está fora");
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
            player.GetModPlayer<MyPlayer>().standDamageBoosts += 0.3f;
            if (player.GetModPlayer<MyPlayer>().StandOut)
            {
                player.statDefense += 10;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("GreaterGoldAmuletOfFight"));
            recipe.AddIngredient(mod.ItemType("GreaterGoldAmuletOfProtect"));
            recipe.AddIngredient(mod.ItemType("WillToFight"), 2);
            recipe.AddIngredient(mod.ItemType("WillToProtect"), 2);
            recipe.AddIngredient(ItemID.Ectoplasm, 5);
            recipe.AddTile(mod.TileType("RemixTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
