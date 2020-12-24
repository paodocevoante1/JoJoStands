using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.ID;

namespace JoJoStands.Items.Accessories
{
    public class ViralPearlRing : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Anel de Perola viral");
            Tooltip.SetDefault("Clique com o botão direito para remover a pérola. Tenha cuidado para não quebrá-lo!");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.accessory = true;
            item.rare = ItemRarityID.LightRed;
            item.value = Item.buyPrice(0, 2, 0, 0);
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.maxStack = 1;
            item.consumable = true;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                int proj = Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("ViralPearl"), 0, 0f, player.whoAmI);
                Main.projectile[proj].netUpdate = true;
                item.TurnToAir();
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
