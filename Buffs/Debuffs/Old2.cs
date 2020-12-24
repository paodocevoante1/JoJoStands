﻿using System;
using Terraria;
using Terraria.ModLoader;

namespace JoJoStands.Buffs.Debuffs
{
    public class Old2 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Velho");
            Description.SetDefault("Você pode sentir toda a sua energia vital saindo.");
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        private bool oneTimeEffectsApplied = false;
        private float savedVelocityX = -1f;

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.lifeRegen > 0)
            {
                player.lifeRegen = 0;
            }
            player.lifeRegenTime = 120;
            player.lifeRegen -= 16;
            player.moveSpeed *= 0.8f;
            player.meleeDamage *= 0.75f;
            player.rangedDamage *= 0.75f;
            player.magicDamage *= 0.75f;
            player.meleeSpeed *= 0.5f;
            player.statDefense = (int)(player.statDefense * 0.8f);
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            Player player = Main.player[Main.myPlayer];
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
            if (savedVelocityX == -1f)
            {
                savedVelocityX = Math.Abs(npc.velocity.X) / 2f;
            }
            if (!oneTimeEffectsApplied)
            {
                npc.defense = (int)(npc.defense * 0.2f);
                oneTimeEffectsApplied = true;
            }

            npc.lifeRegen = -250;
            if (Math.Abs(npc.velocity.X) > savedVelocityX)
            {
                npc.velocity.X *= 0.8f;
            }
            if (modPlayer.gratefulDeadTier == 3)
            {
                npc.lifeRegen = -350;
            }
            if (modPlayer.gratefulDeadTier == 4)
            {
                npc.lifeRegen = -500;
            }
        }
    }
}
