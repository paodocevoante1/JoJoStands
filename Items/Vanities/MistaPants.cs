using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JoJoStands.Items.Vanities
{
	[AutoloadEquip(EquipType.Legs)]
	public class MistaPants : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mista's Pants");
            Tooltip.SetDefault("A tacky pair of red pants with black boots. Your fashion sense is odd.");
		}

		public override void SetDefaults()
        {
			item.width = 18;
			item.height = 18;
			item.rare = 6;
			item.vanity = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}