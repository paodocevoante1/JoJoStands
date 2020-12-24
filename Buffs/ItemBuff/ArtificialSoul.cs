using Terraria;
using Terraria.ModLoader;
 
namespace JoJoStands.Buffs.ItemBuff
{
    public class ArtificialSoul : ModBuff
    {
        public override void SetDefaults()
        {
			DisplayName.SetDefault("Alma Artificial");
            Description.SetDefault("Uma alma artificial foi dada a você!");
            canBeCleared = false;
            Main.debuff[Type] = true;
        }
    }
}
