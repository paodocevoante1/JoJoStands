using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using JoJoStands.Networking;

namespace JoJoStands.Buffs.ItemBuff
{
    public class TheWorldBuff : ModBuff
    {
        public override void SetDefaults()
        {
			DisplayName.SetDefault("The World");
            Description.SetDefault("O tempo ... parou");
            Main.persistentBuff[Type] = true;
            Main.debuff[Type] = true;
            canBeCleared = false;
        }

        public bool sendFalse = false;
 
        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer mPlayer = player.GetModPlayer<MyPlayer>();
            if (!player.HasBuff(mod.BuffType(Name)))
            {
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    mPlayer.TheWorldEffect = false;
                }
                else
                {
                    for (int i = 0; i < Main.maxPlayers; i++)
                    {
                        Player otherPlayers = Main.player[i];
                        if (otherPlayers.active && otherPlayers.whoAmI != player.whoAmI)
                        {
                            if (otherPlayers.HasBuff(mod.BuffType(Name)))
                            {
                                sendFalse = false;      //don't send the packet and let the buff end if you weren't the only timestop owner
                            }
                            else
                            {
                                sendFalse = true;       //send the packet if no one is owning timestop
                            }
                        }
                        if (player.active && !otherPlayers.active)       //for those people who just like playing in multiplayer worlds by themselves... (why does this happen)
                        {
                            sendFalse = true;
                        }
                    }
                }
                if (Main.netMode == NetmodeID.MultiplayerClient && sendFalse)
                {
                    mPlayer.TheWorldEffect = false;
                    ModNetHandler.effectSync.SendTimestop(256, player.whoAmI, false, player.whoAmI);
                }
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/sound/timestop_stop"));
                player.AddBuff(mod.BuffType("AbilityCooldown"), mPlayer.AbilityCooldownTime(30));
                if (Filters.Scene["GreyscaleEffect"].IsActive())
                {
                    Filters.Scene["GreyscaleEffect"].Deactivate();
                }
            }
        }
    }
}
