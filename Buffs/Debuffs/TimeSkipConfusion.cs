using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
 
namespace JoJoStands.Buffs.Debuffs
{
    public class TimeSkipConfusion : ModBuff
    {
        public override void SetDefaults()
        {
			DisplayName.SetDefault("O tempo saltou?");
            Description.SetDefault("O que você acabou de ver foi o seu futuro eu.");
            Main.persistentBuff[Type] = true;
            Main.debuff[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.velocity = Vector2.Zero;
            npc.AddBuff(BuffID.Confused, 2);
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.velocity = Vector2.Zero;
            player.AddBuff(BuffID.Confused, 2);
        }
    }
}
