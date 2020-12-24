using Terraria;
using Terraria.ModLoader;
 
namespace JoJoStands.Buffs.PetBuffs
{
    public class ZeppeliPetBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Zeppeli Pet");
            Description.SetDefault("Ele diz que vai embora se você derramar o vinho.");
            Main.buffNoTimeDisplay[Type] = false;
        }
 
        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[mod.ProjectileType("ZeppeliPet")] != 0)
            {
                player.buffTime[buffIndex] = 2;
            }
        }
    }
}
