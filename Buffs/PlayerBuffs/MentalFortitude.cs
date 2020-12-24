using Terraria;
using Terraria.ModLoader;
 
namespace JoJoStands.Buffs.PlayerBuffs
{
    public class MentalFortitude : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Fortaleza Mental");
            Description.SetDefault("Sua vontade é inquebrável. \ Defesa aumentada em 3.");
            Main.buffNoTimeDisplay[Type] = false;
        }
 
        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 3;
        }
    }
}
