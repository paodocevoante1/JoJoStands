using Terraria;
using Terraria.ModLoader;
 
namespace JoJoStands.Buffs.Debuffs
{
    public class AbilityCooldown : ModBuff
    {
        public override void SetDefaults()
        {
			DisplayName.SetDefault("Habilidade em Recarga");
            Description.SetDefault("Você não pode mais usar nenhuma habilidade de stand ...");
            Main.persistentBuff[Type] = true;
            Main.debuff[Type] = true;
            canBeCleared = false;
        }
    }
}
