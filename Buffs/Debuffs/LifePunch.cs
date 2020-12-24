using System;
using Terraria;
using Terraria.ModLoader;

namespace JoJoStands.Buffs.Debuffs
{
    public class LifePunch : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Punho da Vida");
            Description.SetDefault("Seus sentidos estão acelerados e seu corpo não consegue acompanhar você!");
            Main.persistentBuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = true;
        }

        private bool appliedChange = false;

        public override void Update(Player player, ref int buffIndex)
        {
            player.velocity.X *= 0.5f;
            player.statDefense -= 5;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            if (Math.Abs(npc.velocity.X) > 0.5f)
            {
                npc.velocity.X *= 0.9f;
            }
            if (!appliedChange)
            {
                npc.defense -= 5;
                appliedChange = true;
            }
        }
    }
}
