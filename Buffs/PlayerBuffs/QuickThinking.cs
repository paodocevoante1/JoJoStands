using Terraria;
using Terraria.ModLoader;
 
namespace JoJoStands.Buffs.PlayerBuffs
{
    public class QuickThinking : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Pensamento rápido");
            Description.SetDefault("Você é muito mais rápido em saber o que fazer e como fazer. \ Velocidade do suporte aumentada em 1.");
            Main.buffNoTimeDisplay[Type] = false;
        }
 
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MyPlayer>().standSpeedBoosts += 1;
        }
    }
}
