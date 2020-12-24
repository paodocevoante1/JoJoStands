using Terraria;
using Terraria.ModLoader;
 
namespace JoJoStands.Buffs.PlayerBuffs
{
    public class StrongWill : ModBuff
    {
        public override void SetDefaults()
        {
			DisplayName.SetDefault("Força De Vontade");
            Description.SetDefault("Você sente como se você e seu suporte pudessem fazer qualquer coisa! \ N + 10% de aumento de dano do suporte");
            Main.buffNoTimeDisplay[Type] = false;
        }
 
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MyPlayer>().standDamageBoosts += 0.1f;
        }
    }
}
