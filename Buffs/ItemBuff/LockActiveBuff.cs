using Terraria;
using Terraria.ModLoader;
 
namespace JoJoStands.Buffs.ItemBuff
{
    public class LockActiveBuff : ModBuff
    {
        public override void SetDefaults()
        {
			DisplayName.SetDefault("Fechadura");
            Description.SetDefault("Os inimigos que te atingirem sentirão o peso de sua culpa.");
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.GetModPlayer<MyPlayer>().standAccessory)     //rather than having to check the Stand Slot for any 4 items
            {
                player.buffTime[buffIndex] = 10;
            }
        }
    }
}
