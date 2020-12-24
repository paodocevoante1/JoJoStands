using Terraria;
using Terraria.ModLoader;
 
namespace JoJoStands.Buffs.PlayerBuffs
{
    public class SharpMind : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Mente afiada");
            Description.SetDefault("Seus reflexos mentais foram aguçados e, portanto, sua Chance de Crítico de Resistência aumentou em 10%");
            Main.buffNoTimeDisplay[Type] = false;
        }
 
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MyPlayer>().standCritChangeBoosts += 10f;
        }
    }
}
