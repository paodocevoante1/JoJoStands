using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace JoJoStands.Items.Accessories
{
    public class CrackedPearl : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pérola rachada");
            Tooltip.SetDefault("Uma pérola não bem removida daquele anel. Parece vazar algum tipo de gás infectante.");
        }
        public override void SetDefaults()
        {
            item.width = 100;
            item.height = 8;
            item.maxStack = 1;
            item.value = Item.buyPrice(0, 50, 0, 0);
            item.rare = 6;
            item.accessory = true;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<MyPlayer>().crackedPearlEquipped = true;
        }
    }
}
