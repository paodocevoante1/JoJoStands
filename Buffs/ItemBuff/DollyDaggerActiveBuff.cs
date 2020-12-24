using Terraria;
using Terraria.ModLoader;
 
namespace JoJoStands.Buffs.ItemBuff
{
    public class DollyDaggerActiveBuff : ModBuff
    {
        public override void SetDefaults()
        {
			DisplayName.SetDefault("Dolly Dagger");
            Description.SetDefault("Quando atingido, uma certa porcentagem do dano é refletida de volta para o inimigo.");
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer mPlayer = player.GetModPlayer<MyPlayer>();
            if (mPlayer.standAccessory)     //rather than having to check the Stand Slot for any 4 items
            {
                if (mPlayer.StandSlot.Item.type == mod.ItemType("DollyDaggerT1"))
                {
                    player.endurance += 0.35f;
                }
                if (mPlayer.StandSlot.Item.type == mod.ItemType("DollyDaggerT2"))
                {
                    player.endurance += 0.7f;
                }
                player.buffTime[buffIndex] = 10;
            }
        }
    }
}
