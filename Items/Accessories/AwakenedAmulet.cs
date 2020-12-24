using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace JoJoStands.Items.Accessories
{
    public class AwakenedAmulet : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 8));
            Tooltip.SetDefault("Um amuleto que representa e melhora perfeitamente a forma da alma. \n30% de dano de ataque de stand aumentada \n2 Velocidade de stand aumentada \n20% Redução de resfriamento da Habilidade de stand aumentada \n30% de chance de crítica de stand aumentada \nFaz ataques stands de corpo a corpo infligir debuff Infectados nos inimigos  \naumento de defesa enquanto o Stand está fora");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 1;
            item.value = Item.buyPrice(1, 0, 0, 0);
            item.rare = ItemRarityID.Red;
            item.accessory = true;
        }

        public override void UpdateEquip(Player player)
        {
            MyPlayer mPlayer = player.GetModPlayer<MyPlayer>();
            mPlayer.standDamageBoosts += 0.3f;
            mPlayer.standSpeedBoosts += 2;
            mPlayer.standCooldownReduction += 0.2f;
            mPlayer.standCritChangeBoosts += 30f;
            mPlayer.awakenedAmuletEquipped = true;
            if (mPlayer.StandOut)
            {
                player.statDefense += 10;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("GoldAmuletOfManipulation"));
            recipe.AddIngredient(mod.ItemType("GoldAmuletOfServing"));
            recipe.AddIngredient(mod.ItemType("GoldAmuletOfAdapting"));
            recipe.AddIngredient(mod.ItemType("ViralMeteoriteBar"), 5);
            recipe.AddRecipeGroup(RecipeGroupID.Fragment, 5);
            recipe.AddTile(mod.TileType("RemixTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("PlatinumAmuletOfManipulation"));
            recipe.AddIngredient(mod.ItemType("PlatinumAmuletOfServing"));
            recipe.AddIngredient(mod.ItemType("PlatinumAmuletOfAdapting"));
            recipe.AddIngredient(mod.ItemType("ViralMeteoriteBar"), 5);
            recipe.AddRecipeGroup(RecipeGroupID.Fragment, 5);
            recipe.AddTile(mod.TileType("RemixTableTile"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
