using Terraria;
using Terraria.ModLoader;

namespace JoJoStands.Buffs.AccessoryBuff
{
    public class Locked : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Bloqueado");
            Description.SetDefault("Sua culpa está aumentando e machuca.");
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }
    }
}
