using Terraria;
using Terraria.ModLoader;
 
namespace JoJoStands.Buffs.PlayerBuffs
{
    public class CoordinatedEyes : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Olhos Coordenados");
            Description.SetDefault("Seus olhos podem focar em tudo, portanto, sua posição pode ir ainda mais longe. (Raio de alcance do bloco +1)");
            Main.buffNoTimeDisplay[Type] = false;
        }
 
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MyPlayer>().standRangeBoosts += 32f;
        }
    }
}
