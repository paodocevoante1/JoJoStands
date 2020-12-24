using Terraria;
using Terraria.ModLoader;

namespace JoJoStands.Buffs.ItemBuff
{
    public class CooledOut : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Esfriado");
            Description.SetDefault("Você baixou a temperatura do corpo.");
            Main.buffNoTimeDisplay[Type] = false;
        }
    }
}
