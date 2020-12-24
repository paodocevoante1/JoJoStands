using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JoJoStands.Buffs.Debuffs
{
    public class Spin : ModBuff
    {
        public static int directionCounter = 0;
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Spin");
            Description.SetDefault("Você está sendo girado infinitamente ... Não há esperança de sobreviver.");
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            Main.persistentBuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.direction *= -1;
            player.lifeRegen = -60;
            player.moveSpeed /= 2;
            player.buffTime[buffIndex] = 2;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            directionCounter++;
            if (directionCounter >= 5)
            {
                npc.direction *= -1;
                directionCounter = 0;
            }
            if (!npc.HasBuff(mod.BuffType("Spin")))
            {
                directionCounter = 0;
            }
            npc.AddBuff(BuffID.Confused, 95);
            npc.lifeRegen = (npc.lifeMax / 8) * -1;
            npc.buffTime[buffIndex] = 2;
            if (Math.Abs(npc.velocity.X) > 1f)
            {
                npc.velocity.X *= 0.5f;
            }
        }
    }
}
