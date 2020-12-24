using Terraria;
using Terraria.ModLoader;
 
namespace JoJoStands.Buffs.Debuffs
{
    public class Sunburn : ModBuff
    {
        public override void SetDefaults()
        {
			DisplayName.SetDefault("Queimadura de sol");
            Description.SetDefault("Você está queimando à luz do sol!");
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }
 
        public override void Update(Player player, ref int buffIndex)
        {
            if (player.lifeRegen > 0)
            {
                player.lifeRegen = 0;
            }
            player.lifeRegenTime = 0;
            player.lifeRegen -= 60;     //losing 30 health
            player.moveSpeed *= 0.5f;
            if (Main.rand.Next(0, 2) == 0)
                Dust.NewDust(player.position, player.width, player.height, 169, player.velocity.X * -0.5f, player.velocity.Y * -0.5f);
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            if (npc.lifeRegen > 0)
            {
                npc.lifeRegen = 0;
            }
            npc.lifeRegenExpectedLossPerSecond = 30;
            npc.lifeRegen -= 60;     //losing 30 health
            if (Main.rand.Next(0, 2) == 0)
                Dust.NewDust(npc.position, npc.width, npc.height, 169, npc.velocity.X * -0.5f, npc.velocity.Y * -0.5f);
        }
    }
}
