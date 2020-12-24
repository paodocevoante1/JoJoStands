using Terraria;
using Terraria.ModLoader;
 
namespace JoJoStands.Buffs.AccessoryBuff
{
    public class SpaceFreeze : ModBuff
    {
        public override void SetDefaults()
        {
			DisplayName.SetDefault("Espaço Congelante!");
            Description.SetDefault("Você subiu muito e agora vai ficar no espaço pelo resto da eternidade ... Divirta-se!");
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }
 
        public override void Update(Player player, ref int buffIndex)
        {
            if (player.lifeRegen > 0)
            {
                player.lifeRegen = 0;
            }
            player.velocity.Y += -0.2f;
            player.velocity.X += -0.2f;
            player.lifeRegenTime = 0;
            player.lifeRegen -= 120;
            player.moveSpeed *= 0.5f;
        }
    }
}
