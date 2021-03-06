using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JoJoStands.Buffs.Debuffs
{
    public class MissingOrgans : ModBuff
    {
        private float savedVelocityX = -1f;

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Órgãos ausentes!");
            Description.SetDefault("Partes do seu corpo foram arrancadas!");
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.lifeRegen > 0)
            {
                player.lifeRegen = 0;
            }
            player.lifeRegenTime = 0;
            player.lifeRegen -= 20;
            player.moveSpeed *= 0.6f;
            Dust.NewDust(player.position, player.width, player.height, DustID.Blood, player.velocity.X * -0.5f, player.velocity.Y * -0.5f);
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            if (savedVelocityX == -1f)
            {
                savedVelocityX = Math.Abs(npc.velocity.X) / 2f;
            }

            if (npc.lifeRegen > 0)
            {
                npc.lifeRegen = 0;
            }
            Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, DustID.Blood, npc.velocity.X * -0.5f, npc.velocity.Y * -0.5f);
            npc.lifeRegenExpectedLossPerSecond = 20;
            npc.lifeRegen -= 60;
            if (Math.Abs(npc.velocity.X) > savedVelocityX)
            {
                npc.velocity.X *= 0.9f;
            }
        }
    }
}
