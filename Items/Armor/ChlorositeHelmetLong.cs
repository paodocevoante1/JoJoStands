﻿using Terraria.ID;
using Terraria;
using Terraria.ModLoader;


namespace JoJoStands.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class ChlorositeHelmetLong : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chlorosite Helmet (Long-Ranged)");
            Tooltip.SetDefault("A helmet that is made with Chlorophyte infused with an otherworldly virus.\n15% Stand Damage");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 24;
            item.value = Item.buyPrice(0, 3, 0, 0);
            item.rare = ItemRarityID.LightRed;
            item.defense = 10;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("ChlorositeChestplate") && legs.type == mod.ItemType("ChlorositeLeggings");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "+5% Stand Damage\nSummons a Crystal Leaf";
            player.GetModPlayer<MyPlayer>().standDamageBoosts += 0.5f;
            player.crystalLeaf = true;
        }

        public override void UpdateEquip(Player player)
        {
            MyPlayer mPlayer = player.GetModPlayer<MyPlayer>();
            mPlayer.standCritChangeBoosts += 15f;
            mPlayer.standDamageBoosts += 0.18f;

            if (mPlayer.standType == 0)
            {
                item.type = mod.ItemType("ChlorositeHelmetNeutral");
                item.SetDefaults(mod.ItemType("ChlorositeHelmetNeutral"));
            }
            if (mPlayer.standType == 1)
            {
                item.type = mod.ItemType("ChlorositeHelmetShort");
                item.SetDefaults(mod.ItemType("ChlorositeHelmetShort"));
            }
        }
    }
}